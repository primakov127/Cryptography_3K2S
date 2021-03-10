using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LAB_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameEn = "Primakov Maksim Nikolaevich";
            string nameRu = "Примаков Максим Николаевич";
            string inputTextEn = System.IO.File.ReadAllText(@".\Data\en.txt");
            string inputTextRu = System.IO.File.ReadAllText(@".\Data\ru.txt");
            var clearPatternEn = new Regex(@"(\W|\d)", RegexOptions.IgnoreCase);
            var clearPatternRu = new Regex(@"[^А-Яа-я]", RegexOptions.IgnoreCase);

            var clearTextEn = clearPatternEn.Replace(inputTextEn, "").ToLower();
            var clearTextRu = clearPatternRu.Replace(inputTextRu, "").ToLower();
            var clearBitTextEn = Entropy.ToBitString(clearTextEn);
            var clearBitTextRu = Entropy.ToBitString(clearTextRu);
            var clearNameEn = clearPatternEn.Replace(nameEn, "");
            var clearNameRu = clearPatternRu.Replace(nameRu, "");

            float entropyEn = Entropy.Shannon(clearTextEn);
            float entropyBitEn = Entropy.Shannon(clearBitTextEn);
            float entropyRu = Entropy.Shannon(clearTextRu);
            float entropyBitRu = Entropy.Shannon(clearBitTextRu);

            float infoASCICountEn = Entropy.GetASCIInformationCount(clearNameEn, entropyBitEn);
            float infoASCICountRu = Entropy.GetASCIInformationCount(clearNameRu, entropyBitRu);
            float infoCountEn = Entropy.GetInformationCount(clearNameEn, entropyEn);
            float infoCountRu = Entropy.GetInformationCount(clearNameRu, entropyRu);

            Console.WriteLine($"EN Entropy: {entropyEn}");
            Console.WriteLine($"EN Bit Entropy: {entropyBitEn}");
            Console.WriteLine($"RU Entropy: {entropyRu}");
            Console.WriteLine($"RU Bit Entropy: {entropyBitRu}");
            Console.WriteLine();
            Console.WriteLine($"Information Count ASCI EN: {infoASCICountEn}");
            Console.WriteLine($"Information Count ASCI RU: {infoASCICountRu}");
            Console.WriteLine($"Information Count EN: {infoCountEn}");
            Console.WriteLine($"Information Count RU: {infoCountRu}");
            Console.WriteLine();
            Console.WriteLine($"Information Count Err[0.1] EN: {Entropy.GetInformationCountEr(0.1f, clearBitTextEn.Length)}");
            Console.WriteLine($"Information Count Err[0.5] EN: {Entropy.GetInformationCountEr(0.5f, clearBitTextEn.Length)}");
            Console.WriteLine($"Information Count Err[1] EN: {Entropy.GetInformationCountEr(1f, clearBitTextEn.Length)}");
            Console.WriteLine();
            Console.WriteLine($"Information Count Err[0.1] RU: {Entropy.GetInformationCountEr(0.1f, clearBitTextRu.Length)}");
            Console.WriteLine($"Information Count Err[0.5] RU: {Entropy.GetInformationCountEr(0.5f, clearBitTextRu.Length)}");
            Console.WriteLine($"Information Count Err[1] RU: {Entropy.GetInformationCountEr(1f, clearBitTextRu.Length)}");
        }
    }
}
