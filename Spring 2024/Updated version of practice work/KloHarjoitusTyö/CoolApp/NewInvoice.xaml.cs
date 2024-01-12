using MySqlConnector;
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
using System.Windows.Shapes;

namespace CoolApp
{
    public partial class NewInvoice : Window

    {
        private ObservableCollection<InvoiceLine> invoiceLines;

        private string? local = Environment.GetEnvironmentVariable("KLOSQL");
        private string? localWithDb = Environment.GetEnvironmentVariable("KLOSQLWithDB");

        public NewInvoice()
        {
            InitializeComponent();


            var newInvoice = new Invoice // Creating new invoice
            {
                InvoiceID = 0,
                Date = DateTime.Today,
                InvoiceeName = "",
                InvoiceeAddress = "",
            };

            Repository repo = new Repository();
            repo.SaveInvoice(newInvoice); // save

            newInvoice.InvoiceID = repo.GetLastInvoiceId(); // Gets next id

            this.DataContext = newInvoice;
            comProductColumn.ItemsSource = repo.GetProducts();

            invoiceLines = new ObservableCollection<InvoiceLine>();
        }

        /// <summary>
        /// Saves the invoice to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoice(object sender, RoutedEventArgs e)
        {


            var invoice = (Invoice)this.DataContext;
            invoice.AdditionalInfo = additionalInfo.Text;

            Repository repo = new Repository();
            repo.SaveNewInvoice(invoice);

            int invoiceID = 0;

            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                invoiceID = Convert.ToInt32(cmd.ExecuteScalar());

                foreach (var line in invoiceLines)
                {
                    line.InvoiceID = invoiceID;
                    repo.SaveInvoiceLine(line, invoiceID);
                }
            }
            this.Close();

        }

    }

}
