using LAB_09.Extensions;
using Org.BouncyCastle.Math;
using System;
using System.Linq;
using System.Text;

namespace LAB_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var privateKey = new int[]{ 6, 14, 36, 71, 139, 278, 546, 1109 };
            var m = 2201;
            var n = 37;
            var publicKey = SuperIncreasingSequence.GetNormalSequence(privateKey, n, m);
            foreach (var num in publicKey)
            {
                Console.Write($"{num}, ");
            }

            Console.WriteLine();

            var crypted = KnapsackCrypto.Encrypt("Yeah, you've done it! Молодец!", publicKey);
            foreach (var num in crypted)
            {
                Console.Write($"{num}, ");
            }

            Console.WriteLine();
            Console.WriteLine(KnapsackCrypto.Decrypt(crypted, privateKey, n, m));

            var numb = 420;
            var result = Enumerable.Range(0, (int)Math.Floor(2.52 * Math.Sqrt((double)numb) / Math.Log((double)numb))).Aggregate(
                Enumerable.Range(2, numb - 1).ToList(),
                (result, index) => {
                    var bp = result[index]; var sqr = bp * bp;
                    result.RemoveAll(i => i >= sqr && i % bp == 0);
                    return result;
                }
            );
            
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}
