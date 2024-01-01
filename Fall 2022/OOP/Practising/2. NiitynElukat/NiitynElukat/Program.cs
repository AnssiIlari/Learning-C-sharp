namespace NiitynElukat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal Insect = new Animal();
            Animal Cow = new Animal();
            Animal Bat = new Animal();

            Animal.Time = 11;
            Insect.Species = "Insect";
            Cow.Species = "Cow";
            Bat.Species = "Bat";
            
            if (Animal.Time >= 5 && Animal.Time <= 22)
            {
                Cow.IsAwake = true;
            }
            else if (Animal.Time >= 6 && Animal.Time <= 22)
            {
                Insect.IsAwake = true;
            }
            else if (Animal.Time >= 22 || Animal.Time <= 5)
            {
                Bat.IsAwake = true;
            }

            Console.WriteLine("{0} is awake at {1}: {2}", Cow.Species, Animal.Time, Cow.IsAwake);
            Console.WriteLine("{0} is awake at {1}: {2}", Insect.Species, Animal.Time, Insect.IsAwake);
            Console.WriteLine("{0} is awake at {1}: {2}", Bat.Species, Animal.Time, Bat.IsAwake);


        }
    }
}