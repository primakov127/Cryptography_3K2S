using System;

namespace LAB_04
{
    class Program
    {
        static void Main(string[] args)
        {
            string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string polskAlphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            string crypted = MonoCrypt.Encrypt(polskAlphabet, "Język polski", 7);
            string encrypted = MonoCrypt.Decrypt(polskAlphabet, crypted, 7);
            Console.WriteLine(crypted);
            Console.WriteLine(encrypted);
            PolygamCrypt polygamRussian = new PolygamCrypt(russianAlphabet);
            PolygamCrypt polygamPolsk = new PolygamCrypt(polskAlphabet);
            string cryptedPolsk = polygamPolsk.Encrypt("Językpolski");
            string encryptedPolsk = polygamPolsk.Decrypt(cryptedPolsk);
            string cryptedRussian = polygamRussian.Encrypt("Примаков");
            string encryptedRussian = polygamRussian.Decrypt(cryptedRussian);
            Console.WriteLine(cryptedRussian);
            Console.WriteLine(encryptedRussian);
            Console.WriteLine(cryptedPolsk);
            Console.WriteLine(encryptedPolsk);
        }
    }
}
