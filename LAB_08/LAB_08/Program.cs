using System;
using System.Text;

namespace LAB_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            LinearCongruentialGenerator.Seed = 324212;
            for (int i = 0; i < 5; i++)
            {
                Console.Write(Convert.ToString(LinearCongruentialGenerator.Rand(), 2));
            }

            Console.WriteLine();

            var key = new byte[] { 123, 125, 41, 84, 203 };
            var encoded = RC4Crypt.Crypt("Вот это да! У тебя получилось!", key);
            var decoded = RC4Crypt.Crypt(encoded, key);

            Console.WriteLine(encoded);
            Console.WriteLine(decoded);
        }
    }
}
