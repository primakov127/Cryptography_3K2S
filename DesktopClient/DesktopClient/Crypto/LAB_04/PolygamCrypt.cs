using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Crypto.LAB_04
{
    public class PolygamCrypt
    {
        private int[,] _codesTable;
        private List<char> _alphabetArray;

        public PolygamCrypt(string alphabet)
        {
            _alphabetArray = new List<char>(alphabet.ToLower().ToCharArray());
            _codesTable = new int[alphabet.Length, alphabet.Length];
            CodesTableInit();
        }

        private void CodesTableInit()
        {
            int code = 1;
            for (int i = 0; i < _alphabetArray.Count; i++)
            {
                for (int j = 0; j < _alphabetArray.Count; j++)
                {
                    _codesTable[i, j] = code++;
                }
            }
        }

        private void GetCodesTableIndex(int code, out int row, out int column)
        {
            row = -1;
            column = -1;

            for (int i = 0; i < _alphabetArray.Count; i++)
            {
                for (int j = 0; j < _alphabetArray.Count; j++)
                {
                    if (code == _codesTable[i, j])
                    {
                        row = i;
                        column = j;
                        return;
                    }
                }
            }
        }

        private IEnumerable<string> Split(string str, int num)
        {
            while (str.Length > 0)
            {
                yield return new string(str.Take(num).ToArray());
                str = new string(str.Skip(num).ToArray());
            }
        }

        public string Encrypt(string text)
        {
            string smallText = text.ToLower();
            if (smallText.Length % 2 != 0)
            {
                smallText = String.Concat(smallText.Append(_alphabetArray[0]));
            }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < smallText.Length; i += 2)
            {
                int rowIndex = _alphabetArray.FindIndex(ch => ch.Equals(smallText[i]));
                int columnIndex = _alphabetArray.FindIndex(ch => ch.Equals(smallText[i + 1]));
                int code = _codesTable[rowIndex, columnIndex];
                result.Append(code.ToString("0000"));
            }

            return result.ToString();
        }

        public string Decrypt(string text)
        {
            string smallText = text.ToLower();
            StringBuilder result = new StringBuilder();
            int row = -1;
            int column = -1;

            foreach (var code in Split(smallText, 4))
            {
                GetCodesTableIndex(Int32.Parse(code), out row, out column);
                result.Append(_alphabetArray[row]);
                result.Append(_alphabetArray[column]);
            }

            return result.ToString();
        }
    }
}
