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

namespace Harjoitustehtävä_1._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window // Kesken, ei onnistu
    {
        public MainWindow()
        {
            InitializeComponent();

            // Pää

            Ellipse head = new Ellipse();

            head.Width = 70;
            head.Height = 70;
            head.Stroke = Brushes.Black;
            head.StrokeThickness = 1;

            Canvas.SetRight(head, 250);
            Canvas.SetTop(head, 40);

            myCanvas.Children.Add(head);

            // Ruumis

            Line body= new Line();

            body.X1= 500;
            body.Y1= 115;
            body.X2 = 500;
            body.Y2 = 220;
            body.Stroke = Brushes.Black;
            body.StrokeThickness = 1;

            myCanvas.Children.Add(body);

            // Kädet x2

            Line arm1= new Line();
            arm1.X1= 500;
            arm1.Y1 = 115;
            arm1.X2= 420;
            arm1.Y2 = 190;
            arm1.Stroke = Brushes.Black;
            arm1.StrokeThickness = 1;

            myCanvas.Children.Add(arm1);

            Line arm2 = new Line();
            arm2.X1 = 500;
            arm2.Y1 = 115;
            arm2.X2 = 580;
            arm2.Y2 = 190;
            arm2.Stroke = Brushes.Black;
            arm2.StrokeThickness = 1;

            myCanvas.Children.Add(arm2);

            // Jalat x2

            Line leg1 = new Line();
            leg1.X1 = 500;
            leg1.Y1 = 220;
            leg1.X2 = 425;
            leg1.Y2 = 295;
            leg1.Stroke = Brushes.Black;
            leg1.StrokeThickness = 1;

            myCanvas.Children.Add(leg1);

            Line leg2 = new Line();
            leg2.X1 = 500;
            leg2.Y1 = 220;
            leg2.X2 = 575;
            leg2.Y2 = 295;
            leg2.Stroke = Brushes.Black;
            leg2.StrokeThickness = 1;

            myCanvas.Children.Add(leg2);





        }
    }
}
