using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Threading;

namespace Tehtävä_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    //Tee ohjelma, joka sisältää kolme erillistä säiettä.Kukin säie tulostaa säikeen kirjainta ja juoksevaa
    //numero 100 kertaa. (säie 1 tulostaa A1, A2, A3 jne. ja säie 2 tulostaa B1, B2, B3 ja säie3 tulostaa C1,
    //C2, C3 jne.). Säikeet käynnistetään peräkkäin
    public partial class MainWindow : Window
    {
        private int round = 1;


        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread first = new Thread(PrintA);
            first.Start();

            Thread second = new Thread(PrintB);
            second.Start();

            Thread third = new Thread(PrintC);
            third.Start();
        }

        public void PrintA()
        {
            int counter = 0;

            while (counter < 100)
            {
                counter++;

                Thread.Sleep(20);

                Dispatcher.Invoke(() =>
                {
                    lblA.Content = "A" + counter;
                });
            }
        }

        public void PrintB()
        {
            int counter = 0;

            while (counter < 100)
            {
                counter++;

                Thread.Sleep(20);

                Dispatcher.Invoke(() =>
                {
                    lblB.Content = "B" + counter;
                });
            }
        }

        public void PrintC()
        {
            int counter = 0;

            while (counter < 100)
            {
                counter++;

                Thread.Sleep(20);

                Dispatcher.Invoke(() =>
                {
                    lblC.Content = "C" + counter;
                });
            }
        }
    }
}

// "Muistiinpanoja"
//Dispatcher.Invoke(() =>
//{
//    for (int i = 0; i < 100; i++)
//    {
//        lblA.Content = "A" + i;
//    }
//});