using Microsoft.WindowsAPICodePack.Dialogs;
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

namespace _3_AsyncAwaitApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();

        public string from_file;
        public string to_directory;

        public MainWindow()
        {
            InitializeComponent();
        }
        //async - allow method to use await keyword
        //await - wait task without freezing

        //private async void Generate_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //int value = GenerateValue(); //freeze

        //    //Task<int> task = Task.Run(GenerateValue);
        //    //task.Wait(); //freeze
        //    //list.Items.Add(task.Result); //freeze

        //    //int value = await GenerateValueAsync();
        //    list.Items.Add(await GenerateValueAsync());
        //    //MessageBox.Show("Complete main!!!");
        //}

        private void From_Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                from_file = dialog.FileName;
                MessageBox.Show("You selected : " + dialog.FileName);
            }
        }

        private void To_Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                to_directory = dialog.FileName;
                MessageBox.Show("You selected : " + dialog.FileName);
            }
        }

        private async void Copy_Button_Click(object sender, RoutedEventArgs e)
        {
            await CopyFileAsync();
        }

        Task CopyFileAsync()
        {
            return Task.Run(() =>
            {
                string new_file_path = Path.Combine(to_directory, Path.GetFileName(from_file));
                File.Copy(from_file, new_file_path, true);
                MessageBox.Show(new_file_path);
            });
        }

        //Task<int> GenerateValueAsync()
        //{
        //    return Task.Run(() =>
        //    {
        //        Thread.Sleep(random.Next(5000));
        //        return random.Next(1000);
        //    });
        //}

        //int GenerateValue()
        //{
        //    Thread.Sleep(random.Next(5000));
        //    //MessageBox.Show("Generated!!!");
        //    return random.Next(1000);
        //}
    }
}