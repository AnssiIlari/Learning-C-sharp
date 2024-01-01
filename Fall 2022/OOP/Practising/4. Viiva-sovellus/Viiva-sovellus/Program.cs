using System.Xml.Serialization;

namespace Viiva_sovellus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var viiva = new Viiva();

            viiva.Length = 10;

            viiva.Draw();
            viiva.Draw("y");
            viiva.Draw("x");
            viiva.DrawDoubleLine();
        }


    }
    /// <summary>
    /// Viiva luokan luominen
    /// </summary>
    public class Viiva
    {
        public int Length { get; set; }
        /// <summary>
        /// Viivojen tulostus for-loopissa
        /// </summary>
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Tulostaa haluttuja merkkejä
        /// </summary>
        /// <param name="merkki"></param>
        public void Draw(string merkki) 
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write(merkki);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Tulostaa = merkkiä
        /// </summary>
        public void DrawDoubleLine()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }
    }

}