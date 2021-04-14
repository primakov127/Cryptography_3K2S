using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Crypto.LAB_09.Extensions
{
    public static class StringExtension
    {
        public static IEnumerable<string> ToString1251BinaryArray(this String str)
        {
            return Encoding.GetEncoding(1251).GetBytes(str).Select(s => Convert.ToString(s, 2).PadLeft(8, '0'));
        }

        public static string ToStringFrom1251BinaryArray(this IEnumerable<string> str)
        {
            return Encoding.GetEncoding(1251).GetString(str.Select(s => Convert.ToByte(s, 2)).ToArray());
        }
    }
}
