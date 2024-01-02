
namespace Harjoitustyö
{
    // Laskurivi luokka, perii Tuote- luokan
    public class Laskurivi: Tuote
    {
        public double Maara { get; set; }
        public double Yhteensa { get; set; }

        /// <summary>
        /// Konstruktori jossa saa parametrina tuotteen ja maaran.
        /// Tuotteelta kopioidaan ominaisuudet ja Maara tulee parametrina
        /// </summary>
        /// <param name="tuote"></param>
        /// <param name="maara"></param>
        public Laskurivi(Tuote tuote, int maara)
        {
            Maara= maara;
            Yhteensa = tuote.Hinta * Maara;
            Kuvaus = tuote.Kuvaus;
            Hinta= tuote.Hinta;
            Yksikkö = tuote.Yksikkö;
        }

        /// <summary>
        /// Ylikirjoitettu ToString- metodi
        /// </summary>
        /// <returns> Palauttaa laskurin tiedot string muodossa </returns>
        public override string ToString()
        {
            return $"{Kuvaus}\t\t{Maara}\t\t{Yksikkö}\t\t{Hinta}\t\t{Yhteensa:F1}";
        }


    }
}