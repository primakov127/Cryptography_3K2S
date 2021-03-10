using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_03
{
    static class Crypto
    {
        public static bool IsPrimeNum(long n)
        {
            for (long i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }

        public static IEnumerable<long> PrimeNumbersList(long from, long to)
        {
            var numbers = new List<long>();
            for (long i = 2; i < to; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                for (long j = 2; j < to; j++)
                {
                    numbers.Remove(numbers[(int)i] * j);
                }
            }
            numbers.RemoveAll(num => num < from);

            return numbers;
        }

        public static long GCD(long a, long b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
    }
}
