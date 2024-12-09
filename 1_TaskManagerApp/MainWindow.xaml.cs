using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        public bool IsProcessSelected(Process process)
        {
            if (process == null)
            {
                MessageBox.Show("Process is not selected");
                return false;
            }
            return true;
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
            if (!IsProcessSelected(selected)) return;
            selected.Kill();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Process selected = grid.SelectedItem as Process;
            if (!IsProcessSelected(selected)) return;
            selected.CloseMainWindow();
        }

        private void ShowInfo_Button_Click(object sender, RoutedEventArgs e)
        {
            Process selected = grid.SelectedItem as Process;
            if (!IsProcessSelected(selected)) return;
            try
            {
                MessageBox.Show($"Process Name : {selected.ProcessName}" +
                                $"\nPID : {selected.Id}" +
                                $"\nStart Time : {selected.StartTime}" +
                                $"\nUser Name : {selected.MachineName}" +
                                $"\nMemory Usage : {selected.WorkingSet64 / 1024} KB" +
                                $"\nPriority : {selected.BasePriority}" +
                                $"\nMain Window Title : {selected.MainWindowTitle}" +
                                $"\nTotal Processor Time : {selected.TotalProcessorTime}" +
                                $"\nResponding : {selected.Responding}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartProcess_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(prName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}