using System.Net;

namespace GenericsDemoAppOikea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] taulukko = new string[4];

            List<string> list = new List<string>();
            
            list.Add("a");
            list.Add("b");
            list.Add("c");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            list.ForEach(item => Console.WriteLine(item)); // yksi lisätapa


            list.Remove("b");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}