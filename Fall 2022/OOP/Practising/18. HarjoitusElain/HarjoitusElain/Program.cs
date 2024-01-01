using System.Drawing;
using System.Globalization;

namespace HarjoitusElain
    // Valmis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Ilmentymien luontia ja testailua

            var cat = new Cat();

            cat.Name = "Teppo";
            Console.WriteLine("{0} on kuollut: {1}", cat.Name, cat.IsDead);

            Console.WriteLine("{0} kissalla on {1} elämää", cat.Name, cat.Lives);
            cat.Lives--;
            Console.WriteLine("{0} kissalla on enää {1} elämää", cat.Name, cat.Lives);
            cat.Speak();

            var parrot = new Parrot();
            parrot.PirateHost = "Jalmari Hirmuinen";
            Console.WriteLine("Papukaijan isäntä on {0}", parrot.PirateHost);
            parrot.Speak();

            var sheep = new Sheep();

            Console.WriteLine("Lammas on {0}", sheep.Color);
            sheep.ChangeColor();
            Console.WriteLine("Lammas on {0}", sheep.Color);
            sheep.Speak();


            // Animal taulukon luonti
            Animal[] animal = new Animal[3];

            animal[0] = cat;
            animal[1] = parrot;
            animal[2] = sheep;

            
            /// Jokaisen taulukon alkion läpi käynti foreach-loopilla, kutsutaan Speak-metodia
            foreach (var item in animal)
            {
                item.Speak();
            }



        }
    }
    /// <summary>
    /// Animal luokka
    /// </summary>
    public abstract class Animal
    {
        public string Name { get; set; }
        public bool IsDead { get; set; } // Onko kuollut
        /// <summary>
        /// Speak metodi
        /// </summary>
        abstract public void Speak();

    }

    /// <summary>
    /// Cat luokka
    /// </summary>
    public class Cat : Animal
    {
        public int Lives { get; set; } // Elämät

        // Asetetaan konstruktorissa Lives arvo 9
        public Cat()
        {
            Lives = 9;
        }
        /// <summary>
        /// Override Speak metodi
        /// </summary>
        public override void Speak()
        {
            Console.WriteLine("Miau!");
        }

    }
    /// <summary>
    /// Parrot luokka
    /// </summary>
    public class Parrot : Animal
    {
        public string PirateHost { get; set; } // Isäntä

        /// <summary>
        /// Override Speak metodi
        /// </summary>
        public override void Speak()
        {
            Console.WriteLine("Tsirp!");
        }
    }

    /// <summary>
    /// Sheep luokka
    /// </summary>
    public class Sheep : Animal
    {

        public enum Sheepcolor
        {
            valkoinen,
            musta
        }
        public Sheepcolor Color { get; set; } // Väri

        // Asetetaan konstruktorissa väri valkoiseksi
        public Sheep()
        {
            Color = Sheepcolor.valkoinen;
        }
        /// <summary>
        /// Värin vaihtaminen metodina
        /// </summary>
        public void ChangeColor()
        {
            if (Color == Sheepcolor.valkoinen)
            {
                Color = Sheepcolor.musta;
            }
            else
            {
                Color = Sheepcolor.valkoinen;
            }
        }
        /// <summary>
        /// Override Speak metodi
        /// </summary>
        public override void Speak()
        {
            Console.WriteLine("Baa!");
        }
    }

}