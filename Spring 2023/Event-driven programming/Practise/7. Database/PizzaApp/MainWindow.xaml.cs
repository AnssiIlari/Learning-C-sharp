//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml.Serialization;

namespace PizzaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PizzaRepository repo;

        public MainWindow()
        {
            InitializeComponent();

            repo = new PizzaRepository();
            repo.CreatePizzaDb();
            repo.CreatePizzaTable();
            repo.AddDefaultPizzas();

            comPizzas.ItemsSource = repo.GetPizzas();
        }

        private void AddPizza(object sender, RoutedEventArgs e)
        {
            AddNewPizza addNew = new AddNewPizza();

            //addNew.Show();
            var returnValue = addNew.ShowDialog();

            if (returnValue == true)
            {
                comPizzas.ItemsSource = repo.GetPizzas();
            }

        }

        private void UpdateSelected(object sender, RoutedEventArgs e)
        {
            var pizza = (Pizza)comPizzas.SelectedValue;

            if (pizza != null)
            {
                UpdatePizza updatePizza = new UpdatePizza(pizza);
                var returnValue = updatePizza.ShowDialog();

                if (returnValue == true)
                {
                    comPizzas.ItemsSource = repo.GetPizzas();
                }
            }
        }

        private void RemoveSelectedPizza(object sender, RoutedEventArgs e)
        {

            var pizza = (Pizza)comPizzas.SelectedValue;

            if (pizza != null)
            {
                var result = MessageBox.Show("Haluatko varmasti poistaa valitun pizzan?", "Varoitus", MessageBoxButton.YesNo, MessageBoxImage.Question); // Myös otsikko parametrina, sekä nappulat

                if (result == MessageBoxResult.Yes)
                {
                    repo.RemovePizza(pizza);
                    comPizzas.ItemsSource = repo.GetPizzas();
                }
            }
        }
    }
}
