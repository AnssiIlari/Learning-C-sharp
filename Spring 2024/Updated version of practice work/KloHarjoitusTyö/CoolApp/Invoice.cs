using Microsoft.VisualBasic;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolApp
{

    /// <summary>
    /// Invoice class
    /// </summary>
    public class Invoice
    {
        public ObservableCollection<InvoiceLine> InvoiceLines { get; set; }

        public int InvoiceID { get; set; } // Primary key

        public string InvoicerName { get; set; }
        public string InvoicerAddress { get; set; }
        public string InvoiceeName { get; set; }
        public string InvoiceeAddress { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string AdditionalInfo { get; set; }
        public int Total { get; set; }





        /// <summary>
        /// Constructor
        /// Luodaan myös laskurivit lista
        /// </summary>
        public Invoice()
        {
            InvoiceLines = new ObservableCollection<InvoiceLine>();
            Date = DateTime.Now; // Created when invoice is created
            DueDate = DateTime.Now.AddDays(14); // // Set the DueDate to the current date plus 14 days
            InvoicerName = "Rakennus Oy";
            InvoicerAddress = "Osoite 123, 00100 Helsinki";
        }


    }
}
