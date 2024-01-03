//using MySql.Data.MySqlClient;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace PizzaApp
{
    public class PizzaRepository
    {


        private string? local = Environment.GetEnvironmentVariable("PizzaAppConnectionString");
        private string? localWithDb = Environment.GetEnvironmentVariable("PizzaAppConnectionStringWithDB");

       
        public PizzaRepository()
        {
            if (local == null || localWithDb == null)
            {
                throw new Exception("Environment variable PizzaAppConnectionString or PizzaAppConnectionStringWithDB is null");
            }
        }

        public void CreatePizzaDb()
        {
            using (MySqlConnection conn = new MySqlConnection(local))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DROP DATABASE IF EXISTS PizzaDb", conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE DATABASE PizzaDb", conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreatePizzaTable()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string createTable = "CREATE TABLE Pizzas (number INT NOT NULL PRIMARY KEY, " + // + merkkijonon katenointia, kahdelle riville....
                                                            "name VARCHAR(50))";

                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddDefaultPizzas()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                string pizza1 = "INSERT INTO Pizzas(number, name) VALUES(1, 'Opera Special')";
                string pizza2 = "INSERT INTO Pizzas(number, name) VALUES(2, 'Margerita')";
                string pizza3 = "INSERT INTO Pizzas(number, name) VALUES(3, 'Quattro Stagioni')";
                string pizza4 = "INSERT INTO Pizzas(number, name) VALUES(4, 'Frutti di mare')";
                string pizza5 = "INSERT INTO Pizzas(number, name) VALUES(5, 'Karelia Speciale')";

                MySqlCommand cmd = new MySqlCommand(pizza1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(pizza2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(pizza3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(pizza4, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(pizza5, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Pizza> GetPizzas()
        {
            var pizzas = new ObservableCollection<Pizza>();



            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM pizzas;", conn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Debug.WriteLine(dr.GetInt32("number")); // Debug, Output ikkunaan >
                    Debug.WriteLine(dr.GetString("name"));

                    pizzas.Add(new Pizza { Number= dr.GetInt32("number") , Name = dr.GetString("name") }); // ilman konstruktoriakin voi antaa parametreja...
                }
            }
            return pizzas;
        }

        public void AddPizza(Pizza pizza)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Pizzas(number, name) VALUES(@number, @name)", conn);

                cmd.Parameters.AddWithValue("@number", pizza.Number);  // SISÄISTÄ TÄMÄ, tietoturva ( luento aikaleima 13:32, siellä myös esimerkki miten ei saa tehdä)
                cmd.Parameters.AddWithValue("@name", pizza.Name);

                cmd.ExecuteNonQuery();

            }
        }

        public void UpdatePizza(Pizza pizza)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Pizzas SET name=@name WHERE number=@number", conn);

                cmd.Parameters.AddWithValue("@number", pizza.Number);
                cmd.Parameters.AddWithValue("@name", pizza.Name);

                cmd.ExecuteNonQuery();

            }
        }

        public void RemovePizza(Pizza pizza)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDb))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM Pizzas WHERE number=@number", conn);

                cmd.Parameters.AddWithValue("@number", pizza.Number);

                cmd.ExecuteNonQuery();

            }
        }


    }
}
