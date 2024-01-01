namespace Pelilauta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var p1 = new Player("Anssi");
            var p2 = new Player("Pertti");

            var board = new Gameboard(p1, p2);

            var winner = board.StartPlay();

            if (winner != null)
            {
                Console.WriteLine("Voittaja on " + winner.Name);
            }
            else
            {
                Console.WriteLine("Tasapeli!");
            }

        }
    }

    public class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            Name = name;
        }

            public int Play()
        {
            Random random = new Random();
            return  random.Next(1, 14);
        }
    }
    public class Gameboard
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Gameboard(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public Player StartPlay()
        {
            var p1 = Player1.Play();
            var p2 = Player2.Play();

            if (p1 > p2)
            {
                return Player1;
            }
            else if (p1 < p2)
            {
                return Player2;
            }
            else
            {
                return null;
            }
        }

    }
}