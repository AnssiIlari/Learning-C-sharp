using System.Diagnostics;
using System.Drawing;

namespace Laivanupotuspeli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Laivanupotuspeli");

            var Player1 = new Player("Anssi"); // Uusi ilmentymä Player luokasta
            Player1.Ships = Ship.CreateShips(); // Ilmentymälle tehdään laivat

            var Player2 = new Player("Pertti"); 
            Player2.Ships = Ship.CreateShips();

            var Board = new Board(); // Uusi ilmentymä Board luokasta
            Board.Player1 = Player1; // Edellä luodut ilmentymät Board luokan ilmentymän ominaisuuksiksi
            Board.Player2 = Player2;

            Board.PrintData();

            Board.PrintShips();

            string winner = Board.GetWinner(); // Voittajan haku  metodilla
            Console.WriteLine(winner);

            Board.GameStoppedTime(); // Pelin lopetusajan tulostaminen metodilla
        }
    }

    /// <summary>
    /// Pelaaja luokka
    /// </summary>
    public class Player
    {
        public string Name { get; set; } // Nimi
        public Ship[] Ships { get; set; } // Taulukko laivoista

        public Player(string name) // Konstruktori jossa ilmentymä saa arvon Name ominaisuuteen
        {
            Name = name;
        }
    }

    /// <summary>
    /// Board luokka
    /// </summary>
    public class Board
    {

        private DateTime gameStarted = DateTime.Now; // Aloitusaika saatavilla

        public Player Player1 { get; set; } // Pelaajat
        public Player Player2 { get; set; }

        /// <summary>
        /// Metodi voittajan palauttamiselle, logiikkaa ei vielä ole joten ei tiedossa
        /// </summary>
        /// <returns> Palauttaa voittajan string muodossa </returns>
        public string GetWinner()
        {
            return "Voittaja: ei tiedossa";
        }
        /// <summary>
        /// Metodi pelin lopetusajan tulostamiselle
        /// </summary>
        public void GameStoppedTime()
        {
            Console.WriteLine("Peli päättyi: " + DateTime.Now);
        }
        /// <summary>
        /// Metodi joka tulostaa pelaajien nimet ja aloitusajan
        /// </summary>
        public void PrintData()
        {
            Console.WriteLine("Pelaajat: " + Player1.Name + " & " + Player2.Name);
            Console.WriteLine(gameStarted);
        }
        /// <summary>
        /// Metodi joka tulostaa pelajaajien laivojen tiedot
        /// </summary>
        public void PrintShips()
        {
            foreach (var ship in Player1.Ships)
            {
                Console.WriteLine("Tyyppi: " + ship.Type);
                Console.WriteLine("Koko ruutuina: " + ship.Size);
                Console.WriteLine("Onko pystyasennossa: " + ship.IsUpright);
            }

            Console.WriteLine("");

            foreach (var ship in Player2.Ships)
            {
                Console.WriteLine("Tyyppi: " + ship.Type);
                Console.WriteLine("Koko ruutuina: " + ship.Size);
                Console.WriteLine("Onko pystyasennossa: " + ship.IsUpright);
            }
        }

    }

    public class Ship
    {
     
        public enum Shiptype // Tyyppi enumilla
        {
            Lentotukialus,
            Taistelulaiva,
            Risteilijä,
            Hävittäjä,
            Sukellusvene
        }

        public Shiptype Type { get; set; } // Tyyppi
        public bool HasSunk { get; set; } // Onko uponnut, vakiona false
        public int Size { get; set; } // Koko
        public bool IsUpright { get; set; } // Onko pysty- vai vaaka-asennossa

        public Ship(Shiptype type, int size, bool isUpright) // Konstruktori jossa ilmentymä saa Type, Size ja IsUpright ominaisuuksiin arvot
        {
            Type = type;
            Size = size;
            IsUpright = isUpright;
        }
        /// <summary>
        /// Metodi laivojen luonnille
        /// </summary>
        /// <returns> Palauttaa laivat taulukkona </returns>
        public static Ship[] CreateShips()
        {
            var ships = new Ship[6];

            ships[0] = new Ship(Shiptype.Lentotukialus, 5, true);
            ships[1] = new Ship(Shiptype.Taistelulaiva, 4, true);
            ships[2] = new Ship(Shiptype.Risteilijä, 3, true);
            ships[3] = new Ship(Shiptype.Risteilijä, 3, false);
            ships[4] = new Ship(Shiptype.Hävittäjä, 2, false);
            ships[5] = new Ship(Shiptype.Sukellusvene, 1, false);

            return ships;
        }



    }
}