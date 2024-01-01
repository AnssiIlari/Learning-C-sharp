using System.Data;

namespace IDriveable
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("IDriveable");
            Console.WriteLine("----------");

            var bmw = new Car("BMW");

            Console.WriteLine(bmw.ToString());

            bmw.Drive();
        }

    }
    public interface IDriveable
    {
        public string Drive();
    }

    public class Car : IDriveable
    {
        public string Model { get; set; }

        public Car()
        {

        }
        public Car(string model)
        {
            Model = model;
        }

        public override string ToString()
        {
            return ("Tämä on bemari");
        }
        public string Drive()
        {
            return ToString();
        }
    }
}