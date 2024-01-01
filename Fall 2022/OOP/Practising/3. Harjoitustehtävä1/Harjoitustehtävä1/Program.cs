using System.Reflection.Metadata.Ecma335;

namespace Harjoitustehtävä1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Toimipiste joensuunToimipiste = new Toimipiste();

            joensuunToimipiste.AutojenLukumäärä = 100;
            joensuunToimipiste.AutojaHuollossa = 20;
            joensuunToimipiste.Myymäläpäällikkö = "Pertti Pertinpoika";

            Auto Auto123 = new Auto();
            Auto123.Merkki = "Toyota";
            Auto123.Malli = "Corolla";
            Auto123.OnkoMyynnissä = true;

            Huolto Samara22122021 = new Huolto();
            Samara22122021.Huoltotoimenpide = "Kampikammion kattovalon korjaus";
            Samara22122021.HuollonSuorittaja = "Esko Eerikäinen";
            Samara22122021.VaraOsat = "Kyynärpäärasva ja vilkkuneste";


            Console.WriteLine("Joensuun toimipisteen myymäläpäällikkö on {0}, hänen vastuullaan on liikkeen tiloissa olevat {1} autoa.",
                joensuunToimipiste.Myymäläpäällikkö, joensuunToimipiste.AutojenLukumäärä);

            Console.WriteLine();

            Console.Write("Ajoneuvo {0} {1}", Auto123.Merkki, Auto123.Malli);
            if (Auto123.OnkoMyynnissä)
            {
                Console.WriteLine(" on myynnissä.");
            }
            else
            {
                Console.WriteLine(" ei ole myynnissä");
            }

            Console.WriteLine();

            Console.WriteLine("Huoltotoimenpiteen: {0} teki {1}. Huoltoon käytetyt osat ja tarvikkeet: {2}"
                , Samara22122021.Huoltotoimenpide, Samara22122021.HuollonSuorittaja, Samara22122021.VaraOsat);


        }
    }
}