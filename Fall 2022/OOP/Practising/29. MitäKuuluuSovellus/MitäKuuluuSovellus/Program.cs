namespace MitäKuuluuSovellus
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Vastaus> vastaukset = new List<Vastaus>();

            while (true)
            {
                Console.WriteLine("Mitä kuuluu, (q = lopeta)");
                string answer = Console.ReadLine();

                if (answer != "q")
                {
                    Vastaus vastaus = new Vastaus(answer);
                    vastaukset.Add(vastaus);
                }
                else
                {
                    break;
                }
            }

            foreach (var item in vastaukset)
            {
                //Console.WriteLine(item.Teksti + " " + item.Aika);
                //Console.WriteLine(item);

                //item.ToString();
                Console.WriteLine(item.ToString());

            }

        }

        public class Vastaus
        {
            public string Teksti { get; set; }
            public DateTime Aika { get; set; }


            public Vastaus(string vastaus)
            {
                Teksti = vastaus;
                Aika = DateTime.Now;
            }

            public override string ToString()
            {
                return Aika.ToString() + " " + Teksti;
            }
        }
    }
}