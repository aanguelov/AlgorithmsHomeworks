namespace _05.PermutationsWithRepetition
{
    using System;

    internal class PermutationsWithRepetition
    {
        private static void Main()
        {
            //int[] arr = { 1, 3, 5, 5 };
            int[] arr = { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            int start = 0;
            int end = arr.Length - 1;

            GeneratePermWithRep(arr, start, end);
        }

        private static void GeneratePermWithRep(int[] array, int start, int end)
        {
            Console.WriteLine("{{{0}}}", string.Join(", ", array));

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (array[left] != array[right])
                    {
                        int temp = array[left];
                        array[left] = array[right];
                        array[right] = temp;

                        GeneratePermWithRep(array, left + 1, end);
                    }
                }

                int firstElement = array[left];
                for (int i = left; i <= end - 1; i++)
                {
                    array[i] = array[i + 1];
                }

                array[end] = firstElement;
            }
        }
    }
}