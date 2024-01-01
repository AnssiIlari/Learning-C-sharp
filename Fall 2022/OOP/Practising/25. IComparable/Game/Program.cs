using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AnssiL anssiL = new AnssiL();
            int i = anssiL.Play();
            Console.WriteLine(i);

        }
    }
}