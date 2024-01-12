﻿using System;
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

namespace CoolApp
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


            invoice.Total = repo.GetTotalFromDatabase(invoice.InvoiceID); // Get total from database

            this.DataContext = invoice;

        }

        /// <summary>
        /// Saves the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save(object sender, RoutedEventArgs e)
        {
            var invoice = (Invoice)this.DataContext;
            invoice.AdditionalInfo = additionalInfo.Text;

            Repository repo = new Repository();


            repo.SaveInvoice(invoice);

        }

        /// <summary>
        /// Deletes the line from the invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteLine_Click(object sender, RoutedEventArgs e) // Works without save, WIP!
        {
            var button = (Button)sender;
            var invoiceLine = (InvoiceLine)button.DataContext;

            var invoice = (Invoice)DataContext;
            invoice.InvoiceLines.Remove(invoiceLine);


            Repository repo = new Repository();
            repo.DeleteInvoiceLine(invoiceLine);
        }

        /// <summary>
        /// Deletes the invoice + warnings
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
