using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_02
{
    public static class Entropy
    {
        public static float Shannon(string text)
        {
            var map = new Dictionary<char, int>();
            foreach (var ch in text)
            {
                if (map.ContainsKey(ch))
                    map[ch]++;
                else
                    map.Add(ch, 1);
            }

            float result = 0;
            foreach (var d in map)
            {
                //Console.WriteLine($"{d.Key} : { (float)d.Value / text.Length}");
                //sum += (float)d.Value / clearText.Length;
                float probability = (float)d.Value / text.Length;
                result += probability * (float)Math.Log2(probability);
            }

            return result *= -1;
        }

        public static string ToBitString(string text)
        {
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in textBytes)
            {
                sb.Append(Convert.ToString(b, 2));
            }
            return sb.ToString();
        }

        public static float GetASCIInformationCount(string text, float entropy)
        {
            //byte[] bytes = Encoding.ASCII.GetBytes(text);
            //int n = 0;
            //foreach (var b in bytes)
            //{
            //    n += b.ToString().Length;
            //}
            //return entropy * n;
            return entropy * (text.Length * 8);
        }

        public static float GetInformationCount(string text, float entropy)
        {
            return entropy * text.Length;
        }

        public static float GetInformationCountEr(float p, int messageLenght)
        {
            float q = 1 - p;
            float conditionalEntropy = (float)(-p * Math.Log2(p) - q * Math.Log2(q));
            float effectiveEntropy = 1 - conditionalEntropy;
            return (float)(messageLenght * effectiveEntropy);
        }
    }
}
