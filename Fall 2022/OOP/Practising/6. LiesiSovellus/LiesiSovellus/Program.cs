using System.ComponentModel;

namespace LiesiSovellus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var levy1 = new Levy();
            levy1.RaiseTemperature();
            levy1.RaiseTemperature();
            levy1.RaiseTemperature();
            levy1.RaiseTemperature();
            levy1.LowerTemperature();
            levy1.LowerTemperature();
            levy1.LowerTemperature();
            levy1.LowerTemperature();
            levy1.LowerTemperature();
            levy1.LowerTemperature();

        }
    }

    public class Levy
    {

        public int level { get; set; } = 0;

        public int Temperature
        {
            get { return level * 10; }
        }
        public bool IsHot
        {
            get { return level > 0; }
        }

        public void RaiseTemperature()
        {
            if (level < 10)
            {
                level++;
                Console.WriteLine(level);
            }
        }

        public void LowerTemperature()
        {
            if (level > 0)
            {
                level--;
                Console.WriteLine(level);
            }
        }
    }
}