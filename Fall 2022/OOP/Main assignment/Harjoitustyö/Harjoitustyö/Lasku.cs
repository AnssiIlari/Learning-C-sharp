
namespace Harjoitustyö
{
    /// <summary>
    /// Lasku- luokka
    /// </summary>
    public class Lasku
    {
        public Laskuttaja Laskuttaja { get; set; }
        public Laskutettava Laskutettava { get; set; }
        public DateTime Paivays { get; set; }
        public DateTime Erapaiva { get; set; }
        public List<Laskurivi> Laskurivit { get; set; }

        public static int Numero = 1; // Yksilöinti
        public int numero;
        public string Lisatiedot { get; set; }


        /// <summary>
        /// Parametriton konstruktori, saa Paivays ja Erapaiva arvot luontihetkellä
        /// Luodaan myös laskurivit lista
        /// </summary>
        public Lasku()
        {
            Paivays = DateTime.Now; // Luodaan päiväys luontihetkellä
            Erapaiva = DateTime.Now.AddDays(14); // Eräpäivälle luontihetki + 14vrk
            List<Laskurivi> laskurivit = new List<Laskurivi>();
            Laskurivit = laskurivit;

            this.numero = Numero; // Yksilöinti
            Numero++;

        }
        /// <summary>
        /// Parametrillinen konstruktori, kutsutaan parametritonta konstruktoria,
        /// lisänä annetaan Lisatiedot ominaisuudella parametrina tullut arvo
        /// </summary>
        /// <param name="lisatiedot"></param>
        public Lasku(string lisatiedot) : this()
        {
            Lisatiedot = lisatiedot;
        }


        /// <summary>
        /// Ylikirjoitettu ToString- metodi
        /// </summary>
        /// <returns> Palauttaa laskun tietoja string muodossa </returns>
        public override string ToString() // ALKU
        {
            return $"Päiväys: {Paivays.ToString()}\nLaskun numero: {numero.ToString()}\nEräpäivä: {Erapaiva.ToString()}" +
                $"\nLisätiedot: {Lisatiedot}\n";
        }
        /// <summary>
        /// LisaaLaskulle- metodi, lisää tuotteen laskurivi Laskurivi- luokan ilmentymänä listalle
        /// </summary>
        /// <param name="tuote"></param>
        /// <param name="maara"></param>
        public void LisaaLaskulle(Tuote tuote, int maara)
        {
            Laskurivi laskurivi = new Laskurivi(tuote, maara);
            Laskurivit.Add(laskurivi);
        }

        /// <summary>
        /// Haku- metodi, etsii tuotetta laskuriveiltä
        /// </summary>
        /// <param name="tuote"></param>
        /// <returns> Palauttaa True jos parametri löytyi laskuriveiltä, muutoin False </returns>
        public bool Haku(Tuote tuote)
        {
            foreach (var item in Laskurivit)
            {
                if (item.Kuvaus == tuote.Kuvaus)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// TuoLasku- metodi
        /// </summary>
        /// <returns> Palauttaa laskun tiedot kokonaisuudessa string muodossa </returns>
        public string TuoLasku()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode; // Jotta saadaan euron merkki

            // Käydään Laskurivit lista läpi ja tallennetaan ToStringit ja Yhteensä ominaisuudet omiin muuttujiinsa
            string lista = string.Empty;
            double yhteensa = 0;
            foreach (var item in Laskurivit)
            {
                lista = lista + item.ToString() + "\n";
                yhteensa = yhteensa + item.Yhteensa;
            }
            yhteensa = Math.Round(yhteensa, 2); // Pyöristetään yhteensa- muuttuja

            return
                "LASKU" + "\n\n" + ToString() + "\n" + "Laskuttaja:" + "\n" + Laskuttaja.ToString() + "\n" + "Asiakas:" + "\n"
                + Laskutettava.ToString() + "\n\n" + "Tuote\t\tMäärä\t\tYksikkö\t\tHinta\t\tYhteensä" + "\n\n" + lista
                + "\t\t\t\t\t\tYHTEENSÄ\t" + yhteensa + " €\n";
        }
    }
}