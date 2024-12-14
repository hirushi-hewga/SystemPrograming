using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3_AsyncAwaitApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }
        //async - allow method to use await keyword
        //await - wait task without freezing

        private async void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            //int value = GenerateValue(); //freeze

            Task<int> task = Task.Run(GenerateValue);
            //task.Wait(); //freeze
            //list.Items.Add(task.Result); //freeze

            await task;
            MessageBox.Show("Complete main!!!");
        }

        int GenerateValue()
        {
            Thread.Sleep(random.Next(5000));
            MessageBox.Show("Generated!!!");
            return random.Next(1000);
        }
    }
}