namespace _03.DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class DividingPresents
    {
        private static void Main()
        {
            var presents = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            Array.Sort(presents);
            Array.Reverse(presents);

            List<int> presentsAlan = new List<int>();
            List<int> presentsBob = new List<int>();
            int maxAlan = 0;
            int maxBob = 0;

            for (int i = 0; i < presents.Length; i++)
            {
                if (maxBob < maxAlan)
                {
                    maxBob += presents[i];
                    presentsBob.Add(presents[i]);
                }
                else
                {
                    maxAlan += presents[i];
                    presentsAlan.Add(presents[i]);
                }
            }

            int diff = Math.Abs(maxBob - maxAlan);

            Console.WriteLine("Difference " + diff);
            Console.WriteLine("Alan: " + maxAlan + " Bob: " + maxBob);
            Console.WriteLine(string.Join(" ", presentsAlan));
            Console.WriteLine(string.Join(" ", presentsBob));
        }
    }
}