using Microsoft.WindowsAPICodePack.Dialogs;
using System.CodeDom;
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

namespace ExamApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class FileInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int Count { get; set; }
        public static List<FileInfo> FromTuples(List<(string name, string path, int count)> tuples)
        {
            var fileInfoList = new List<FileInfo>();
            foreach (var (name, path, count) in tuples)
            {
                fileInfoList.Add(new FileInfo { Name = name, Path = path, Count = count });
            }
            return fileInfoList;
        }
    }
    public partial class MainWindow : Window
    {
        public string directory = null;
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
            if (directory == null)
            {
                MessageBox.Show("Directory not selected");
                return;
            }
            string word = find_textbox.Text;
            pbar.Value = 0;
            var progress = new Progress<int>(value => { pbar.Value = value; });
            List<FileInfo> info = FileInfo.FromTuples(await FindAsync(directory, word, progress));
            pbar.Value = pbar.Maximum;
            if (info.Count() != 0) grid.ItemsSource = info;
            else MessageBox.Show("Word not found.");
        }

        private Task<List<(string, string, int)>> FindAsync(string directory_path, string word, IProgress<int> progress)
        {
            return Task.Run(() =>
            {
                List<(string, string, int)> list = new List<(string, string, int)>();
                string[] files = Directory.GetFiles(directory_path, "*.txt");
                int totalFiles = files.Length;
                Parallel.ForEach(files, (file, state, index) =>
                {
                    var value = ContainsWordAsync(file, word).Result;
                    if (value.Item3 > 0)
                        lock (list)
                            list.Add(value);
                    progress?.Report((int)(100 * (index + 1) / totalFiles));
                });
                string[] directories = Directory.GetDirectories(directory_path);
                if (directories.Length != 0)
                {
                    Parallel.ForEach(directories, directory =>
                    {
                        lock (list)
                            list.AddRange(FindAsync(directory, word, progress).Result);
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