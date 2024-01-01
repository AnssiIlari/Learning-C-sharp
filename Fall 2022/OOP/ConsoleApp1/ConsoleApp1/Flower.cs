namespace ConsoleApp1
{
    public class Flower
    {

        public string Name { get; set; }
        public string Color { get; set; }
        public bool IsAnnual { get; set; }
        public double AvgSize { get; set; }

        public override string ToString()
        {
            return $"{Name} on väriltään {Color} ja se on yksivuotinen: {IsAnnual}. " +
                $"Kukan keskikorkeus on {AvgSize}.";
        }

    }
}