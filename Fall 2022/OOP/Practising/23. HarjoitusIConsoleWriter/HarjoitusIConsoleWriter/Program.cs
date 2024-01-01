using System.Xml.Serialization;

namespace HarjoitusIConsoleWriter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Writer");
            Console.WriteLine("------");


            // Ilmentymä HappyWriter luokasta
            HappyWriter happyWriter = new HappyWriter();

            // Ilmentymä SadWriter luokasta
            SadWriter sadWriter = new SadWriter();

            // Luodaan rajapintatyyppinen kokoelma
            var collections = new List<IConsoleWriter>();

            // Lisätään edelliset ilmentymät kokoelmaan
            collections.Add(happyWriter);
            collections.Add(sadWriter);

            // Kutsutaan foreach loopissa kunkin ilmentymän rajapinnan WriteLine metodia
            foreach (var item in collections)
            {
                item.WriteLine("Tämä on testiviesti");
            }

            /// CensoredChatWriter luokasta IConsoleWriter- tyyppinen muuttuja
            IConsoleWriter censoredChatWriter = new CensoredChatWriter();

            // Kutsutaan muuttujan WriteLine metodia
            censoredChatWriter.WriteLine("Apina ja gorilla, kävelivät torilla");
            censoredChatWriter.WriteLine("Oletko tyhmä vai idiootti! Haluan erota jo tänään!!");
        }
    }

    /// <summary>
    /// IconsoleWriter rajapinta
    /// </summary>
    public interface IConsoleWriter
    {
        public void WriteLine(string message);
    }
    /// <summary>
    /// HappyWriter luokka, perii IconsoleWriter rajapinnan
    /// </summary>
    public class HappyWriter : IConsoleWriter
    {
        /// <summary>
        /// Kirjoittaa konsoliin parametrina saadun viestin + " :) "
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message + " :)");
        }
    }
    /// <summary>
    /// SadWriter luokka, perii IConsoleWriter rajapinnan
    /// </summary>
    public class SadWriter : IConsoleWriter
    {
        /// <summary>
        /// Kirjoittaa konsoliin parametrina saadun viestin + " :( "
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message)
        {
            Console.WriteLine(message + " :(");
        }
    }
    /// <summary>
    /// CensoreChatWriter luokka, perii IConsoleWriter rajapinnan
    /// </summary>
    public class CensoredChatWriter : IConsoleWriter
    {
        /// <summary>
        /// WriteLine metodi, sensuroi tulostettavaa tekstiä, jos tietyt sanat esiintyvät parametrissä
        /// </summary>
        /// <param name="message"></param>
        public void WriteLine(string message)
        {
            string newMessage;

            /// korvataan tiettyjä sanoja niiden esiintyessä
            if (message.Contains("tyhmä") || message.Contains("erota") || message.Contains("idiootti"))
            {
                newMessage = message.Replace("tyhmä", "ihana");
                newMessage = newMessage.Replace("erota", "mennä naimisiin");
                newMessage = newMessage.Replace("idiootti", "intellektuelli");
                Console.WriteLine(newMessage);
            }
            /// Tulostetaan parametrina saatu viesti muokkaamattomana, jos ei ollut sensuroitavaa
            else
            {
                Console.WriteLine(message);
            }

        }
    }





}