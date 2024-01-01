using Karelia.IO;

namespace ComponentDemoAPp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plant rose = new Plant();
            rose.Name = "Ruusu";
            rose.Width = 30;

            MyObjectSerializer.SaveObject("C:\\Temp\\ruusu.xml", rose);

            object o = MyObjectSerializer.ReadObject("C:\\Temp\\ruusu.xml", typeof(Plant));

            Console.WriteLine(o);

        }
    }

    public class Plant
    {
        public string Name { get; set; }
        public int Width { get; set; }

        public override string ToString()
        {
            return "Nimi: " + Name + " Korkeus: " + Width;
        }

    }
}