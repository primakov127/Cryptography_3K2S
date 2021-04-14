using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Crypto.LAB_09
{
    public static class SuperIncreasingSequence
    {
        private static Random _rand = new Random();

        /// <summary>
        /// Generate Super Increasing int array
        /// </summary>
        public static int[] Generate(int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result.Sum() + _rand.Next(1, 20);
            }

            return result;
        }

        /// <summary>
        /// Return a normal sequence from super increasing one. 
        /// {m} should be more than sum of the incoming array elements,
        /// {m} and {n} should be mutually simple.
        /// </summary>
        public static int[] GetNormalSequence(int[] superIncreasingSequence, int n, int m)
        {
            int sequenceLength = superIncreasingSequence.Length;
            int[] result = new int[sequenceLength];
            for (int i = 0; i < sequenceLength; i++)
            {
                result[i] = (superIncreasingSequence[i] * n) % m;
            }

            return result;
        }
    }
}
