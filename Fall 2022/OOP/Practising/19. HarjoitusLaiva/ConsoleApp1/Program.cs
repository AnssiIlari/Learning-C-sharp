using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        // Valmis
        static void Main(string[] args)
        {
            Console.WriteLine("Laivaohjelma");

            // Ilmentymien tekoa
            var laiva = new Laiva("Laivanen", 1300);
            //Console.WriteLine(laiva.ToString());

            var risteilyalus = new Risteilyalus("Paatti", 1989, 5000);
            //Console.WriteLine(risteilyalus.ToString());

            var tankkeri = new Tankkeri("Rahtipaatti", 1000000);
            //Console.WriteLine(tankkeri.ToString());


            // Taulukko ilmentymistä
            Laiva[] laivat = new Laiva[3];

            laivat[0] = laiva;
            laivat[1] = risteilyalus;
            laivat[2] = tankkeri;

            // Taulukon läpikäynti foreach- metodilla ja ylikirjoitetulla ToString- metodilla
            foreach (var item in laivat)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
    /// <summary>
    ///  Laiva luokka
    /// </summary>
    public class Laiva
    {
        public string Nimi { get; set; }
        public int Rakennusvuosi { get; set; }

        /// <summary>
        /// Konstruktori kahdella parametrilla
        /// </summary>
        /// <param name="nimi"></param>
        /// <param name="rakennusvuosi"></param>
        public Laiva(string nimi, int rakennusvuosi)
        {
            Nimi = nimi;
            Rakennusvuosi = rakennusvuosi;
        }

        // Tyhjä konstruktori
        public Laiva()
        {

        }
        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns> Palauttaa laivan nimen ja rakennusvuoden </returns>
        public override string ToString()
        {
            return "Laivan nimi on " + Nimi + " ja sen rakennusvuosi on " + Rakennusvuosi;
        }
    }

    /// <summary>
    /// Risteilyalus luokka
    /// </summary>
    public class Risteilyalus : Laiva
    {
        public int Maksimimatkustajat { get; set; }

        /// <summary>
        /// Konstruktori kolmella parametrilla
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rakennusvuosi"></param>
        /// <param name="maksimimatkustajat"></param>
        public Risteilyalus(string name, int rakennusvuosi, int maksimimatkustajat)
        {
            Nimi = name;
            Rakennusvuosi = rakennusvuosi;
            Maksimimatkustajat = maksimimatkustajat;
        }

        /// <summary>
        /// ToString override
        /// </summary>
        /// <returns> palauttaa kantaluokan toString tulosteen + matkustajamäärä </returns>
        public override string ToString()
        {
            return base.ToString() + ". Maksimimatkustajat : " + Maksimimatkustajat;
        }
    }
    /// <summary>
    /// Tankkeri luokka
    /// </summary>
    public class Tankkeri : Laiva
    {
        public int Maksimilasti { get; set; }

        /// <summary>
        /// Konstruktori kahdella parametrilla
        /// </summary>
        /// <param name="nimi"></param>
        /// <param name="maksimilasti"></param>
        public Tankkeri(string nimi, int maksimilasti)
        {
            Nimi = nimi;
            Maksimilasti = maksimilasti;
        }

        public override string ToString()
        {
            return "Laivan nimi: " + Nimi + "\tMaksimilasti " + Maksimilasti;
        }
    }
}