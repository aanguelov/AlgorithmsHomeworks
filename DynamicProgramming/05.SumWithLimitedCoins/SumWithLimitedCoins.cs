namespace _05.SumWithLimitedCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SumWithLimitedCoins
    {
        private static bool[] usedCoins;

        private static HashSet<string> combinations = new HashSet<string>(); 

        private static List<int> comb = new List<int>(); 

        private static void Main()
        {
            int[] coins = { 1, 2, 2, 3, 3, 4, 6 };
            int sum = 6;
            usedCoins = new bool[coins.Length];
            GetSumOfLimitedCoins(coins, sum, comb);
            Console.WriteLine(combinations.Count);
        }

        private static void GetSumOfLimitedCoins(int[] arr, int sum, List<int> combTemp, int index = 0)
        {
            if (combTemp.Sum() == sum)
            {
                combinations.Add(string.Join(",", combTemp));
                return;
            }

            if (combTemp.Sum() > sum)
            {
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                if (!usedCoins[i])
                {
                    usedCoins[i] = true;
                    combTemp.Add(arr[i]);
                    GetSumOfLimitedCoins(arr, sum, combTemp, i);

                    combTemp.Remove(arr[i]);
                    usedCoins[i] = false;
                }
            }
        }
    }
}