using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace HomeWork_09_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие по нажатию на Кнопку 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                listBox.Items.Clear();
                return;
            }
            foreach (var text in GetStrList(textBox1.Text))
            {
                listBox.Items.Add(text);
            }
        }

        /// <summary>
        /// Событие по нажатию на Кнопку 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                label.Content = string.Empty;
                return;
            }

            List<string> outputStrList = new List<string>();
            
            var inputRevStrList = GetInvertStringList(textBox2.Text);
            labelTextBlock.Text = string.Join(" ", inputRevStrList);
        }

        /// <summary>
        /// Создание массива слов из строки
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        private List<string> GetStrList(string inputStr, char separator = ' ')
        {
            return inputStr.Split(separator).ToList();
        }

        /// <summary>
        /// Получение инвертированного списка
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private List<string> GetInvertStringList(string inputStr)
        {
            var strList = GetStrList(inputStr);
            strList.Reverse();
            return strList;
        }
    }
}
