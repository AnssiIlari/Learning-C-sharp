﻿using System;
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
    public partial class AllInvoices : Window
    {

        public ObservableCollection<Invoice> Invoices { get; set; } // List of invoices

        public AllInvoices()
        {
            InitializeComponent();
            Repository repo = new Repository();
            Invoices = repo.GetInvoices(); // Gets invoices from database
            foreach (var invoice in Invoices) // Gets total for each invoice
            {
                invoice.Total = repo.GetTotalFromDatabase(invoice.InvoiceID);
            }
            DataContext = this;
        }
    }
}