namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flower flower = new Flower();
            flower.Name = "Voikukka";
            flower.Color = "Keltainen";
            flower.IsAnnual = true;
            flower.AvgSize = 7.55;

            Console.WriteLine(flower.ToString());

            Flower flowerRose = new Flower();
            flowerRose.Name = "Ruusu";
            flowerRose.Color = "Punainen";
            flowerRose.IsAnnual = true;
            flowerRose.AvgSize = 7.55;

            Console.WriteLine(flowerRose.ToString());

            Hay Hay = new Hay();

            Hay.Color = "green";
            Hay.IsAnnual = true;
            Hay.Size = 5.5;
            Hay.IsFlowering = true;
            Hay.Name = "Heinä";

            Console.WriteLine(Hay.ToString());
            Console.WriteLine("{0} is {1}", Hay.Name, Hay.Color);
        }

    }
}