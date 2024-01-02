namespace Harjoitustyö
{

    /// <summary>
    /// Tuote- luokka
    /// </summary>
    public class Tuote
    {
        public string Kuvaus { get; set; }
        public double Hinta { get; set; }
        public string Yksikkö { get; set; }

        /// <summary>
        /// Parametriton konstruktori
        /// </summary>
        public Tuote()
        {
        }

        /// <summary>
        /// Parametrillinen konstruktori, ilmentymä saa parametrit ominaisuuksien arvoiksi
        /// </summary>
        /// <param name="kuvaus"></param>
        /// <param name="hinta"></param>
        /// <param name="yksikkö"></param>
        public Tuote(string kuvaus, double hinta, string yksikkö)
        {
            Kuvaus = kuvaus;
            Hinta = hinta;
            Yksikkö = yksikkö;  
        }

        /// <summary>
        /// Ylikirjoitettu ToString- metodi
        /// </summary>
        /// <returns> Palauttaa tuotteen kuvauksen ja hinnan string muodossa </returns>
        public override string ToString()
        {
            return $"Kuvaus: {Kuvaus}\t\nHinta: {Hinta}\t\n\n";
        }

    }
}