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

namespace Tehtävä_3
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

        private int guesses; // arvauksien määrä
        private string word = "lintu"; // arvattava sana


        /// <summary>
        /// Piirtää tarvittavat osat jos arvattava kirjain ei ole arvattavassa sanassa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            string guess = e.Key.ToString();
            guess = guess.ToLower();

            // onko arvattu kirjain arvattavassa sanassa
            if ((word.Contains(guess)) == false)
            {
                // Piirrellään tikku-ukkoa jos kirjain ei ole sanassa
                switch (guesses)
                {
                    // pää
                    case 0:

                        Ellipse head = new Ellipse();

                        head.Width = 40;
                        head.Height = 40;
                        head.Stroke = Brushes.Black;
                        head.StrokeThickness = 1;

                        Canvas.SetRight(head, 260);
                        Canvas.SetTop(head, 145);

                        myCanvas.Children.Add(head);
                        guesses++;
                        break;

                    // ruumis
                    case 1:
                        Line body = new Line();

                        body.X1 = 500;
                        body.Y1 = 115;
                        body.X2 = 500;
                        body.Y2 = 175;
                        body.Stroke = Brushes.Black;
                        body.StrokeThickness = 1;
                        Canvas.SetRight(body, 280);
                        Canvas.SetTop(body, 70);

                        myCanvas.Children.Add(body);
                        guesses++;
                        break;
                    // Käsi
                    case 2:
                        Line arm1 = new Line();
                        arm1.X1 = 500;
                        arm1.Y1 = 115;
                        arm1.X2 = 420;
                        arm1.Y2 = 190;
                        arm1.Stroke = Brushes.Black;
                        arm1.StrokeThickness = 1;
                        Canvas.SetRight(arm1, 280);
                        Canvas.SetTop(arm1, 70);

                        myCanvas.Children.Add(arm1);
                        guesses++;
                        break;

                    // Käsi
                    case 3:
                        Line arm2 = new Line();
                        arm2.X1 = 500;
                        arm2.Y1 = 115;
                        arm2.X2 = 580;
                        arm2.Y2 = 190;
                        arm2.Stroke = Brushes.Black;
                        arm2.StrokeThickness = 1;
                        Canvas.SetRight(arm2, 200);
                        Canvas.SetTop(arm2, 70);

                        myCanvas.Children.Add(arm2);
                        guesses++;
                        break;
                    // Jalka    
                    case 4:
                        Line leg1 = new Line();
                        leg1.X1 = 500;
                        leg1.Y1 = 220;
                        leg1.X2 = 425;
                        leg1.Y2 = 295;
                        leg1.Stroke = Brushes.Black;
                        leg1.StrokeThickness = 1;
                        Canvas.SetRight(leg1, 280);
                        Canvas.SetTop(leg1, 25);

                        myCanvas.Children.Add(leg1);
                        guesses++;
                        break;

                    // jalka
                    case 5:
                        Line leg2 = new Line();
                        leg2.X1 = 500;
                        leg2.Y1 = 220;
                        leg2.X2 = 575;
                        leg2.Y2 = 295;
                        leg2.Stroke = Brushes.Black;
                        leg2.StrokeThickness = 1;
                        Canvas.SetRight(leg2, 205);
                        Canvas.SetTop(leg2, 25);

                        myCanvas.Children.Add(leg2);
                        MessageBox.Show("Game over!");

                        break;
                }
            }
            // Tämä ei ole sinne päinkään, tehty kuitenkin
            else
            {
                switch (guess)
                {
                    case "l":
                        txtBlock.Text = "l****";
                        break;
                    case "i":
                        txtBlock.Text = "li***";
                        break;
                    case "n":
                        txtBlock.Text = "lin**";
                        break;
                    case "t":
                        txtBlock.Text = "lint*";
                        break;
                    case "u":
                        txtBlock.Text = "lintu";
                        MessageBox.Show("Voitit!");
                        break;
                }
            }
        }
    }
}
