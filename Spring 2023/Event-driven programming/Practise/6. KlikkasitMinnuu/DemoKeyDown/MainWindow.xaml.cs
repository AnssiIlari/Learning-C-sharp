using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace DemoKeyDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //canvas.Focus();
            myTextBox.Focus();


        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            this.Title = e.Key.ToString();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.A)
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
            //myTextBox.Text = e.Key.ToString();
        }
    }
}
