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
using Athena.Config;

namespace Athena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Randomizer.Randomizer? _randomizer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRandomize_Click(object sender, RoutedEventArgs e)
        {
            string mode = "";
            if (RadioOptionBase.IsChecked == true)
            {
                mode = Constants.OptionBase;
            }
            else if (RadioOptionDlc.IsChecked == true)
            {
                mode = Constants.OptionDlc;
            }
            else if (RadioOptionBaseDlc.IsChecked == true)
            {
                mode = Constants.OptionBaseDlc;
            }
            else
            {
                return;
            }
            _randomizer = new Randomizer.Randomizer(mode);
            _randomizer.run();
        }

        private void btnLaunchEldenRing_Click(object sender, RoutedEventArgs e)
        {
            string fileName = "";

            if (RadioOptionBase.IsChecked == true)
            {
                fileName = Constants.LaunchEldenRingBase;
            }
            else if (RadioOptionDlc.IsChecked == true)
            {
                fileName = Constants.LaunchEldenRingDlc;
            }
            else if (RadioOptionBaseDlc.IsChecked == true)
            {
                fileName = Constants.LaunchEldenRingBaseDlc;
            }
            else
            {
                return;
            }

            Process eldenring = new()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    WorkingDirectory = Constants.ModEngineWorkingDirectory,
                    UseShellExecute = true,
                    CreateNoWindow = true,
                },
            };
            eldenring.Start();
        }
    }
}
