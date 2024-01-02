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

namespace Tehtävä_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int left = 350;
        private int top = 175;
        public MainWindow()
        {
            InitializeComponent();
            Canvas.SetLeft(myCircle, left);
            Canvas.SetTop(myCircle, top);
            
        }

        // liikutetaan ympyrää vasemmalle
        private void toLeft(object sender, RoutedEventArgs e)
        {

            left -= 10;
            Canvas.SetLeft(myCircle, left);
            Canvas.SetTop(myCircle, top);
            if (left <= 0)
            {
                left += 10;
            }
        }

        // Liikutetaan ympyrää oikealle
        private void toRight(object sender, RoutedEventArgs e)
        {
            left += 10;
            Canvas.SetLeft(myCircle, left);
            Canvas.SetTop(myCircle, top);
            if (left > 680)
            {
                left -= 10;
            }
        }

        // liikutetaan ympyrää ylöspäin
        private void toUp(object sender, RoutedEventArgs e)
        {
            top -= 10;
            Canvas.SetLeft(myCircle, left);
            Canvas.SetTop(myCircle, top);
            if (top < 0)
            {
                top += 10;
            }
        }

        // liikutetaan ympyrää alaspäin
        private void toDown(object sender, RoutedEventArgs e)
        {
            top += 10;
            Canvas.SetLeft(myCircle, left);
            Canvas.SetTop(myCircle, top);

            if (top > 270)
            {
                top -= 10;
            }
        }
    }
}
