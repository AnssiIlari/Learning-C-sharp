using System.Collections;
using System.Threading.Tasks;

namespace TehtavienListaus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ilmentymien tekemistä ja metodien testailua
            ToDo task1 = new ToDo();
            task1.Description = "Tiskaus";
            task1.PrintTask();
            task1.AskTask();
            task1.PrintTask();

            ToDo task2 = new ToDo();
            task2.AskTask();

            ToDo task3 = new ToDo();
            task3.AskTask();

            // Jonon luominen
            Queue<ToDo> tasks = new Queue<ToDo>();
            
            // Ilmentymät listalle
            tasks.Enqueue(task1);
            tasks.Enqueue(task2);
            tasks.Enqueue(task3);

            tasks.First().PrintTask(); // Jonon ensimmäisen ilmentymän PrintTask- metodin kutsuminen
            tasks.Last().PrintTask();  // Jonon viimeisen ilmentymän PrintTask- metodin kutsuminen


            tasks.First().PrintAndDelete(tasks); // PrintAndDelete- metodin kutsu

        }
    }


    /// <summary>
    /// Todo luokka
    /// </summary>
    public class ToDo
    {
        public string Description { get; set; } // Kuvaus


        /// <summary>
        /// AskTask metodi kysyy tehtävän kuvauksen käyttäjältä ja tallentaa sen ominaisuudeksi
        /// </summary>
        public void AskTask()
        {
            Console.WriteLine("Mistä tehtävästä on kyse?");
            Description = Console.ReadLine();
        }
        /// <summary>
        /// PrintTask metodi tulostaa tehtävän kuvauksen
        /// </summary>
        public void PrintTask() // Vaihtoehtoisesti ylikirjoittamalla ToString
        {
            if (Description != null)
            {
                Console.WriteLine($"Tehtävän kuvaus: {Description}");
            }
            else
            {
                Console.WriteLine("Tehtävällä ei ole vielä kuvausta.");
            }
        }
        /// <summary>
        /// PrintAndDelete metodi tyhjentää listan ja tulostaa yksitellen poistetun ilmentymän tehtäväkuvauksen
        /// </summary>
        /// <param name="queue"></param>
        public void PrintAndDelete(Queue<ToDo> queue)
        {
            do
            {
                for (int i = 0; i < queue.Count; i++)
                {
                    ToDo task = queue.Dequeue();
                    task.PrintTask();
                    i++;
                }
            } while (queue != null);
        }


    }
}