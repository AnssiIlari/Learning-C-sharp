namespace Tehtävä_3_ConsoleVersion
{
  

    class Program
    {
        static int[] seats = new int[150]; // Istumapaikat taulukossa
        static int numThreads = 100; // Säikeet taulukossa ( 1000 säikeellä ei synny paljoa eroja, jos 100 niin erot selkeitä)
        static Random random = new Random();

        static void Main(string[] args)
        {
            int reservedSeats = 0;

            // Luodaan threadit taulukkoon
            Thread[] threads = new Thread[numThreads];

            // Käynnistetään säikeet for-loopissa
            for (int i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(ReserveSeats);
                threads[i].Start();
            }

            // Lasketaan varattujen paikkojen määrä for-loopissa
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    reservedSeats++;
                }
            }

            // Tulosten tulostus
            Console.WriteLine("Varattu {0} istumapaikkaa synkronoimatta.", reservedSeats);

            // Käynnistetään seuraava erä säikeitä
            for (int i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(ReserveSeatSync);
                threads[i].Start();
            }

            reservedSeats = 0;

            // Lasketaan varattujen paikkojen määrä
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 1)
                {
                    reservedSeats++;
                }
            }
            // Tulosten tulostus
            Console.WriteLine("Varattu {0} istumapaikkaa synkronoinnilla.", reservedSeats);
        }

        /// <summary>
        /// Synkronoimaton paikkojen varausmetodi
        /// </summary>
        static void ReserveSeats()
        {
            int seat = random.Next(0, seats.Length);

            if (seats[seat] == 0)
            {
                seats[seat] = 1;
            }
        }

        /// <summary>
        /// Synkronoitu paikkojen varausmetodi
        /// </summary>
        static void ReserveSeatSync()
        {
            lock (seats)
            {
                int seat = random.Next(0, seats.Length);
                if (seats[seat] == 0)
                {
                    seats[seat] = 1;
                }
            }
        }
    }
}