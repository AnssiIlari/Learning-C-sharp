namespace TenttiinValmistavaTehtävä
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tietokone");
            Console.WriteLine();
            Console.WriteLine("---------");

            List<Tietokone> tietokoneLista = new List<Tietokone>();


            Console.WriteLine("Valmistautumista tenttiin");
            // Kysytaan tietokoneen tiedot kayttajalta 
            Console.WriteLine("Anna tietokoneen merkki: ");
            string merkki = Console.ReadLine();
            Console.WriteLine("Anna tietokoneen malli: ");
            string malli = Console.ReadLine();
            Console.WriteLine("Anna tietokoneen hinta: ");
            double hinta = double.Parse(Console.ReadLine());
            Console.WriteLine("Anna arvio: ");
            string arvio = Console.ReadLine();

            // Eeron osa
            // Luodaan Tietokone-olio ja viedään sen attribuutien arvoksi käyttäjältä pyydetyt tiedot
            Tietokone kompuutteri1 = new Tietokone();
            kompuutteri1.Merkki = merkki;
            kompuutteri1.Malli = malli;
            kompuutteri1.Hinta = hinta;
            kompuutteri1.Arvio = arvio;
            Console.WriteLine(kompuutteri1.ToString());

            Tietokone kone2 = new Tietokone("HP", "ZBook", 1289.00, "Hyvä, nopea kone");

            Console.WriteLine(kone2.Arvio);

            Tietokone kone3 = new Tietokone("Lenovo", "ThinkPad X1", 1916.10, "Tehokas ja kevyt kannettava");

            TietokoneRekisteri rek = new TietokoneRekisteri();
            rek.Lisaa(kone2);
            rek.Lisaa(kone3);
            rek.Lisaa(kompuutteri1);
            rek.TulostaKaikki();
            Console.WriteLine("Loytyyko merkkia IBM? " + rek.Etsi("IBM"));
            // Löytyy, jos koneen merkiksi on syötetty IBM

            Console.WriteLine(kone2.CompareTo(kone3)); // -1
            Console.WriteLine(kompuutteri1.CompareTo(kone2)); // 

            // Eeron osa



        }
    }

    /// <summary>
    /// Icomparable rajapinta
    /// </summary>
    public interface IComparable
    {
        public int CompareTo(Tietokone other);
    }
    /// <summary>
    /// Tietokone- luokka, perii Icomparable rajapinnan
    /// </summary>
    public class Tietokone : IComparable
    {
        public string Merkki { get; set; }
        public string Malli { get; set; }
        public double Hinta { get; set; }
        public string Arvio { get; set; }

        // Tyhjä konstruktori
        public Tietokone()
        {

        }
        // Konstruktori neljällä parametrilla
        public Tietokone(string merkki, string malli, double hinta, string arvio)
        {
            Merkki = merkki;
            Malli = malli;
            Hinta = hinta;
            Arvio = arvio;
        }
        /// <summary>
        /// Ylikirjoitettu ToString
        /// </summary>
        /// <returns> Palauttaa stringinä Merkin, mallin, hinnan ja arvion </returns>
        public override string ToString()
        {
            return $"Merkki: {Merkki}\nMalli: {Malli}\nHinta: {Hinta}\nArvio: {Arvio}\n";

        }

        /// <summary>
        /// CompareTo- rajapinnan toteutus, vertaa ilmentymien Hinta ominaisuutta.
        /// </summary>
        /// <param name="other"></param>
        /// <returns> Palauttaa vertailun mukaisesti int arvon </returns>
        public int CompareTo(Tietokone? other)
        {
            if (other == null || Hinta > other.Hinta)
            {
                return 1;
            }
            else if (Hinta < other.Hinta)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// Tietokonerekisteri- luokka
    /// </summary>
    public class TietokoneRekisteri
    {
        private List<Tietokone> Lista { get; set; } // Ominaisuutena lista Tietokone tyyppisistä ilmentymistä
        private int koneLkm; // Laskuri, toimisi myös indeksinä jos Lista olisi taulukko

        // Alustetaan Lista konstruktorissa
        public TietokoneRekisteri()
        {
            List<Tietokone> tietokoneLista = new List<Tietokone>();
            Lista = tietokoneLista;
        }
        /// <summary>
        /// Lisaa- metodi lisää parametrina saadun ilmentymän listalle
        /// </summary>
        /// <param name="tietokone"></param>
        public void Lisaa(Tietokone tietokone)
        {
            Lista.Add(tietokone);
            koneLkm++;
        }
        /// <summary>
        /// TulostaKaikki- metodi käy läpi jokaisen ilmentymän ylikirjoitetun ToStringin
        /// </summary>
        public void TulostaKaikki()
        {
            foreach (var item in Lista)
            {
                Console.WriteLine(item.ToString());
            }
        }
        /// <summary>
        /// Etsi- metodi käy läpi ilmentymien Merkki ominaisuuden
        /// </summary>
        /// <param name="etsittava"></param>
        /// <returns> Palauttaa True jos etsittävien joukosta löytyy parametrina annettava haettava </returns>
        public bool Etsi(string etsittava)
        {
            foreach (var item in Lista)
            {
                if (item.Merkki.Contains(etsittava))
                {
                    return true;
                }
            }
            return false;
        }

    }
}