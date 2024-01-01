namespace Joukot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Joukkojen luominen
            HashSet<int> GroupA = new HashSet<int>();
            HashSet<int> GroupB = new HashSet<int>();

            // Arvojen lisääminen joukkoihin
            GroupA.Add(1);
            GroupA.Add(2);
            GroupA.Add(3);
            GroupA.Add(4);
            GroupA.Add(5);

            GroupB.Add(3);
            GroupB.Add(4);
            GroupB.Add(5);
            GroupB.Add(6);
            GroupB.Add(7);

            // Luodaan kopiot Hashseteistä, jotta saadaan säilytettyä alkuperäinen
            HashSet<int> UnionGroup = new HashSet<int>(GroupA);
            HashSet<int> IntersectGroup = new HashSet<int>(GroupA);
            HashSet<int> ExceptGroupAMinusB = new HashSet<int>(GroupA);
            HashSet<int> ExceptGroupBMinusA = new HashSet<int>(GroupB);

            // Tehdään kopioille joukko-opin perusoperaatiot
            UnionGroup.UnionWith(GroupB);
            IntersectGroup.IntersectWith(GroupB);
            ExceptGroupAMinusB.ExceptWith(GroupB);
            ExceptGroupBMinusA.ExceptWith(GroupA);

            // Joukkojen tulostus
            PrintData("Alkuperäinen A", GroupA);
            PrintData("Alkuperäinen B", GroupB);
            PrintData("Unioni", UnionGroup);
            PrintData("Leikkaus", IntersectGroup);
            PrintData("Erotus A / B", ExceptGroupAMinusB);
            PrintData("Erotus B / A", ExceptGroupBMinusA);

        }
        /// <summary>
        /// PrintData metodi tulostaa selityksen ja HashSetin
        /// </summary>
        /// <param name="explanation"></param>
        /// <param name="hashSet"></param>
        public static void PrintData(string explanation, HashSet<int> hashSet)
        {
            Console.WriteLine(explanation);
            Console.WriteLine();

            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}