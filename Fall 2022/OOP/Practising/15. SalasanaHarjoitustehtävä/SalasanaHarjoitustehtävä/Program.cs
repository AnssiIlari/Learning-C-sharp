using System.Globalization;

namespace SalasanaHarjoitustehtävä
{
    internal class Program
    {
        // VALMIS
        static void Main(string[] args)
        {


            // Salasanan kysely while-loopissa
            while (true)
            {
                string password = AskPassWord(); // Salasanan asettaminen muuttujaan
                var Password = new PassWordChecker(password); // uusi olio PassWordChecker luokasta
                bool valid = Password.IsValid(); // Salasanan testaus IsValid metodilla

                if (valid) // Poistutaan while-loopista jos salasana vastaa vaatimuksia
                {
                    Console.Clear();
                    Console.WriteLine("Salasana on nyt luotu");
                    break;
                }
            }


            /// Jätetty muistiin toinen tapa salasanan kysely loppille

            //bool valid;
            //do
            //{
            //    password = AskPassWord();
            //    var Password = new PassWordChecker(password);
            //    valid = Password.IsValid();
            //    if (valid)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Salasana on nyt luotu");
            //        valid = true;
            //    }
            //} while (valid == false);

        }
        /// <summary>
        /// Metodi salasanan kysymiselle
        /// </summary>
        /// <returns>Palauttaa salasanan string muuttujassa</returns>
        public static string AskPassWord()
        {
            
            Console.WriteLine("Salasanasovellus");
            Console.WriteLine("");
            Console.WriteLine("Salasanassa on oltava vähintään 10 merkkiä.");
            Console.WriteLine("Salasanassa on ainakin yksi iso kirjain ja yksi pieni kirjain.");
            Console.WriteLine("Salasanassa on ainakin yksi numero.");
            Console.WriteLine("");
            Console.WriteLine("Anna salasana: ");
            return Console.ReadLine();
        }
    }


    /// <summary>
    /// Salasanan tarkistus luokka
    /// </summary>
    public class PassWordChecker
    {
        public string Password { get; set; } // Salasana ominaisuus

        public PassWordChecker(string password) // Konstruktori, saa salasanan arvokseen
        {
            Password = password;
        }
        /// <summary>
        /// Metodi salasanan ehtojen tarkastamiseen, sisäkkäinen if-rakenne
        /// </summary>
        /// <returns> Palauttaa boolean tyyppisen muuttujan, true jos vastaa ehtoja, muutoin false </returns>
        public bool IsValid()
        {
            if (Password.Length >= 10)
            {
                if (Password.Any(char.IsLetter) && Password.Any(char.IsUpper))
                {
                    if (Password.Any(char.IsDigit))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


    }
}