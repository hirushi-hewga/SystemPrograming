using System.Diagnostics;
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

namespace _1_TaskManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadProcesses();
        }

        public void LoadProcesses()
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            LoadProcesses();
        }

        private void Kill_Button_Click(object sender, RoutedEventArgs e)
        {
            Process selected = grid.SelectedItem as Process;
            if (selected == null)
            {
                MessageBox.Show("Process is not selected");
                return;
            }
            selected.Kill();
            MessageBox.Show("Process is killed");
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowInfo_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartProcess_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}