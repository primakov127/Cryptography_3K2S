using DesktopClient.Crypto.LAB_09.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Crypto.LAB_09
{
    public static class KnapsackCrypto
    {
        public static IEnumerable<int> Encrypt(string text, IEnumerable<int> publicKey)
        {
            var binarySymbols = text.ToString1251BinaryArray();
            var result = new List<int>(binarySymbols.Count());

            foreach (var binarySymbol in binarySymbols)
            {
                var sum = 0;
                for (int i = 0; i < binarySymbol.Length; i++)
                {
                    if (binarySymbol[i].Equals('1'))
                    {
                        sum = sum + publicKey.ElementAt(i);
                    }
                }
                result.Add(sum);
            }

            return result;
        }

        public static string Decrypt(IEnumerable<int> cipher, IEnumerable<int> privateKey, int n, int m)
        {
            var nModInverse = n.ModInverse(m);
            var binaryStrings = new List<string>();
            var binarySymobl = new StringBuilder();

            foreach (var cipherNum in cipher)
            {
                int knapsackWeight, knapsackWeightRemainder;
                knapsackWeightRemainder = knapsackWeight = (cipherNum * nModInverse) % m;
                binarySymobl.Clear();

                foreach (var keyNum in privateKey.Reverse())
                {
                    if (keyNum <= knapsackWeightRemainder)
                    {
                        binarySymobl.Insert(0, '1');
                        knapsackWeightRemainder = knapsackWeightRemainder - keyNum;
                    }
                    else
                    {
                        binarySymobl.Insert(0, '0');
                    }
                }
                binaryStrings.Add(binarySymobl.ToString());
            }

            return binaryStrings.ToStringFrom1251BinaryArray();
        }
    }
}
