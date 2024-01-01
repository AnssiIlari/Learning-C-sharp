using System.Diagnostics;

namespace Orkki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Örkkisovellus");
            Console.WriteLine();

            Mordor mordor = new Mordor();

            Console.WriteLine(mordor.ToString());

            mordor.PrintOrcInfo();

            mordor.TheRingIsDestroyed();


        }
    }
    /// <summary>
    /// Orc luokka
    /// </summary>
    public class Orc
    {
        public int Number { get; set; }

        /// <summary>
        /// Ylikirjoitettu ToString- metodi
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Örkki numero: {Number}";
        }
    }
    /// <summary>
    /// Mordor luokka
    /// </summary>
    public class Mordor
    {
        public List<Orc> Orcs { get; set; } // Lista joka koostuu Orc- ilmentymistä

        public Mordor()
        {
            // rand ilmentymä
            Random rand = new Random();
            int random = rand.Next(0, 1001); // arvotaan luku väliltä 0-1000

            List<Orc> orcs = new List<Orc>(); // orcs lista

            // luodaan ilmentymä, annetaan juokseva numero ja lisätään listaan for-rakenteessa
            for (int i = 0; i < random; i++)
            {
                Orc orc = new Orc();
                orc.Number = i + 1;
                orcs.Add(orc);
            }

            Orcs = orcs;
        }
        /// <summary>
        /// Ylikirjoitettu ToString
        /// </summary>
        /// <returns> Palauttaa örkkien määrän </returns>
        public override string ToString()
        {
            return $"Örkkejä Mordorissa: {Orcs.Count}";
        }
        /// <summary>
        /// PrintOrcInfo palauttaa jokaisen listalla olevan ilmentymän ToString- metodin
        /// </summary>
        public void PrintOrcInfo()
        {
            foreach (var item in Orcs)
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// Tyhjentää listan
        /// </summary>
        public void TheRingIsDestroyed()
        {
            Orcs.Clear();
        }
    }
}