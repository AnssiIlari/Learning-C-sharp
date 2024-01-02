using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtävä_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Muutetaan väri labelin tekstin väri punaiseksi
        private void toRed(object sender, MouseButtonEventArgs e)
        {
            lblBox.Foreground = Brushes.Red;
        }

        // Muutetaan labelin tekstin väri siniseksi
        private void toBlue(object sender, MouseButtonEventArgs e)
        {
            lblBox.Foreground = Brushes.Blue;
        }

        // Muutetaan labelin tekstin väri mustaksi, eventhandleri ikkunassa
        private void lblToBlack(object sender, KeyEventArgs e)
        {
            lblBox.Foreground = Brushes.Black;
        }
    }
}
