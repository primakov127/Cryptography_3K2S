using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LAB_10.ElGamal
{
    public class ElGamalCrypto
    {
        public static int[] Crypt(string text, int p, int g, int y)
        {
            var bigP = new BigInteger(p);
            var bigG = new BigInteger(g);
            var bigY = new BigInteger(y);
            var rand = new Random();
            var byteText = Encoding.GetEncoding(1251).GetBytes(text);
            var result = new List<int>();

            foreach (var m in byteText)
            {
                var bigM = new BigInteger(m); // Open text symbol
                var k = new BigInteger(rand.Next(1, p - 1));

                var r = BigInteger.ModPow(bigG, k, bigP);
                var c = (bigM * BigInteger.Pow(bigY, (int)k)) % bigP;

                result.Add((int)r);
                result.Add((int)c);
            }

            return result.ToArray();
        }

        public static string Decrypt(int[] text, int p, int x)
        {
            var bigP = new BigInteger(p);
            var result = new List<byte>();

            for(int i = 0; i < text.Length; i += 2)
            {
                var r = new BigInteger(text[i]);
                var c = new BigInteger(text[i + 1]);

                var m = (c * BigInteger.Pow(r, p - 1 - x)) % bigP;
                result.Add((byte)m);
            }

            return Encoding.GetEncoding(1251).GetString(result.ToArray());
        }
    }
}
