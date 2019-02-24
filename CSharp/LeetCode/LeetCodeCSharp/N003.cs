using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    public class N003
    {
        [TestCase("abcabcbb", ExpectedResult = 3)]
        public int LengthOfLongestSubstring(string s)
        {
            var charArray = s.ToCharArray();
            int n = s.Length, ans = 0;
            int[] index = new int[128]; // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                i = Math.Max(index[charArray[j]], i);
                ans = Math.Max(ans, j - i + 1);
                index[charArray[j]] = j + 1;
            }
            return ans;
        }
    }
}