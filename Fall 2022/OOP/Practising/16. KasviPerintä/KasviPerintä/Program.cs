using System.Drawing;

namespace KasviPerintä
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kasvin perintä");

            var rikkaruoho = new Kasvi();

            var ruusu = new Kukka();

            var puu = new Puu();

            var koivu = new LehtiPuu();

            var kuusi = new KuusiPuu();

            koivu.Name = "koivu";
            //puu.Name;
            //puu.Kasvuvyohyke;
            //puu.OnkoSuojeltu;

            
        }

    }

    public class Kasvi
    {
        public string Name { get; set; }
        public string Kasvuvyohyke { get; set; }
    }

    public class Kukka : Kasvi
    {
        public Color Vari { get; set; }
    }

    public class Puu : Kasvi
    {
        public bool OnkoSuojeltu { get; set; }
    }

    public class LehtiPuu : Puu
    {
        public bool OnkoRuskanVarit { get; set; }
    }

    public class KuusiPuu : Puu
    {
        public bool OnkoAinaVihrea { get; set; }
    }
}