using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Tehtävä_1_Testiversio_1._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // Palauta tämä
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Tehdään säikeet ja käynnistetään ne.
            Thread t1 = new Thread(() => PrintChar('A'));
            Thread t2 = new Thread(() => PrintChar('B'));
            Thread t3 = new Thread(() => PrintChar('C'));
            t1.Start();
            t2.Start();
            t3.Start();

        }

        /// <summary>
        /// Tulostetaan parametrina annettu kirjain + juokseva numero
        /// </summary>
        /// <param name="c"></param>
        private void PrintChar(char c)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(500);

                Dispatcher.Invoke(() =>
                {
                    lblA.Content = c + i.ToString();
                });
            }
        }
    }
}
