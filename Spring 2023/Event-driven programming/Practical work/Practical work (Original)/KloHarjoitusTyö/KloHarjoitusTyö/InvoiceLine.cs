using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KloHarjoitusTyö
{
    /// <summary>
    /// InvoiceLine luokka
    /// </summary>
    public class InvoiceLine
    {
        public int InvoiceLineID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }



    }
}
