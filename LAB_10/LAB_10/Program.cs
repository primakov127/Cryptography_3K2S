using LAB_10.ElGamal;
using LAB_10.RSA;
using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace LAB_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // TASK 01

            var timer = new Stopwatch();
            var a = new BigInteger(13);
            var n = new BigInteger(Encoding.UTF8.GetBytes("13131139780205884014566051738979"));
            var x = new BigInteger(10);
            var xArray = new BigInteger[]
            {
                BigInteger.Pow(x, 3),
                BigInteger.Pow(x, 11),
                BigInteger.Pow(x, 27),
                BigInteger.Pow(x, 43),
                BigInteger.Pow(x, 56)
            };

            foreach (var num in xArray)
            {
                timer.Start();
                var y = BigInteger.ModPow(a, num, n);
                timer.Stop();
                Console.WriteLine($"y = {y}, a = {a}, n = {n}, x = {num},\n time = {timer.Elapsed}");

                timer.Reset();
            }

            // TASK 02 (RSA)

            var RSA = new RSACryptoServiceProvider();
            byte[] text = Encoding.UTF8.GetBytes("Hi! Here we go again!");

            byte[] crypted = RSACrypto.Crypt(text, RSA.ExportParameters(false));
            string cryptedText = Convert.ToBase64String(crypted);
            Console.WriteLine($"(RSA) Crypted text: {cryptedText}");

            string decryptedText = RSACrypto.Decrypt(crypted, RSA.ExportParameters(true));
            Console.WriteLine($"(RSA) Decrypted text: {decryptedText}");

            // TASK 03 (ElGamal)

            var elGamalCrypted = ElGamalCrypto.Crypt("primakov", 593, 123, 162);
            var elGamalCryptedText = String.Join(',', elGamalCrypted.Select(n => n.ToString()));
            Console.WriteLine($"(ElGamal) Crypted text: {elGamalCryptedText}");
            Console.WriteLine($"(ElGamal) Decrypted text: {ElGamalCrypto.Decrypt(elGamalCrypted, 593, 8)}");
        }
    }
}
