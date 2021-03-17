using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Crypto.LAB_05
{
    public class MultiPermCrypt
    {
        private List<char> _alphabetArray;
        private List<int> _key1;
        private List<int> _key2;
        private char[,] _table;

        public MultiPermCrypt(string alphabet, string key1, string key2)
        {
            _alphabetArray = new List<char>(alphabet.ToLower().ToCharArray());
            _table = new char[key1.Length, key2.Length];
            _key1 = GetKey(key1.ToLower());
            _key2 = GetKey(key2.ToLower());
        }

        // BAD ALGORITHM :(
        private List<int> GetKey(string key)
        {
            var charList = _alphabetArray.Intersect(key).ToList();
            var result = new List<int>();
            foreach (var ch in key)
            {
                result.Add(charList.IndexOf(ch));
            }
            for (int i = 0; i < result.Count; i++)
            {
                var nums = result.FindAll(x => x == result[i]);
                if (nums.Count > 1)
                {
                    while (nums.Count > 1)
                    {
                        int index = result.FindLastIndex(x => x == nums[0]);
                        result[index]++;
                        nums = result.FindAll(x => x == result[i]);
                    }

                }
            }
            return result;
        }

        private string GetString(char[,] table)
        {
            var result = new StringBuilder();
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                for (int j = 0; j < _table.GetLength(1); j++)
                {
                    result.Append(_table[i, j]);
                }
            }
            return result.ToString().TrimEnd();
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

        private void SortTableColumn()
        {
            char[,] result = new char[_key1.Count, _key2.Count];
            int columnIndex = -1;
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                columnIndex = _key1.IndexOf(i);
                Array.Copy(_table, columnIndex * _table.GetLength(1), result, i * result.GetLength(1), _table.GetLength(1));

            }
            _table = result;
        }

        private void SortTableRow()
        {
            char[,] result = new char[_key1.Count, _key2.Count];
            int rowIndex = -1;
            for (int i = 0; i < _table.GetLength(1); i++)
            {
                rowIndex = _key2.IndexOf(i);
                for (int j = 0; j < _table.GetLength(0); j++)
                {
                    result[j, i] = _table[j, rowIndex];
                }
            }
            _table = result;
        }

        private void UnsortTableColumn()
        {
            char[,] result = new char[_key1.Count, _key2.Count];
            int columnIndex = -1;
            for (int i = 0; i < _table.GetLength(0); i++)
            {
                columnIndex = _key1.IndexOf(i);
                Array.Copy(_table, i * _table.GetLength(1), result, columnIndex * result.GetLength(1), _table.GetLength(1));

            }
            _table = result;
        }

        private void UnsortTableRow()
        {
            char[,] result = new char[_key1.Count, _key2.Count];
            int rowIndex = -1;
            for (int i = 0; i < _table.GetLength(1); i++)
            {
                rowIndex = _key2.IndexOf(i);
                for (int j = 0; j < _table.GetLength(0); j++)
                {
                    result[j, rowIndex] = _table[j, i];
                }
            }
            _table = result;
        }

        public string Encrypt(string text)
        {
            string result = String.Empty;
            if (text.Length > _table.Length)
            {
                return result;
            }

            FillTable(text);
            SortTableRow();
            SortTableColumn();
            result = GetString(_table);

            return result;
        }

        public string Decrypt(string text)
        {
            string result = String.Empty;
            if (text.Length > _table.Length)
            {
                return result;
            }

            FillTable(text);
            UnsortTableColumn();
            UnsortTableRow();
            result = GetString(_table);

            return result;
        }
    }
}
