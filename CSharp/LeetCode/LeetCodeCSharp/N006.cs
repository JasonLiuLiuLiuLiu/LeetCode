using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    class N006
    {
        [TestCase("LEETCODEISHIRING", 4, ExpectedResult = "LDREOEIIECIHNTSG")]
        [TestCase("",1,ExpectedResult = "")]
        [TestCase("AB", 1, ExpectedResult = "AB")]
        public string Convert(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s))
                return s;
            if (numRows == 1)
                return s;
            List<char?>[] store = new List<char?>[numRows];
            for (var i = 0; i < store.Length; i++)
            {
                store[i]=new List<char?>();
            }
            var charArray = s.ToCharArray();
            int x = 0, y = 0;

            bool down = true;

            for (int i = 0; i < s.Length; i++)
            {
                SetValueToStore(charArray[i], x, y, store);
                if (down)
                {
                    y++;
                    if (y == numRows)
                    {
                        down = false;
                        y-=2;
                        x++;
                    }
                }
                else
                {
                    y--;
                    x++;
                    if (y < 0)
                    {
                        down = true;
                        y+=2;
                        x--;
                    }
                }
            }

            List<char> resultChar = new List<char>();

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < store[i].Count; j++)
                {
                    if (store[i][j] != null)
                    {
                        resultChar.Add(store[i][j].Value);
                    }
                }
            }

            return new string(resultChar.ToArray());

        }

        private void SetValueToStore(char value, int x, int y, List<char?>[] store)
        {
            while (store[y].Count < x + 1)
            {
                store[y].Add(null);
            }
            store[y][x] = value;
        }
    }
}
