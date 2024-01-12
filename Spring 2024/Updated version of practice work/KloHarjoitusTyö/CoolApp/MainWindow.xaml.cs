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
        public Repository repo;

        public MainWindow()
        {
            InitializeComponent();

            repo = new Repository();
            repo.CreateOrdersDb(); // Create database
            repo.CreateProductsTable(); // Create products table
            repo.AddDefaultProducts(); // Add default products

            repo.CreateInvoiceTable(); // Create invoice table
            repo.AddDefaultInvoices(); // Add default invoices

            repo.CreateInvoiceLineTable(); // Create invoice line table
            repo.AddDefaultInvoiceLines(); // Add default invoice lines

            comProducts.ItemsSource = repo.GetProducts(); // Get products to combobox
            comInvoices.ItemsSource = repo.GetInvoices(); // Get invoices to combobox
        }
        /// <summary>
        /// Opens a window where you can add a new product
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
        /// Opens a window where you can update a selected product
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
        /// Delete selected product + warnings
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
        /// Opens a window where you can see all products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllProducts(object sender, RoutedEventArgs e)
        {
            ShowAllProducts showAllProducts = new ShowAllProducts(repo.GetProducts());

            showAllProducts.ShowDialog();
        }

        /// <summary>
        /// Open a window where you can see details of a single invoice
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
        /// Opens a window where you can create a new invoice
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
        /// Opens a window where you can see all invoices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListAllInvoices(object sender, RoutedEventArgs e)
        {
            AllInvoices allInvoices = new AllInvoices();
            allInvoices.ShowDialog();
        }

        /// <summary>
        /// Change MainWindow background color to random
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
        /// Change MainWindow background color to original
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriginalColor_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Background = Brushes.White;

        }


        

    }
}
