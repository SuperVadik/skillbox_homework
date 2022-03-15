using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace HomeWork_09
{
    /// <summary>
    /// 
    /// </summary>
    internal class BotData
    {
        public string? Text;
        public long ChatId;
        public string? Username;
        public TelegramFile TelegramFile;
        public MessageType? MessageType;
    }

    /// <summary>
    /// 
    /// </summary>
    internal class TelegramFile
    {
        public string FileName;
        public string FileId;
    }
}
