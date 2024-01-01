namespace VehicleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Brand = "Subaru";
            car.Drive();
            car.Refuel();

            IDriveable driveableCar = car;
            driveableCar.Drive();
            IRefuelable refuelablecar = car;
            refuelablecar.Refuel();

            Bike bike = new Bike();

            bike.Drive();
            IDriveable driveableBike = bike;
            driveableBike.Drive();

            EBike ebike = new EBike();
            ebike.Drive();
            ebike.Refuel();

            IDriveable driveableEBIKE = new EBike();
            IRefuelable refualableEBIKE = new EBike();

            driveableEBIKE.Drive();
            refualableEBIKE.Refuel();

            //Console.WriteLine(bike.Range);

            Monkey monkey = new Monkey();
            monkey.Refuel();

            IRefuelable refuelableMonkey = monkey;
            refuelableMonkey.Refuel();

            IDriveable[] driveables = new IDriveable[3];

            driveables[0] = car;
            driveables[1] = bike;
            driveables[2] = ebike;

            foreach (var item in driveables)
            {
                item.Drive();
            }

            IRefuelable[] refuelables = new IRefuelable[3];

            refuelables[0] = car;
            refuelables[1] = ebike;
            refuelables[2] = monkey;

            foreach (var item in refuelables)
            {
                item.Refuel();
            }

        }
    }

    public interface IDriveable
    {
        public void Drive();
    }
    public interface IRefuelable
    {
        public void Refuel();
    }

    public class Car : IDriveable, IRefuelable
    {
        public string Brand { get; set; }

        public void Drive()
        {
            Console.WriteLine("Frummmmmmmm my car is driving....");
        }

        public void Refuel()
        {
            Console.WriteLine("Tankattu");
        }
    }

    public class Bike : IDriveable
    {
        public int Range { get; set; }
        public void Drive()
        {
            Console.WriteLine("Bike goes vrrrr....");
        }

    }
    public class EBike : Bike, IDriveable, IRefuelable
    {

        public EBike()
        {
            Range = 100;
        }

        public void Drive()
        {
            Console.WriteLine("Ebike goes whirrrr....");
        }

        public void Refuel()
        {
            Console.WriteLine("Sähkötetty");
        }

    }
    public class Monkey : IRefuelable
    {

        public void Refuel()
        {
            Console.WriteLine("Apina on tankattu");
        }

    }

}