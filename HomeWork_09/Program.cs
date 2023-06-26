using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HomeWork_09;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using File = System.IO.File;

namespace HomeWork_09
{
    class Program
    {
        /// <summary>
        /// Путь к файлу со списком сообщений
        /// </summary>
        static string _fileName = "updates.json";

        /// <summary>
        /// Список сообщений
        /// </summary>
        static List<BotData> botUpdates = new List<BotData>();

        /// <summary>
        /// Токен для бота
        /// </summary>
        private static BotToken? _botToken =
            JsonConvert.DeserializeObject<BotToken>(System.IO.File.ReadAllText(@"D:\Bot_Token.json"));

        /// <summary>
        /// Инициализация бота
        /// </summary>
        static TelegramBotClient _bot = new(_botToken?.Token);

        /// <summary>
        /// Путь к папке с файлами
        /// </summary>
        static string _directoryPath = "Files";
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var botUpdatesString = System.IO.File.ReadAllText(_fileName);

                botUpdates = JsonConvert.DeserializeObject<List<BotData>>(botUpdatesString) ?? botUpdates;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading or deserializing {ex}");
            }

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage
                }
            };

            _bot.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions);
            
            Console.ReadLine();

            ClearData();
        }

        /// <summary>
        /// Очистка данных после завершения
        /// </summary>
        private static void ClearData()
        {
            File.WriteAllText(_fileName, string.Empty);
            foreach (var fileInfo in GetFileList())
            {
                fileInfo.Delete();
            }
        }

        /// <summary>
        /// Что-то про ошибки
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Наблюдатель за сообщениями
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="update"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        private static async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken arg3)
        {
            if (update.Type == UpdateType.Message)
            {
                var botUpdate = Update(update);
                
                switch (update.Message.Type)
                {
                    case MessageType.Audio:
                    case MessageType.Document:
                    case MessageType.Video:
                    case MessageType.Unknown:
                        WriteFileToDisk(botUpdate);
                        break;
                    case MessageType.Text:
                        if (update.Message.Text == "/start")
                        {
                            await _bot.SendTextMessageAsync(update.Message.Chat.Id,
                                $"Привет {update.Message.From.Username}", cancellationToken: arg3);
                        }
                        else if (update.Message.Text == "/all")
                        {
                            var fileList = GetFileList();
                            if (!fileList.Any())
                            {
                                await _bot.SendTextMessageAsync(update.Message.Chat.Id, $"Файлы отсутствуют",
                                    cancellationToken: arg3);
                                break;
                            }
                                
                            foreach (var fileInfo in fileList)
                            {
                                var botUpdateInfo =
                                    botUpdates.FirstOrDefault(c => fileInfo.Name.Contains(c.TelegramFile.FileId));
                                await _bot.SendDocumentAsync(update.Message.Chat.Id,
                                    new InputMedia(fileInfo.OpenRead(), botUpdateInfo.TelegramFile.FileName),
                                    cancellationToken: arg3);
                            }
                        }
                        else if (update.Message.Text[0] == '/')
                        {
                            await _bot.SendTextMessageAsync(update.Message.Chat.Id,
                                $"{update.Message.Text} не является командой", cancellationToken: arg3);
                        }
                        break;
                }
                botUpdates.Add(botUpdate);
                var botUpdatesString = JsonConvert.SerializeObject(botUpdates);
                await System.IO.File.WriteAllTextAsync(_fileName, botUpdatesString, arg3);
            }
        }

        /// <summary>
        /// Получение файлов
        /// </summary>
        /// <returns></returns>
        private static List<FileInfo> GetFileList()
        {
            var filePathList = Directory.GetFiles(_directoryPath).ToList();
            return filePathList.Select(c => new FileInfo(c)).ToList();
        }

        /// <summary>
        /// Запись файла на диск
        /// </summary>
        /// <param name="botUpdate"></param>
        private static async void WriteFileToDisk(BotData botUpdate)
        {
            string path = Path.Combine(_directoryPath, $"{botUpdate.TelegramFile.FileId}_{botUpdate.TelegramFile.FileName}");
            var fs = new FileStream(path, FileMode.Create);
            await _bot.GetInfoAndDownloadFileAsync(botUpdate.TelegramFile.FileId, fs);
            fs.Close();

            await fs.DisposeAsync();
        }

        /// <summary>
        /// Обновление файла с историей
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        private static BotData Update(Update update)
        {
            dynamic? fileBase = update.Message?.Document != null ? update.Message.Document :
                update.Message?.Audio != null ? update.Message.Audio : update.Message?.Video ?? null;

            TelegramFile telegramFile = null;
            try
            {
                telegramFile = new TelegramFile();
                telegramFile.FileId = fileBase.FileId;
                telegramFile.FileName = fileBase.FileName;
            }
            catch
            {
                // ignored
            }

            return new BotData
            {
                Text = update.Message?.Text,
                ChatId = update.Message.Chat.Id,
                Username = update.Message.Chat.Username,
                TelegramFile = telegramFile,
                MessageType = update.Message.Type
            };
        }
    }
}
