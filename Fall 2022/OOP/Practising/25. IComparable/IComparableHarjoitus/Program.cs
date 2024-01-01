namespace IComparableHarjoitus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student1 = new Student("Anssi", 196);
            var student2 = new Student("Toljanteri", 98.1);
            var student3 = new Student("Kati", 176);

            // Yksi keino alustaa taulukko
            Student[] students = new Student[] { student1, student2, student3 };

            foreach (var item in students)
            {
                Console.WriteLine(item.Name + ": " + item.Height);
            }

            Console.WriteLine();
            Array.Sort(students);

            foreach (var item in students)
            {
                Console.WriteLine(item.Name + ": " + item.Height);
            }

            Console.WriteLine();
            Array.Reverse(students);

            foreach (var item in students)
            {
                Console.WriteLine(item.Name + ": " + item.Height);
            }
        }
    }

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public double Height { get; set; }

        public Student(string name, double height)
        {
            Name= name;
            Height= height;
        }

        public int CompareTo(Student? other)
        {
            if (Height > other.Height)
            {
                return 1;
            }
            else if (Height < other.Height)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}