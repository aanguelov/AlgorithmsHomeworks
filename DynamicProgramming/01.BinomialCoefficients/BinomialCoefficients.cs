namespace _01.BinomialCoefficients
{
    using System;

    internal class BinomialCoefficients
    {
        private static void Main()
        {
            Console.WriteLine("Please enter n and k:");
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int result = Binomial(n, k);
            Console.WriteLine(result);
        }

        private static int Binomial(int x, int y)
        {
            if (y > x - y)
            {
                y = x - y;
            }

            int temp = 1;
            for (int i = 0; i < y; i++)
            {
                temp = temp * (x - i);
                temp = temp / (i + 1);
            }

            return temp;
        }
    }
}