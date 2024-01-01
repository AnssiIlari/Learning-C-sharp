namespace ShakkiPeli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shakki sovellus");

            var Pelaaja1 = new Pelaaja("Anssi");
            Pelaaja1.Pelinappulat = PeliNappula.LuoPeliNappulat(true);

            var Pelaaja2 = new Pelaaja("Pertti");
            Pelaaja2.Pelinappulat = PeliNappula.LuoPeliNappulat(false);

            Pelilauta lauta = new Pelilauta();
            lauta.Pelaaja1 = Pelaaja1;
            lauta.Pelaaja2 = Pelaaja2;

            lauta.TulostaTiedot();
        }

    }

    public class Pelaaja
    {
        public string Nimi { get; set; }
        public PeliNappula[] Pelinappulat { get; set; } 

        public Pelaaja()
        {

        }

        public Pelaaja(string nimi)
        {
            Nimi = nimi;
        }
    }

    public class PeliNappula
    {
        public enum Nappulantyyppi
        {
            Sotilas,
            Torni,
            Ratsu,
            Lahetti,
            Kuningatar,
            Kuningas
        }
        public PeliNappula(Nappulantyyppi tyyppi, bool onkoMusta)
        {
            Tyyppi = tyyppi;
            OnkoMusta = onkoMusta;
        }

        public Nappulantyyppi Tyyppi { get; set; }
        public bool OnkoMusta { get; set; }
        public bool OnkoSyoty { get; set; }

        public static PeliNappula[] LuoPeliNappulat(bool mustatNappulat)
        {
            var nappulat = new PeliNappula[16];

            nappulat[0] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);
            nappulat[1] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);
            nappulat[2] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);
            nappulat[3] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);
            nappulat[4] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);
            nappulat[5] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);
            nappulat[6] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);
            nappulat[7] = new PeliNappula(Nappulantyyppi.Sotilas, mustatNappulat);

            nappulat[8] = new PeliNappula(Nappulantyyppi.Torni, mustatNappulat);
            nappulat[9] = new PeliNappula(Nappulantyyppi.Torni, mustatNappulat);

            nappulat[10] = new PeliNappula(Nappulantyyppi.Ratsu, mustatNappulat);
            nappulat[11] = new PeliNappula(Nappulantyyppi.Ratsu, mustatNappulat);

            nappulat[12] = new PeliNappula(Nappulantyyppi.Lahetti, mustatNappulat);
            nappulat[13] = new PeliNappula(Nappulantyyppi.Lahetti, mustatNappulat);

            nappulat[14] = new PeliNappula(Nappulantyyppi.Kuningatar, mustatNappulat);
            nappulat[15] = new PeliNappula(Nappulantyyppi.Kuningas, mustatNappulat);

            return nappulat;
        }

    }
    public class Pelilauta
    {
        private DateTime pelinaloitus = DateTime.Now;
        public Pelaaja Pelaaja1 { get; set; }
        public Pelaaja Pelaaja2 { get; set; }

        public string HaeVoittajanNimi()
        {
            return "Ei tiedossa";
        }

        public void TulostaTiedot()
        {
            Console.WriteLine("Peli aloitettu: {0}", pelinaloitus.ToString());
            Console.WriteLine("Pelaaja1 : " + Pelaaja1.Nimi);

            Console.WriteLine("Pelaajan nappulat: ");

            foreach (var peliNappula in Pelaaja1.Pelinappulat)
            {
                Console.WriteLine(peliNappula.Tyyppi);
            }


            Console.WriteLine();


            Console.WriteLine("Pelaaja2 : " + Pelaaja2.Nimi);

            Console.WriteLine("Pelaajan nappulat: ");

            foreach (var peliNappula in Pelaaja2.Pelinappulat)
            {
                Console.WriteLine(peliNappula.Tyyppi);
            }
        }



    }
}