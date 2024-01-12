using Microsoft.VisualBasic;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloHarjoitusTyö
{

    /// <summary>
    /// Invoice luokka
    /// </summary>
    public class Invoice
    {
        private const string local = @"Server=127.0.0.1; Port=3306; User ID=opiskelija; Pwd=opiskelija1;";
        private const string localWithDb = @"Server=127.0.0.1; Port=3306; User ID=opiskelija; Pwd=opiskelija1; Database=Orders;";

        public ObservableCollection<InvoiceLine> InvoiceLines { get; set; }

        public int InvoiceID { get; set; } // PK

        public string InvoicerName { get; set; }
        public string InvoicerAddress { get; set; }
        public string InvoiceeName { get; set; }
        public string InvoiceeAddress { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public string Lisatiedot { get; set; } // TÄmä vielä suomeksi, ei ollutkaan helppo muuttaa
        public int Total { get; set; }





        /// <summary>
        /// Parametriton konstruktori, saa arvot luontihetkellä
        /// Luodaan myös laskurivit lista
        /// </summary>
        public Invoice()
        {
            InvoiceLines = new ObservableCollection<InvoiceLine>();
            Date = DateTime.Now; // Luodaan päiväys luontihetkellä
            DueDate = DateTime.Now.AddDays(14); // Eräpäivälle luontihetki + 14vrk
            InvoicerName = "Rakennus Oy";
            InvoicerAddress = "Osoite 123, 00100 Helsinki";
        }


    }
}
