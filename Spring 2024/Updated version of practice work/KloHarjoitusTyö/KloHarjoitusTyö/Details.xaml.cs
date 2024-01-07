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

namespace KloHarjoitusTyö
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {


        public Details(Invoice invoice)
        {
            InitializeComponent();


            Repository repo = new Repository();


            comProductColumn.ItemsSource = repo.GetProducts();


            invoice.Total = repo.GetTotalFromDatabase(invoice.InvoiceID); // Haetaan laskun summa tietokannasta

            this.DataContext = invoice;

        }

        /// <summary>
        /// Tallentaa muutokset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save(object sender, RoutedEventArgs e)
        {
            var invoice = (Invoice)this.DataContext;
            invoice.Lisatiedot = additionalInfo.Text;

            Repository repo = new Repository();


            repo.SaveInvoice(invoice);

        }

        /// <summary>
        /// Poistaa tuoterivin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteLine_Click(object sender, RoutedEventArgs e) // Toimii ilman Savea, en saanut toimimaan sen kanssa.
        {
            var button = (Button)sender;
            var invoiceLine = (InvoiceLine)button.DataContext;

            var invoice = (Invoice)DataContext;
            invoice.InvoiceLines.Remove(invoiceLine);


            Repository repo = new Repository();
            repo.DeleteInvoiceLine(invoiceLine);
        }

        /// <summary>
        /// Poistaa laskun + varoitukset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceButton_click(object sender, RoutedEventArgs e)
        {
            var invoice = (Invoice)this.DataContext;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this invoice?", "Delete Invoice", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Repository repo = new Repository();
                repo.DeleteInvoice(invoice);
                this.Close();
            }
        }

    }
}
