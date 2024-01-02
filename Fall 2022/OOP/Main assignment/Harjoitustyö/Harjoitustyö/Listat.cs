namespace Harjoitustyö
{

    /// <summary>
    /// Listat- luokka
    /// </summary>
    public class Listat
    {
        // Tarvittavat listat ominaisuuksina
        public List<Lasku> Laskulista { get; set; }
        public List<Laskutettava> Laskutettava { get; set; }
        public List<Tuote> Tuotelista { get; set; }


        /// <summary>
        /// Parametriton konstruktori, tehdään tarvittavat listat ilmentymän luontihetkellä
        /// </summary>
        public Listat()
        {
            List<Lasku> laskuLista = new List<Lasku>();
            List<Laskutettava> asiakasLista = new List<Laskutettava>();
            List<Tuote> tuoteLista = new List<Tuote>();

            Laskulista = laskuLista;
            Laskutettava = asiakasLista;
            Tuotelista = tuoteLista;
        }
        /// <summary>
        /// TulostaKaikkiLaskut metodi, kutsuu listan olioiden TuoLasku-metodia
        /// </summary>
        /// <returns> Palauttaa kaikki laskut string muodossa </returns>
        public string TulostaKaikkiLaskut()
        {
            string laskut = string.Empty;

            foreach (var item in Laskulista)
            {
                laskut = laskut + item.TuoLasku();
            }
            return laskut;
        }
        /// <summary>
        /// TulostaLasku- metodi, tunnistenumerohaku
        /// </summary>
        /// <param name="tunniste"></param>
        /// <returns> Palauttaa tunnistenumeroa vastaavan laskun tiedot string muodossa </returns>
        public string TulostaLasku(int tunniste)
        {
            string laskut = string.Empty;

            foreach (var item in Laskulista)
            {
                if (item.numero == tunniste)
                {
                    laskut = laskut + item.TuoLasku();
                }
            }
            if (laskut.Length <= 0)
            {
                return "Tunnisteella ei löytynyt laskua";
            }
            return laskut;
        }

        /// <summary>
        /// TulostaLasku-metodi, nimihaku
        /// </summary>
        /// <param name="nimi"></param>
        /// <returns> Palauttaa string muodossa tietyn asiakkaan laskut </returns>
        public string TulostaLasku(string nimi)
        {
            string laskut = string.Empty;
            foreach (var item in Laskulista)
            {
                if (item.Laskutettava.Nimi == nimi)
                {
                    laskut = laskut = item.TuoLasku();
                }
            }
            if (laskut.Length <= 0)
            {
                return "Ei listalla";
            }
            return laskut;
        }
        /// <summary>
        /// TulostaLasku- metodi, tuotehaku
        /// </summary>
        /// <param name="tuote"></param>
        /// <returns> Palauttaa string muodossa laskut, joissa on parametrina saatu tuote </returns>
        public string TulostaLasku(Tuote tuote)
        {
            string laskut = string.Empty;
            foreach (var item in Laskulista)
            {
                if (item.Haku(tuote))
                {
                    laskut = laskut + item.TuoLasku();
                }
            }
            return laskut;
        }
        /// <summary>
        /// TulostaTuotteet- metodi, kutsuu Tuotelistan olioiden ToString metodia
        /// </summary>
        /// <returns> Palauttaa tuotteet listattuna string muodossa </returns>
        public string TulostaTuotteet()
        {
            string tuotteet = string.Empty;
            foreach (var item in Tuotelista)
            {
                tuotteet = tuotteet + item.ToString();
            }
            return tuotteet;
        }
    }
}
