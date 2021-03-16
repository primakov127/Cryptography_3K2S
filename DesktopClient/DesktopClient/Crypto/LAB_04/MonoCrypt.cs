using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Crypto.LAB_04
{
    public static class MonoCrypt
    {
        public static string Encrypt(string alphabet, string text, int key)
        {
            string smallAlphabet = alphabet.ToLower();
            string smallText = text.ToLower();

            IEnumerable<char> encryptedChars = smallText.ToCharArray().ToList().Select((symbol) =>
            {
                var symbolIndex = smallAlphabet.IndexOf(symbol);
                if (symbolIndex != -1)
                {
                    return smallAlphabet[(symbolIndex + key) % smallAlphabet.Length];
                }
                return symbol;

            });

            return String.Concat(encryptedChars);
        }

        public static string Decrypt(string alphabet, string text, int key)
        {
            string smallAlphabet = alphabet.ToLower();
            string smallText = text.ToLower();

            IEnumerable<char> encryptedChars = smallText.ToCharArray().ToList().Select((symbol) =>
            {
                var symbolIndex = smallAlphabet.IndexOf(symbol);
                if (symbolIndex != -1)
                {
                    return smallAlphabet[(symbolIndex - key) >= 0 ? (symbolIndex - key) : smallAlphabet.Length + (symbolIndex - key)];
                }
                return symbol;

            });

            return String.Concat(encryptedChars);
        }
    }
}
