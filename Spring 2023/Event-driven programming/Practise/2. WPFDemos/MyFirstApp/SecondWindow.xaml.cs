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
using System.Windows.Shapes;

namespace MyFirstApp
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            this.Title = "My first App *";
            Width = 600;
            Height = 600;
            MinWidth = 400;
            MinHeight = 400;

            Background = Brushes.BurlyWood;

            MainWindow main = new MainWindow();
            main.Topmost = true;
            main.Show();

        }
    }
}
