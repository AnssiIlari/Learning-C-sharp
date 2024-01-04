using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace Tehtävä_1_Testiversio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        private int counterA; // laskurimuuttuja
        private int counterB;
        private int counterC;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Tehdään säikeet ja käynnistetään ne
            Thread t1 = new Thread(PrintA);
            t1.Start();

            Thread t2 = new Thread(PrintB);
            t2.Start();

            Thread t3 = new Thread(PrintC);
            t3.Start();
        }
        /// <summary>
        /// Metodi ensimmäisen labelin tulostusta varten
        /// </summary>
        private void PrintA()
        {

            while (counterA < 100)
            {
                counterA++;

                Thread.Sleep(100);

                Dispatcher.Invoke(() =>
                {
                    lblA.Content = "A" + counterA;
                });
            }
        }

        /// <summary>
        /// Metodi toisen labelin tulostusta varten
        /// </summary>
        private void PrintB()
        {
            while (counterB < 100)
            {
                counterB++;

                Thread.Sleep(100);

                Dispatcher.Invoke(() =>
                {
                    lblB.Content = "B" + counterB;
                });
            }
        }

        /// <summary>
        /// Metodi kolmannen labelin tulostusta varten
        /// </summary>
        private void PrintC()
        {
            while (counterC < 100)
            {
                counterC++;

                Thread.Sleep(100);

                Dispatcher.Invoke(() =>
                {
                    lblC.Content = "C" + counterC;
                });
            }
        }
    }
}
