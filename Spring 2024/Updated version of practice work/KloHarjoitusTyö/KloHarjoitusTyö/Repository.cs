using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KloHarjoitusTyö
{
    public class Repository
    {

        private string? local = Environment.GetEnvironmentVariable("KLOSQL");
        private string? localWithDb = Environment.GetEnvironmentVariable("KLOSQLWithDB");

        /// <summary>
        /// Metodi tietokannan luomiseen
        /// </summary>
        public void CreateOrdersDb()
        {

            using (MySqlConnection conn = new MySqlConnection(local))
            {
                conn.Open();


                MySqlCommand cmd = new MySqlCommand("DROP DATABASE IF EXISTS Orders", conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE DATABASE Orders", conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Metodi products taulun luomiseen
        /// </summary>
        public void CreateProductsTable()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string createTable = "CREATE TABLE Products(ID INT NOT NULL PRIMARY KEY," +
                    " Description VARCHAR(50)," +
                    " Price INT(10), Unit VARCHAR(50), Discontinued TINYINT(1) NOT NULL DEFAULT 0);"; // Lis'tty Discontinued ->

                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Metodi Invoice taulun luomiseen
        /// </summary>
        public void CreateInvoiceTable()  // tarkasta 255
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string createTable = "CREATE TABLE Invoice(InvoiceID INT NOT NULL AUTO_INCREMENT," +
                    "InvoicerName VARCHAR(255) NOT NULL," +
                    "InvoicerAddress VARCHAR(255) NOT NULL," +
                    "InvoiceeName VARCHAR(255) NOT NULL," +
                    "InvoiceeAddress VARCHAR(255) NOT NULL," +
                    "Date DATETIME NOT NULL," +
                    "DueDate DATETIME NOT NULL," +
                    "Lisatiedot VARCHAR(255)," +
                    "PRIMARY KEY (InvoiceID))";

                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Metodi invoiceLine taulun luomiseen
        /// </summary>
        public void CreateInvoiceLineTable()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string createTable = "CREATE TABLE InvoiceLine(InvoiceLineID INT NOT NULL AUTO_INCREMENT," +
                    "InvoiceID INT NOT NULL," +
                    "ProductID INT NOT NULL," +
                    "Quantity INT," +
                    "PRIMARY KEY (InvoiceLineID)," +
                    "FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID)," +
                    "FOREIGN KEY (ProductID) REFERENCES Products(ID))";

                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Metodi oletustuotteiden lisäämiseen
        /// </summary>
        public void AddDefaultProducts()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string product1 = "INSERT INTO Products(ID, Description, Price, Unit) VALUES(1, 'Nut', 1, 'pcs')";
                string product2 = "INSERT INTO Products(ID, Description, Price, Unit) VALUES(2, 'Work in full hours', 50, 'h')";
                string product3 = "INSERT INTO Products(ID, Description, Price, Unit) VALUES(3, 'Hammer', 20, 'pcs')";
                string product4 = "INSERT INTO Products(ID, Description, Price, Unit) VALUES(4, 'Mirror', 10, 'pcs')";
                string product5 = "INSERT INTO Products(ID, Description, Price, Unit) VALUES(5, 'Tile', 2, 'm2')";

                MySqlCommand cmd = new MySqlCommand(product1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(product2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(product3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(product4, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(product5, conn);
                cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Metodi oletuslaskujen lisäämiseen
        /// </summary>
        public void AddDefaultInvoices()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string invoice1 = "INSERT INTO Invoice(InvoicerName, InvoicerAddress, InvoiceeName, InvoiceeAddress, Date, DueDate) VALUES('Rakennus Oy', 'Osoite 123, 00100 Helsinki', 'Janne', 'Osoitekuja 2', curdate(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";
                string invoice2 = "INSERT INTO Invoice(InvoicerName, InvoicerAddress, InvoiceeName, InvoiceeAddress, Date, DueDate) VALUES('Rakennus Oy', 'Osoite 123, 00100 Helsinki', 'Pekka', 'Ylätie 4', curdate(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";
                string invoice3 = "INSERT INTO Invoice(InvoicerName, InvoicerAddress, InvoiceeName, InvoiceeAddress, Date, DueDate) VALUES('Rakennus Oy', 'Osoite 123, 00100 Helsinki', 'IsoYhtiö', 'Telitie 6', curdate(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";
                string invoice4 = "INSERT INTO Invoice(InvoicerName, InvoicerAddress, InvoiceeName, InvoiceeAddress, Date, DueDate) VALUES('Rakennus Oy', 'Osoite 123, 00100 Helsinki', 'Kaisa', 'Tori 13', curdate(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";
                string invoice5 = "INSERT INTO Invoice(InvoicerName, InvoicerAddress, InvoiceeName, InvoiceeAddress, Date, DueDate) VALUES('Rakennus Oy', 'Osoite 123, 00100 Helsinki', 'Mirjami', 'Sillanalus 7', curdate(), DATE_ADD(CURDATE(), INTERVAL 14 DAY))";


                MySqlCommand cmd = new MySqlCommand(invoice1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoice2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoice3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoice4, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoice5, conn);
                cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Metodi oletuslaskurivien lisäämiseen
        /// </summary>
        public void AddDefaultInvoiceLines()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string InvoiceLine1 = "INSERT INTO InvoiceLine(InvoiceID, ProductID, Quantity) VALUES(1, 1, 2)";
                string InvoiceLine2 = "INSERT INTO InvoiceLine(InvoiceID, ProductID, Quantity) VALUES(1, 2, 2)";
                string InvoiceLine3 = "INSERT INTO InvoiceLine(InvoiceID, ProductID, Quantity) VALUES(2, 3, 2)";
                string InvoiceLine4 = "INSERT INTO InvoiceLine(InvoiceID, ProductID, Quantity) VALUES(2, 4, 2)";
                string InvoiceLine5 = "INSERT INTO InvoiceLine(InvoiceID, ProductID, Quantity) VALUES(3, 5, 2)";


                MySqlCommand cmd = new MySqlCommand(InvoiceLine1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(InvoiceLine2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(InvoiceLine3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(InvoiceLine4, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(InvoiceLine5, conn);
                cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Metodi tuotteiden hakuun tietokannasta
        /// </summary>
        /// <returns> Palauttaa Observablecollection tuotteista </returns>
        public ObservableCollection<Product> GetProducts()
        {
            var products = new ObservableCollection<Product>();

            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open(); // HUOM TÄMÄ HAKEE VAIN NE TUOTTEET JOTKA EIVÄT OLE DISCONTINUED

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM products WHERE Discontinued = 0", conn);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    products.Add(new Product
                    {
                        ID = dr.GetInt32("ID"),
                        Description = dr.GetString("description"),
                        Price = dr.GetInt32("price"),
                        Unit = dr.GetString("unit")
                    });
                }
            }

            return products;
        }

        /// <summary>
        /// Metodi laskujen hakuun tietokannasta
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Invoice> GetInvoices()
        {
            var invoices = new ObservableCollection<Invoice>();

            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Invoice", conn);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var newInvoice = new Invoice
                    {
                        InvoiceID = dr.GetInt32("InvoiceID"),
                        InvoiceeName = dr.GetString("InvoiceeName"),
                        InvoiceeAddress = dr.GetString("InvoiceeAddress"),
                        Date = dr.GetDateTime("Date"),
                        DueDate = dr.GetDateTime("DueDate"),
                        Lisatiedot = dr.IsDBNull(dr.GetOrdinal("Lisatiedot")) ? null : dr.GetString("Lisatiedot")
                    };

                    GetInvoiceLines(newInvoice);

                    invoices.Add(newInvoice);
                }
            }

            return invoices;
        }



        /// <summary>
        /// Metodi tuotteiden lisäämiseksi
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO products(ID, description, price, unit) VALUES(@ID, @description, @price, @unit)", conn);
                cmd.Parameters.AddWithValue("@ID", product.ID);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@unit", product.Unit);
                cmd.ExecuteNonQuery();

            }

        }
        /// <summary>
        /// Metodi tuotteiden päivittämiseksi
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE products SET ID=@ID, description = @description, price = @price, unit = @unit WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", product.ID);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@unit", product.Unit);
                cmd.ExecuteNonQuery();

            }

        }

        /// <summary>
        /// Metodi tuotteiden poistamiseksi, Muuttaa Distcontinued arvoa.
        /// </summary>
        /// <param name="product"></param>
        public void RemoveProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE Products SET Discontinued=1 WHERE ID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", product.ID);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Hakee laskurivit
        /// </summary>
        /// <param name="invoice"></param>
        public void GetInvoiceLines(Invoice invoice) // muutettu private > public
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM InvoiceLine WHERE InvoiceID=@id", conn);
                cmd.Parameters.AddWithValue("@id", invoice.InvoiceID);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    invoice.InvoiceLines.Add(new InvoiceLine
                    {
                        InvoiceLineID = dr.GetInt32("InvoiceLineID"),
                        InvoiceID = dr.GetInt32("InvoiceID"),
                        ProductID = dr.GetInt32("ProductID"),
                        Quantity = dr.GetInt32("Quantity")
                    });
                }
            }
        }


        /// <summary>
        /// Tallentaa laskurivin
        /// </summary>
        /// <param name="line"></param>
        /// <param name="invoiceID"></param>
        public void SaveInvoiceLine(InvoiceLine line, int invoiceID) // Kopioitu, HUOM, ymmärrä ja kommentoi
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO InvoiceLine (InvoiceID, ProductID, Quantity) VALUES (@invoiceID, @productID, @quantity)", conn);
                cmd.Parameters.AddWithValue("@invoiceID", invoiceID);
                cmd.Parameters.AddWithValue("@productID", line.ProductID);
                cmd.Parameters.AddWithValue("@quantity", line.Quantity);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Poistaa laskurivin
        /// </summary>
        /// <param name="line"></param>
        public void DeleteInvoiceLine(InvoiceLine line)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM InvoiceLine WHERE InvoiceLineID=@id", conn);
                cmd.Parameters.AddWithValue("@id", line.InvoiceLineID);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Hakee viimeisimmän laskun ID:n
        /// </summary>
        /// <returns>ID</returns>
        public int GetLastInvoiceId()
        {
            using MySqlConnection connection = new MySqlConnection(localWithDb);
            string query = "SELECT LAST_INSERT_ID();";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Tallentaa laskun
        /// </summary>
        /// <param name="invoice"></param>
        public void SaveInvoice(Invoice invoice)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Invoice SET InvoiceeName=@name, InvoiceeAddress=@address, Date=@date, DueDate=@dueDate, Lisatiedot=@lisatiedot WHERE InvoiceID=@id", conn);
                cmd.Parameters.AddWithValue("@id", invoice.InvoiceID);
                cmd.Parameters.AddWithValue("@name", invoice.InvoiceeName);
                cmd.Parameters.AddWithValue("@address", invoice.InvoiceeAddress);
                cmd.Parameters.AddWithValue("@date", invoice.Date);
                cmd.Parameters.AddWithValue("@dueDate", invoice.DueDate);
                cmd.Parameters.AddWithValue("@lisatiedot", invoice.Lisatiedot);

                cmd.ExecuteNonQuery();

                foreach (var line in invoice.InvoiceLines)
                {
                    if (line.InvoiceLineID == 0)
                    {
                        // INSERT

                        MySqlCommand cmdIns = new MySqlCommand("INSERT INTO InvoiceLine (InvoiceID, ProductID, Quantity)" +
                            "VALUES(@invoiceID, @productID, @quantity)", conn);

                        cmdIns.Parameters.AddWithValue("@invoiceID", invoice.InvoiceID);
                        cmdIns.Parameters.AddWithValue("@productID", line.ProductID);
                        cmdIns.Parameters.AddWithValue("@quantity", line.Quantity);
                        cmdIns.ExecuteNonQuery();
                    }
                    else
                    {
                        // UPDATE

                        MySqlCommand cmdUpd = new MySqlCommand("UPDATE InvoiceLine SET ProductID=@productID, Quantity=@quantity WHERE InvoiceLineID=@lineID", conn);

                        cmdUpd.Parameters.AddWithValue("@productID", line.ProductID);
                        cmdUpd.Parameters.AddWithValue("@quantity", line.Quantity);
                        cmdUpd.Parameters.AddWithValue("@lineID", line.InvoiceLineID);
                        cmdUpd.ExecuteNonQuery();
                    }
                }
            }
        }
        /// <summary>
        /// Tallentaa uuden laskun
        /// </summary>
        /// <param name="invoice"></param>
        public void SaveNewInvoice(Invoice invoice) 
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Invoice (InvoiceeName, InvoiceeAddress, InvoicerName, InvoicerAddress, Date, DueDate, Lisatiedot) VALUES (@name, @address, 'Rakennus Oy', 'Osoite 123, 00100 Helsinki', @date, @dueDate, @lisatiedot)", conn);
                cmd.Parameters.AddWithValue("@name", invoice.InvoiceeName);
                cmd.Parameters.AddWithValue("@address", invoice.InvoiceeAddress);
                cmd.Parameters.AddWithValue("@date", invoice.Date);
                cmd.Parameters.AddWithValue("@dueDate", invoice.DueDate);
                cmd.Parameters.AddWithValue("@lisatiedot", invoice.Lisatiedot);

                cmd.ExecuteNonQuery();

                // Get the auto-generated ID of the new invoice
                invoice.InvoiceID = (int)cmd.LastInsertedId;

                foreach (var line in invoice.InvoiceLines)
                {
                    // Set the InvoiceID property of the InvoiceLine to the ID of the new invoice
                    line.InvoiceID = invoice.InvoiceID;

                    // Save the invoice line
                    SaveInvoiceLine(line, invoice.InvoiceID);
                }

                
            }

        }


        /// <summary>
        /// Poistaa laskun
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteInvoice(Invoice invoice)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                // First delete the invoice lines associated with the invoice
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM InvoiceLine WHERE InvoiceID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", invoice.InvoiceID);
                    cmd.ExecuteNonQuery();
                }

                // Then delete the invoice itself
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM Invoice WHERE InvoiceID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", invoice.InvoiceID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Hakee totalin tietokannasta
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <returns>total</returns>
        public int GetTotalFromDatabase(int invoiceId) 
        {
            int total = 0;
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT SUM(Products.Price * InvoiceLine.Quantity) " +
                    "FROM Invoice " +
                    "INNER JOIN InvoiceLine ON Invoice.InvoiceID = InvoiceLine.InvoiceID " +
                    "INNER JOIN Products ON InvoiceLine.ProductID = Products.ID " +
                    "WHERE Invoice.InvoiceID = @InvoiceID", conn);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);

                var result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    total = Convert.ToInt32(result);
                }
            }

            return total;
        }


    }
}
