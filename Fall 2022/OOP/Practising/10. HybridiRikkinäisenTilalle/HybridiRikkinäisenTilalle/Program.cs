namespace HybridiAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Matkakustannussovellus");

            // Luodaan uusi ilmentymä Auto- luokasta
            var hybridi = new Auto();

            // Annetaan arvot propertyille
            hybridi.PolttoaineenHinta = 2.1;
            hybridi.Sähkönhinta = 13;
            hybridi.AjetutKilometrit = 954;
            hybridi.BensiininKulutus = 4.2;

            // Kutsutaan Kokonaishinta metodia
            hybridi.KokonaisHinta();

        }
    }
    /// <summary>
    /// Auto- luokka
    /// </summary>
    public class Auto
    {
        public double PolttoaineenHinta { get; set; }
        public double Sähkönhinta { get; set; }
        public double AjetutKilometrit { get; set; }
        public double BensiininKulutus { get; set; }

        public Auto() // Annetaan konstruktorissa 2 arvoa, nämä voidaan muuttaa mainissa tarvittaessa"
        {
            PolttoaineenHinta = 2.1;
            Sähkönhinta = 13;
        }

        // Muuttujia
        double sähkölleHinta;
        double kilometrejaBensalla;
        double bensalleHinta;
        double bensalleHintaPerKm;
        double kokonaisHinta;
        double täydenAkunHinta;

        /// <summary>
        /// Metodi joka laskee matkan kustannukset euroina ja tulostaa vastauksen
        /// </summary>
        public void KokonaisHinta()
        {
            täydenAkunHinta = 14 * Sähkönhinta;
            bensalleHintaPerKm = (BensiininKulutus / 100) * (PolttoaineenHinta * 100); // * 100 että saadaan senteissä

            if (AjetutKilometrit <= 0) // Jos autolla ei olekaan ajettu...
            {
                Console.WriteLine("Autolla ei ole ajettu");
            }
            if (AjetutKilometrit <= 55) // Kustannukset vain sähköä
            {

                sähkölleHinta = ((14.0 / 55.0) * AjetutKilometrit) * Sähkönhinta / 100;
                Console.WriteLine("Matkan hinta: {0:f2} euroa ", sähkölleHinta);
            }
            else // Kustannukset maksimi sähkönmäärä + bensasta aiheutuneet kustannukset
            {
                kilometrejaBensalla = AjetutKilometrit - 55;
                bensalleHinta = kilometrejaBensalla * bensalleHintaPerKm;

                kokonaisHinta = (bensalleHinta + täydenAkunHinta) / 100;

                Console.WriteLine("Matkan hinta: {0:f2} euroa", kokonaisHinta);


            }
        }

    }
}