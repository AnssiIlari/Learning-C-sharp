using Weapons; // Uusi nimiavaruus
using Characters; // Uusi nimiavaruus
using Weapons.Soft; // Uusi nimiavaruus

namespace NameSpaceDemo
{
    internal class Program
    {
        private static object hug;

        static void Main(string[] args)
        {
            //Weapons. löytää kaiken Weapons nimiavaruudesta
            
            Weapons.Gun gun1 = new Weapons.Gun(); // Ilman ylläolevaa namespacea
            Gun gun2 = new Gun(); // Ennalta opeteltu tapa

            Weapons.Knife knife1 = new Knife(); // Ilman ylläolevaa namespacea
            Knife knife2 = new Knife();

            Wizard player = new Wizard(); // Uudesta luokasta, ennalta opetellulla tavallla

            Hug hug = new Hug();
            
        }
    }
}

//namespace Weapons
//{
//}

//namespace Weapons.Soft
//{
//}

//namespace Characters
//{
//}

