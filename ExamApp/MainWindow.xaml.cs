using Microsoft.WindowsAPICodePack.Dialogs;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace ExamApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string directory;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void From_Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                directory = dialog.FileName;
                MessageBox.Show("You selected : " + dialog.FileName);
            }
        }

        private async void Find_Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(find_textbox.Text))
            {
                MessageBox.Show("No word entered.");
                return;
            }
            string word = find_textbox.Text;
            List<(string name, string path, int count)> values = await FindAsync(directory, word);
            list.Items = values;
        }

        private Task<List<(string, string, int)>> FindAsync(string directory_path, string word)
        {
            return Task.Run(() =>
            {
                List<(string, string, int)> list = new List<(string, string, int)>();
                string[] files = Directory.GetFiles(directory_path);
                Parallel.ForEach(files, file =>
                {
                    var value = ContainsWordAsync(file, word).Result;
                    if (value.Item3 > 0)
                        lock (list) 
                            list.Add(value);
                });
                string[] directories = Directory.GetDirectories(directory_path);
                if (directories.Length != 0)
                {
                    Parallel.ForEach(directories, directory =>
                    {
                        list.AddRange(FindAsync(directory, word).Result);
                    });
                }
                return list;
            });
        }

        private Task<(string, string, int)> ContainsWordAsync(string file_path, string word)
        {
            return Task.Run(() =>
            {
                string text = File.ReadAllText(file_path);
                int count = 0, index = 0;
                while ((index = text.IndexOf(word, index)) != -1)
                {
                    count++;
                    index += word.Length;
                }
                return (Path.GetDirectoryName(file_path)!, file_path, count);
            });
        }
    }
}