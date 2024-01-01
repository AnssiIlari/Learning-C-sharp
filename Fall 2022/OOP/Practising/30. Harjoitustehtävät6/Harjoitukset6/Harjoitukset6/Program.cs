using System.Xml.Serialization;

namespace Harjoitukset6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Levyluokka");
            Console.WriteLine();

            Record record1= new Record();
            record1.SaveInfo();
            record1.PrintData();

            Record record2 = new Record();
            record2.SaveInfo();
            record2.PrintData();

            Record record3 = new Record();
            record3.SaveInfo();
            record3.PrintData();

            List<Record> list= new List<Record>();

            record1.AddToList(list);
            record2.AddToList(list);
            record3.AddToList(list);

            //list.Add(record1); // Vaihtoehtoisesti
            //list.Add(record2);
            //list.Add(record3);

            record3.PrintAllData(list); // Tulostaa kokoelman


        }
    }
    /// <summary>
    /// Record luokka
    /// </summary>
    public class Record
    {
        public string Artist { get; set; } // Artistin nimi
        public string RecordName { get; set; } // Levyn nimi
        public int Published { get; set; } // Julkaisuvuosi

        /// <summary>
        /// Metodi joka kysyy käyttäjältä levyn tiedot ja tallentaa vastaukset ominaisuuksiksi
        /// </summary>
        public void SaveInfo()
        {
            Console.WriteLine("Anna artistin nimi: ");
            Artist = Console.ReadLine();
            Console.WriteLine("Anna albumin nimi: ");
            RecordName = Console.ReadLine();
            Console.WriteLine("Anna julkaisuvuosi: ");
            Published = int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// Metodi joka tulostaa levyn tiedot. 
        /// Vaihtoehtoisesti olisi voinut toteuttaa ylikirjoittamalla ToString
        /// </summary>
        public void PrintData()
        {
            Console.WriteLine("Artistin nimi: " + Artist);
            Console.WriteLine("Albumin nimi: " + RecordName);
            Console.WriteLine("Julkaisuvuosi: " + Published);
        }
        /// <summary>
        /// Metodi joka lisää ilmentymän listalle
        /// </summary>
        /// <param name="name"></param>
        public void AddToList(List<Record> name)
        {
            name.Add(this);
        }

        /// <summary>
        /// Metodi joka poistaa ilmentymän listalta
        /// </summary>
        /// <param name="name"></param>
        public void RemoveFromList(List<Record> name)
        {
            name.Remove(this);
        }

        /// <summary>
        /// Ylikirjoitettu ToString
        /// </summary>
        /// <returns> Palauttaa levyn tiedot </returns>
        public override string ToString()
        {
            return $"Artisti: {Artist} Levyn nimi: {RecordName} Julkaistu: {Published}";
        }

        /// <summary>
        /// Metodi joka tulostaa kokoelman
        /// </summary>
        /// <param name="name"></param>
        public void PrintAllData(List<Record> name)
        {
            foreach (var item in name)
            {
                string text = item.ToString();
                Console.WriteLine(text);
            }
        }
        


    }
}