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

namespace _2_ProgressBarApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Thread thread;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            //HardWork();
            thread = new Thread(HardWork);
            thread.Start();
        }

        public void HardWork()
        {
            bool isContinue = false;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (progress.Value > 0)
                    progress.Value = progress.Minimum;
                isContinue = progress.Value < progress.Maximum;
            }));
            while (isContinue)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    progress.Value++;
                    isContinue = progress.Value < progress.Maximum;
                }));
                Thread.Sleep(110);
            }
        }
    }
}