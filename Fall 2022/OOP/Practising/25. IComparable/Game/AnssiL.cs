using System;

namespace Game
{
    public class AnssiL : IPlayer
    {
        public string Name
        {
            get
            {
                return "Anssi L.";
            }
        }
        public int Play()
        {
            Random rando = new Random();
            return rando.Next(3);
        }


    }
}
