using System;
using System.Collections.Generic;
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

namespace Tehtävä_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    // Join metodi tuntuisi toimivan parhaiten.
    public partial class MainWindow : Window
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
            t1.Join(100);
            t1.Priority = ThreadPriority.Highest;

            t2.Start();
            t2.Join(100);
            t2.Priority= ThreadPriority.Normal;

            t3.Start();
            t3.Join(100);
            t3.Priority = ThreadPriority.Lowest;
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
