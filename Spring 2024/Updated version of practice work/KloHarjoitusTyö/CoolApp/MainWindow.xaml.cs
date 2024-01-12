using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CoolApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Repository repo; // vaihdettu repo, tarkasta

        public MainWindow()
        {
            InitializeComponent();

            repo = new Repository(); // uusi ilmentyä Repository luokasta
            repo.CreateOrdersDb(); // tehdään tietokanta
            repo.CreateProductsTable(); // tehdään products taulu
            repo.AddDefaultProducts(); // lisätään oletustuotteet

            repo.CreateInvoiceTable(); // tehdään invoice taulu
            repo.AddDefaultInvoices(); // lisätään oletuslaskut

            repo.CreateInvoiceLineTable(); // tehdään invoiceline taulu
            repo.AddDefaultInvoiceLines(); // lisätään oletuslaskurivit

            comProducts.ItemsSource = repo.GetProducts(); // haetaan tuotteet comboboxiin
            comInvoices.ItemsSource = repo.GetInvoices(); // haetaan laskut comboboxiin
        }
        /// <summary>
        /// Aukaisee ikkunan jossa voi lisätä uuden tuotteen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddProduct(object sender, RoutedEventArgs e)
        {
            AddNewProduct addNew = new AddNewProduct();
            var retunValue = addNew.ShowDialog();
            if (retunValue == true)
            {
                comProducts.ItemsSource = repo.GetProducts();
            }
        }
        /// <summary>
        /// Aukaisee ikkunan jossa voi päivittää valitun tuotteen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSelected(object sender, RoutedEventArgs e)
        {
            var product = (Product)comProducts.SelectedValue;

            if (product != null)
            {
                UpdateProduct updateProduct = new UpdateProduct(product);
                var returnValue = updateProduct.ShowDialog();

                if (returnValue == true)
                {
                    comProducts.ItemsSource = repo.GetProducts();
                }
            }
        }
        /// <summary>
        /// Poistaa valitun tuotteen + varoitukset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSelected(object sender, RoutedEventArgs e)
        {

            var product = (Product)comProducts.SelectedValue;

            if (product != null)
            {
                var result = MessageBox.Show("Do you really want to remove this product?", "Warning",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    repo.RemoveProduct(product);
                    comProducts.ItemsSource = repo.GetProducts();
                }
            }
        }
        /// <summary>
        /// Event handler, aukaisee ikkunan jossa näkyy kaikki tuotteet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllProducts(object sender, RoutedEventArgs e)
        {
            ShowAllProducts showAllProducts = new ShowAllProducts(repo.GetProducts());

            showAllProducts.ShowDialog();
        }

        /// <summary>
        /// Aukaisee ikkunan jossa näkyy yksittäisen laskun tiedot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailsAndUpdate(object sender, RoutedEventArgs e)
        {
            var detailsWindow = (Invoice)comInvoices.SelectedValue;
            Details details = new Details(detailsWindow);
            details.ShowDialog();
            comInvoices.ItemsSource = repo.GetInvoices(); // Lisäys
        }
        /// <summary>
        /// Aukaisee ikkunan jossa voi tehdä uuden laskun
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice(object sender, RoutedEventArgs e)
        {
            NewInvoice newInvoice = new NewInvoice();
            newInvoice.ShowDialog();
            comInvoices.ItemsSource = repo.GetInvoices();
        }
        
        /// <summary>
        /// Aukaisee ikkunan joka listaa kaikki laskut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListAllInvoices(object sender, RoutedEventArgs e)
        {
            AllInvoices allInvoices = new AllInvoices();
            allInvoices.ShowDialog();
        }

        /// <summary>
        /// Vaihtoo MainWindown taustavärin satunnaiseksi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeColorButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Color randomColor = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
            mainWindow.Background = new SolidColorBrush(randomColor);

        }
        
        /// <summary>
        /// Palauttaa MainWindown taustavärin alkuperäiseksi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriginalColor_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Background = Brushes.White;

        }


        

    }
}
