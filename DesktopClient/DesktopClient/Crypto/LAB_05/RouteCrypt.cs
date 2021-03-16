using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Crypto.LAB_05
{
    public class RouteCrypt
    {
        private char[,] _table;

        public RouteCrypt(int key)
        {
            _table = new char[key, key];
        }

        private void FillTable(string text)
        {
            Array.Clear(_table, 0, _table.Length);
            var textEnumerator = text.GetEnumerator();

            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    if (!textEnumerator.MoveNext())
                    {
                        _table[i, j] = ' ';
                        continue;
                    }
                    _table[i, j] = textEnumerator.Current;
                }
            }
        }

        public string Crypt(string text)
        {
            if (text.Length > _table.Length)
            {
                return String.Empty;
            }

            FillTable(text);
            var result = new StringBuilder();
            var textEnumerator = text.GetEnumerator();
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    result.Append(_table[j, i]);
                }
            }

            return result.ToString().TrimEnd();
        }


    }
}
