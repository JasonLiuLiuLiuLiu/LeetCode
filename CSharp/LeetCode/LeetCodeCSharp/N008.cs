using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    class N008
    {
        [TestCase("42", ExpectedResult = 42)]
        [TestCase("  -42", ExpectedResult = -42)]
        [TestCase("4193 with words", ExpectedResult = 4193)]
        [TestCase("words and 987", ExpectedResult = 0)]
        [TestCase("-91283472332", ExpectedResult = Int32.MinValue)]
        [TestCase("3.14159", ExpectedResult = 3)]
        [TestCase("  +3", ExpectedResult = 3)]
        public int MyAtoi(string str)
        {

            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                return 0;

            str = str.TrimStart();
            bool isNegative = str[0] == '-';



            if (isNegative && str.Length > 1)
            {
                str = str.Substring(1, str.Length - 1);
            }

            if (str[0]=='+')
            {
                str = str.Substring(1, str.Length - 1);
            }

            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                return 0;

            var endIndex = 0;

            for (int i = 0; i < str.Length; i++)
            {
                endIndex = i;
                if (str[i] < 48 || str[i] > 57)
                {
                    endIndex--;
                    break;
                }
            }

            if (endIndex < 0)
            {
                return 0;
            }

            if (Int32.TryParse(str.Substring(0, endIndex + 1), out var result))
            {
                return isNegative ? -result : result;
            }
            else
            {
                return isNegative ? Int32.MinValue : Int32.MaxValue;
            }


            return 0;
        }
    }
}
