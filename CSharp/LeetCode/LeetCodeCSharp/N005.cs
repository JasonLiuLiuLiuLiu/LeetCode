using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    class N005
    {
        //5. 最长回文子串
        //  给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。
        [TestCase("bab", ExpectedResult = "bab")]
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }

            var store = new bool[s.Length, s.Length];

            string result = "";

            for (int len = 1; len <= s.Length; len++)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    var j = i + len - 1; 

                    if (j >= s.Length)
                    {
                        break;
                    }

                    if (i == j || i + 1 == j||(s[i] == s[j]&&store[i+1,j-1]))
                    {
                        store[i, j] = true;
                    }

                    if (store[i, j] && len > result.Length)
                    {
                        result = s.Substring(i, len);
                    }
                }
            }

            return result;
        }
    }
}
