using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    class N010
    {
        /// <summary>
        /// 正则表达式匹配
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        [TestCase("aba", "a*", ExpectedResult = false)]
        [TestCase("aba", "a*b", ExpectedResult = false)]
        [TestCase("aba", "a*a", ExpectedResult = false)]
        [TestCase("aa", "a", ExpectedResult = false)]
        [TestCase("aab", "a*", ExpectedResult = true)]
        [TestCase("ab", ".*", ExpectedResult = true)]
        [TestCase("aab", "c*a*b", ExpectedResult = true)]
        [TestCase("mississippi", "mis*is*p*.", ExpectedResult = false)]
        [TestCase("abcd", "p*.", ExpectedResult = false)]

        public bool IsMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p))
            {
                return false;
            }

            var pChar = p.ToCharArray();
            var sChar = s.ToCharArray();

            var sCharIndex = 0;
            int pCharIndex;

            for (pCharIndex = 0; pCharIndex < pChar.Length; pCharIndex++)
            {
                if (sCharIndex >= sChar.Length)
                {
                    break;
                }
                var currentP = pChar[pCharIndex];
                switch (currentP)
                {
                    case '*':
                        if (pCharIndex + 1 == pChar.Length)
                        {
                            return sCharIndex == sChar.Length;
                        }
                        for (; sCharIndex < sChar.Length; sCharIndex++)
                        {
                            if (sChar[sCharIndex] != pChar[pCharIndex - 1])
                            {
                                break;
                            }
                        }
                        break;
                    case '.':
                        sCharIndex++;
                        break;
                    default:
                        if (sChar[sCharIndex] == pChar[pCharIndex])
                        {
                            sCharIndex++;
                        }
                        else if (pCharIndex + 1 < pChar.Length && pChar[pCharIndex + 1] == '*')
                        {
                            break;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
            }

            return pCharIndex == pChar.Length && sCharIndex == sChar.Length;
        }
    }
}
