using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maatila");

            var cat = new Cat("Kisu");
            cat.Playsound();
            
            
            var dog = new Dog("Musti", 7);
            dog.Playsound();

            var pig = new Pig("Possu");
            pig.Playsound();

            pig.Farting(false);
            pig.Farting(true);

            Console.Beep(); // Lol


        }
    }

    public abstract class Animal
    {
        private string animalName;

        public Animal(string name)
        {
             animalName = name;
        }

        public virtual void Playsound()
        {
            Console.Write(animalName + " says ");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {

        }

        public override void Playsound()
        {
            base.Playsound();
            Console.WriteLine("meoww");
        }
    }

    public class Dog : Animal
    {

        private int dogAge;
        public Dog(string name, int age) : base(name)
        {
            dogAge = age;
        }
        public override void Playsound()
        {
            base.Playsound();
            Console.WriteLine("wuf-wuf");
            Console.WriteLine("Ikäni on {0}", dogAge);
        }
    }

    public class Pig : Animal
    {
        public Pig(string name) : base(name)
        {

        }

        public override void Playsound()
        {
            base.Playsound();
            Console.WriteLine("whiii");
        }

        public void Farting(bool loud)
        {
            if (loud)
            {
                Console.WriteLine("PIG IS FARTING!!!!");
            }
            else
            {
                Console.WriteLine("Pig is farting");
            }
        }
    }

}