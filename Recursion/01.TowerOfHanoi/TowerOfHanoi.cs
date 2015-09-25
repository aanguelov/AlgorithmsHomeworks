namespace _01.TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class TowerOfHanoi
    {
        private static int stepsCount;

        private static Stack<int> source;

        private static readonly Stack<int> Destination = new Stack<int>();

        private static readonly Stack<int> Spare = new Stack<int>();

        private static void Main()
        {
            int numberOfDisks = int.Parse(Console.ReadLine());

            source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());

            PrintRods();
            MoveDisks(numberOfDisks, source, Destination, Spare);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                stepsCount++;
                destination.Push(source.Pop());
                Console.WriteLine("Step #{0}: Moved disk: {1}", stepsCount, bottomDisk);
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                stepsCount++;
                destination.Push(source.Pop());
                Console.WriteLine("Step #{0}: Moved disk: {1}", stepsCount, bottomDisk);
                PrintRods();
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", Destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", Spare.Reverse()));
            Console.WriteLine();
        }
    }
}