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

namespace PizzaApp
{
    /// <summary>
    /// Interaction logic for AddNewPizza.xaml
    /// </summary>
    public partial class AddNewPizza : Window
    {
        //private Pizza p = new Pizza();
        // katso myös --- var pizza = this.DataContext as Pizza;
        public AddNewPizza()
        {
            InitializeComponent();

            this.DataContext = new Pizza();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pizza = (Pizza)this.DataContext;

            var repo = new PizzaRepository();

            repo.AddPizza(pizza);

            DialogResult= true; // sulkee automaattisesti käyttöliittymän jos aukaisee käyttäliittymän dialogin???
        }
    }
}
