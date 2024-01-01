namespace KiviPaperiSakset
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Kivi, paperi, sakset");
            Console.WriteLine();

            var Pelaaja1 = new Pelaaja("Anssi");
            var Pelaaja2 = new Pelaaja("Pekka");

            Console.WriteLine("{0} : {1}", Pelaaja1.name, Pelaaja1.Play());
            Console.WriteLine("{0} : {1}", Pelaaja2.name, Pelaaja2.Play());

        }
    }

    public class Pelaaja
    {

        public enum Result
        {
            Kivi, 
            Paperi,
            Sakset
        }
        public string name { get;private set; }

        public Result Play()
        {
            Random random = new Random();

            return (Result)random.Next(3);

        }

        public Pelaaja(string Name)
        {
            name = Name;
        }

    }
}