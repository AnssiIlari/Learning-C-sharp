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

namespace KlikkasitMinnuu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            txtWidth.Text = this.Width.ToString();
            txtHeight.Text = this.Height.ToString();
            A.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sie klikkasit minnuu!");
        }

        private int count = 0;

        private void ClickCountClick(object sender, RoutedEventArgs e)
        {
            count++;
            this.Title = "Klikkasit painonappia " + count;
        }

        private void ChangeColorClick(object sender, RoutedEventArgs e)
        {
            Background = Brushes.Blue;
        }

        private void IncreaseSize(object sender, RoutedEventArgs e)
        {
            Height += 5;
        }

        private void DecreaseSize(object sender, RoutedEventArgs e)
        {
            Height -= 5;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Width = int.Parse(txtWidth.Text);
            this.Height = int.Parse(txtHeight.Text);
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void nappula_Click(object sender, RoutedEventArgs e)
        {
            nappula.Content = "Kiitos klikkauksestasi!";
            e.Handled= true; // "kuplmisen esto"
        }

        private void AbButtonClicker(object sender, RoutedEventArgs e) // if-rakenne käy myös
        {
            switch (A.IsEnabled)
            {
                case true:
                    A.IsEnabled = false;
                    B.IsEnabled = true;
                    break;
                case false:
                    A.IsEnabled = true;
                    B.IsEnabled = false;
                    break;

                    // A.isEnabled = !A.IsEnabled;
                    // B.isEnabled = !B.IsEnabled;
            }

        }

        private int counter = 0;
        private void AllButtonClick(object sender, RoutedEventArgs e)
        {
            counter++;
            lblCount.Content = counter.ToString();
        }
    }
}
