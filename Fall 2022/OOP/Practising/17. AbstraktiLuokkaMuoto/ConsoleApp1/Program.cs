namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ilmentymien luonti ja piirtometodit

            var suorakaide = new Suorakaide();
            suorakaide.Draw();

            var nelio = new Nelio();
            nelio.Draw();

            var viiva = new Viiva();
            viiva.Draw();
        }
    }
    /// <summary>
    /// Muoto luokka
    /// </summary>
    public abstract class Muoto
    {
        public string Name { get; set; }

        public abstract void Draw();
    }

    /// <summary>
    ///  Suorakaide luokka
    /// </summary>
    public class Suorakaide : Muoto
    {
        public Suorakaide()
        {
            Name = "Suorakaide";
        }

        public override void Draw()
        {
            Console.WriteLine(Name);
            Console.WriteLine("");
            Console.WriteLine("----------");
            Console.WriteLine("|        |");
            Console.WriteLine("----------");
            Console.WriteLine("");
        }
    }
    /// <summary>
    /// Neliö luokka
    /// </summary>
    public class Nelio : Muoto
    {
        public Nelio()
        {
            Name = "Neliö";
        }
        /// <summary>
        /// Tulostus / piirto -metodi
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine(Name);
            Console.WriteLine("");
            Console.WriteLine("----");
            Console.WriteLine("|  |");
            Console.WriteLine("----");
            Console.WriteLine("");
        }
    }
    /// <summary>
    /// Viiva luokka
    /// </summary>
    public class Viiva : Muoto
    {
        public Viiva()
        {
            Name = "Viiva";
        }

        /// <summary>
        /// Tulostus / piirto -metodi
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine(Name);
            Console.WriteLine("");
            Console.WriteLine("-----");
            Console.WriteLine("");
        }
    }
}