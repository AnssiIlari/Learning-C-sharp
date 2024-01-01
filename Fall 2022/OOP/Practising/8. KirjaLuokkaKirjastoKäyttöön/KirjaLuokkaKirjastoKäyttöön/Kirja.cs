namespace KirjaLuokkaKirjastoKäyttöön
{
    internal class Program
    {
        // Valmis
        static void Main(string[] args)
        {

            var Ruamattu = new Kirja();

            Ruamattu.Tila = "Kateissa";

            Ruamattu.TulostaTila();

            Ruamattu.TallennaTiedot();

            Ruamattu.Print();

            Ruamattu.Print("&");

        }


    }

    /// <summary>
    /// Tehdään Kirja-luokka
    /// </summary>
    public class Kirja
    {
        // Alustetaan propertyt
        public string Tekijä { get; set; }
        public string KirjanNimi { get; set; }
        public string Genre { get; set; }
        public string Isbn { get; set; }
        public int Sivumäärä { get; set; }
        public string Tila { get; set; }

        public Kirja()
        {

        }
        // Konstruktori kahdella parametrilla
        public Kirja(string tekijä, string kirjannimi)
        {
            Tekijä = tekijä;
            KirjanNimi = kirjannimi;
        }
        // Konstruktori, kaikki propertyt parametrina, konstruktorin kuormitus
        public Kirja(string tekijä, string kirjannimi, string genre, string isbn, int sivumäärä, string tila) : this()
        {
            Genre = genre;
            Isbn = isbn;
            Sivumäärä = sivumäärä;
            Tila = tila;
        }
        /// <summary>
        /// Tulostaa tila- propertyn
        /// </summary>
        public void TulostaTila()
        {
            Console.WriteLine(Tila);
        }
        /// <summary>
        /// Kysyy ja tallentaa kaikki tiedot
        /// </summary>
        public void TallennaTiedot()
        {
            Console.WriteLine("Tekijä: ");
            Tekijä = Console.ReadLine();
            Console.WriteLine("Kirjan nimi: ");
            KirjanNimi = Console.ReadLine();
            Console.WriteLine("Genre: ");
            Genre = Console.ReadLine();
            Console.WriteLine("ISBN: ");
            Isbn = Console.ReadLine();
            Console.WriteLine("Sivumäärä: ");
            Sivumäärä = int.Parse(Console.ReadLine());
            Console.WriteLine("Tila: ");
            Tila = Console.ReadLine();
        }
        /// <summary>
        /// Metodi joka tulostaa tiedot
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Teoksen tiedot: ");
            Console.WriteLine();
            Console.WriteLine("Tekijä: {0}", Tekijä);
            Console.WriteLine("Teoksen nimi: {0}", KirjanNimi);
            Console.WriteLine("Genre: {0}", Genre);
            Console.WriteLine("ISBN: {0}", Isbn);
            Console.WriteLine("Sivuja: {0}", Sivumäärä);
            Console.WriteLine("Tila: {0}", Tila);
        }

        /// <summary>
        /// Metodi joka tulostaa ja tiedot + lisäksi erotinmerkit ///
        /// </summary>
        /// <param name="number"></param>
        public void Print(string character)
        {
            Print();

            for (int i = 0; i < 10; i++)
            {
                Console.Write(character);
            }

        }
    }
}