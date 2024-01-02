namespace Harjoitustyö
{
    /// <summary>
    /// AsiakasrakennusOy- luokka
    /// </summary>
    public class Laskuttaja: Osapuoli
    {

        // Ilmentymä saa konstruktorissa ominaisuudet ja luodaan List- kaikkilaskut
        public Laskuttaja()
        {
            Nimi = "Rakennus Oy";
            Osoite = "Perätie 707";
            Postinumero = "80200";
            Kaupunki = "Joensuu";
        }
    }
}