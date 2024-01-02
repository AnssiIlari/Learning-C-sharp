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

namespace Harjoitustehtävä_1._3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Rectangle rectangle = new Rectangle();
            rectangle.Width = 80;
            rectangle.Height = 80;
            rectangle.Fill = Brushes.Red;

            Grid.SetColumn(rectangle, 4);
            Grid.SetRow(rectangle, 5);

            Grid.SetColumnSpan(rectangle, 2);
            Grid.SetRowSpan(rectangle, 2);

            this.Content = myGrid;
            myGrid.Children.Add(rectangle);

        }
    }
}
