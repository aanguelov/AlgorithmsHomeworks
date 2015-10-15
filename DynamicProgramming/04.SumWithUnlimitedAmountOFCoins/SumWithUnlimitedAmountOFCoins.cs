namespace _04.SumWithUnlimitedAmountOFCoins
{
    using System;

    internal class SumWithUnlimitedAmountOfCoins
    {
        private static int totalComb;

        private static void Main()
        {
            int[] coins = { 1, 2, 5, 10 };
            int sum = 13;
            int tempSum = 0;
            SumCoinsRecursive(coins, sum, tempSum, 0);
            Console.WriteLine(totalComb);
        }

        private static void SumCoinsRecursive(int[] arr, int sum, int tempSum, int index)
        {
            if (tempSum > sum)
            {
                return;
            }

            if (tempSum == sum)
            {
                totalComb++;
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                tempSum += arr[i];
                SumCoinsRecursive(arr, sum, tempSum, i);

                tempSum -= arr[i];
            }
        }
    }
}