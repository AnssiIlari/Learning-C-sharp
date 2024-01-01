namespace IComparable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emp1 = new Employee("Eero", 3000);
            var emp2 = new Employee("Mika", 2000);
            var emp3 = new Employee("Mervi", 6000);

            Employee[] emps = new Employee[] { emp1, emp2, emp3 }; // Yksi tapa alustaa taulukko

            foreach (var item in emps)
            {
                Console.WriteLine(item.Name + ": " + item.Salary);
            }

            Console.WriteLine("");

            Array.Sort(emps);
            Array.Reverse(emps);

            foreach (var item in emps)
            {
                Console.WriteLine(item.Name + ": " + item.Salary);
            }


        }
    }

    public class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name= name;
            Salary= salary;
        }

        public int CompareTo(Employee? other)
        {
            if (Salary > other.Salary)
            {
                return 1;
            }
            else if (Salary < other.Salary)
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