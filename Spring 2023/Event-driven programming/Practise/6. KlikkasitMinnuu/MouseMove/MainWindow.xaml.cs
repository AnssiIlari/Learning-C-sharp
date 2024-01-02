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

namespace MouseMove
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

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //Title = "Toimii!";
            //Title = e.GetPosition(this).X.ToString() + ", " + e.GetPosition(this).Y.ToString();

            //var point  = e.GetPosition(this);
            //Title = point.X + ", " + point.Y;


            Title = e.GetPosition(this).ToString();

            Leibeli.Content= e.GetPosition(this).ToString();

            Canvas.SetLeft(Leibeli, e.GetPosition(this).X);
            Canvas.SetTop(Leibeli, e.GetPosition(this).Y);

            // Canvas.SetLeft(lblPoint, point.X); // Liittyy ylempään point vaihtoehtoon

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse circle= new Ellipse();

            circle.Height = 60;
            circle.Width = 60;

            circle.Fill = Brushes.Orange;

            Canvas.SetLeft(circle, e.GetPosition(this).X -30);
            Canvas.SetTop(circle, e.GetPosition(this).Y -30);

            myCanvas.Children.Add(circle);


        }
    }
}
