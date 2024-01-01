using System.Xml.Linq;
using System.Xml.Serialization;

namespace HarjoitusIIdentifiable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yksilöivä ominaisuus");
            Console.WriteLine("");

            /// Luodaan rajapinta- muotoinen 5 alkioinen taulukko
            IIdentifiable[] list = new IIdentifiable[5];

            // taulukon täyttäminen
            list[0] = new Invoice(1, "Paja Oy", 99.5);
            list[1] = new Invoice(2, "Karelia Oy", 25);
            list[2] = new Product("Vas1", "Vasara");
            list[3] = new Person(100, "Teppo Taputtaja");
            list[4] = new Person(101, "Sirpa Laputtaja");

            // Taulukon läpikäyminen foreachillä, haetaan yksilöivä arvo GetIdentifierValue metodilla
            foreach (var item in list)
            {
                Console.WriteLine("Yksilöivä arvo: " + item.GetIdentifierValue());
            }
        }
    }
    /// <summary>
    /// Rajapinta IIdentifiable
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// Metodi GetIdentifierValue
        /// </summary>
        /// <returns> Palauttaa string arvon </returns>
        public string GetIdentifierValue();
    }
    /// <summary>
    /// Invoice luokka, perii IIdentifiable- rajapinnan
    /// </summary>
    public class Invoice : IIdentifiable
    {
        public string CustomerName { get; set; }
        public int ID { get; set; } // Luokan yksilöivä ominaisuus
        public double Sum { get; set; }
        /// <summary>
        /// metodi GetIdentifierValue
        /// </summary>
        /// <returns> Palauttaa yksilöivän ominaisuuden string- muodossa </returns>
        public string GetIdentifierValue()
        {
            return ID.ToString();
        }
        /// <summary>
        /// Tyhjä konstruktori
        /// </summary>
        public Invoice()
        {
        }
        /// <summary>
        /// Konstruktori jossa voi antaa tarvittavat parametrit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerName"></param>
        /// <param name="sum"></param>
        public Invoice(int id, string customerName, double sum)
        {
            ID = id;
            Sum = sum;
            CustomerName = customerName;
        }
    }
    /// <summary>
    /// Person luokka, perii IIdentifiable- rajapinnan
    /// </summary>
    public class Person : IIdentifiable
    {
        public string Name { get; set; }
        public int Number { get; set; } // Luokan yksilöivä ominaisuus
        /// <summary>
        /// GetIdentifierValue metodi
        /// </summary>
        /// <returns> Palauttaa yksilöivän ominaisuuden string- muodossa </returns>
        public string GetIdentifierValue()
        {
            return Number.ToString();
        }
        /// <summary>
        /// Tyhjä konstruktori
        /// </summary>
        public Person()
        {
        }
        /// <summary>
        /// Konstruktori jossa voi antaa tarvittavat parametrit
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public Person(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }
    /// <summary>
    /// Product luokka, perii IIdentifiable- rajapinnan
    /// </summary>
    public class Product : IIdentifiable
    {
        public string Code { get; set; } // Luokan yksilöivä ominaisuus
        public string Description { get; set; }

        /// <summary>
        /// GetIdentifierValue metodi
        /// </summary>
        /// <returns> Palauttaa luokan yksilöivän ominaisuuden string- muodossa </returns>
        public string GetIdentifierValue()
        {
            return Code;
        }
        /// <summary>
        /// Tyhjä konstruktori
        /// </summary>
        public Product()
        {
        }
        /// <summary>
        /// Konstruktori jossa voi antaa tarvittavat parametrit
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        public Product(string code, string description)
        {
            Code= code;
            Description= description;
        }
    }



}