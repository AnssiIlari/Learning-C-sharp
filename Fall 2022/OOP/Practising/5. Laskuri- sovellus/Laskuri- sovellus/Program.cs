namespace Laskuri__sovellus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // uusi ilmentymä
            var eestaas = new Counter();

            // testailua
            eestaas.Next();
            eestaas.Next();
            eestaas.Prev();
            eestaas.Prev();
            eestaas.Prev();
        }
    }
    /// <summary>
    /// EesTaas luokan teko
    /// </summary>
    public class Counter
    {
        public int number { get; set; }
        public void Next() // Lisää laskuria yhdellä ja tulostaa arvon
        {
            number++;
            Console.WriteLine(number);
        }
        public void Prev()
        {
            if (number != 0) // Vähentää arvoa yhdellä jos arvo on joku muu kuin 0, sekä tulostaa arvon
            {
                number--;
                Console.WriteLine(number);
            }
            else 
            {
                Console.WriteLine(0);
            }
        }
    }
}