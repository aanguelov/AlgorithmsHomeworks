namespace _02.LongestZigZagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class LongestZigZagSubsequence
    {
        private static void Main()
        {
            var sequence = Console.ReadLine().Split(',').Select(int.Parse).ToArray();

            List<int> subSequence = new List<int>();
            subSequence.Add(sequence[0]);
            subSequence.Add(sequence[1]);
            int last = sequence[1];

            bool greater = sequence[1] > sequence[0];

            for (int i = 2; i < sequence.Length; i++)
            {
                if (greater)
                {
                    bool reverse = false;
                    for (int j = i + 1; j < sequence.Length; j++)
                    {
                        if (sequence[j] > sequence[i])
                        {
                            reverse = true;
                            break;
                        }
                    }

                    if (i == sequence.Length - 1)
                    {
                        reverse = true;
                    }

                    if (reverse && sequence[i] < last)
                    {
                        subSequence.Add(sequence[i]);
                        last = sequence[i];
                        greater = !greater;
                    }
                }
                else
                {
                    bool reverse = false;
                    for (int j = i + 1; j < sequence.Length; j++)
                    {
                        if (sequence[j] < sequence[i])
                        {
                            reverse = true;
                            break;
                        }
                    }

                    if (i == sequence.Length - 1)
                    {
                        reverse = true;
                    }

                    if (reverse && sequence[i] > last)
                    {
                        subSequence.Add(sequence[i]);
                        last = sequence[i];
                        greater = !greater;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", subSequence));
        }
    }
}