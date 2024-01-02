namespace Harjoitustyö
{
    // Osapuoli- luokka
    public class Osapuoli
    {
        public string Nimi { get; set; }
        public string Osoite { get; set; }
        public string Postinumero { get; set; }
        public string Kaupunki { get; set; }
        
        /// <summary>
        /// Ylikirjoittettu ToString- metodi
        /// </summary>
        /// <returns> Palauttaa Nimen, osoitteen, postinumberon ja kaunpungin string muodossa </returns>
        public override string ToString()
        {
            return $"{Nimi}\n{Osoite}\n{Postinumero} {Kaupunki}\n";
        }

    }
}