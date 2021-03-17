using System;

namespace LAB_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string polskAlphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string str = "примаков максим николаевич";
            //RouteCrypt crypt = new RouteCrypt((int)Math.Ceiling(Math.Sqrt(str.Length)));
            //string crypted = crypt.Crypt(str);
            //string encrypted = crypt.Crypt(crypted);
            //Console.WriteLine(crypted);
            //Console.WriteLine(encrypted);
            MultiPermCrypt permCrypt = new MultiPermCrypt(russianAlphabet, "сооолово", "крипто");
            //Console.WriteLine(permCrypt.Encrypt("примаков"));
            string crypted = permCrypt.Encrypt("примаков");
            string encrypted = permCrypt.Decrypt(crypted);
            Console.WriteLine(crypted);
            Console.WriteLine(encrypted);

        }
    }
}
