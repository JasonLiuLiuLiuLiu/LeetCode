using System;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    class N009
    {
        [TestCase(121, ExpectedResult = true)]
        [TestCase(1121, ExpectedResult = false)]
        [TestCase(-121, ExpectedResult = false)]
        public bool IsPalindrome_old(int x)
        {
            if (x < 0)
            {
                return false;
            }

            var length = x.ToString().Length;

            if (length == 1)
                return true;

            for (int i = 0; i <= length; i++)
            {
                var j = length - i - 1;

                if (j < i)
                    break;

                if (GetValue(x, i) != GetValue(x, j))
                    return false;
            }

            return true;

        }

        public bool IsPalindrome(int x)
        {
            // 特殊情况：
            // 如上所述，当 x < 0 时，x 不是回文数。
            // 同样地，如果数字的最后一位是 0，为了使该数字为回文，
            // 则其第一位数字也应该是 0
            // 只有 0 满足这一属性
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = revertedNumber * 10 + x % 10;
                x /= 10;
            }

            // 当数字长度为奇数时，我们可以通过 revertedNumber/10 去除处于中位的数字。
            // 例如，当输入为 12321 时，在 while 循环的末尾我们可以得到 x = 12，revertedNumber = 123，
            // 由于处于中位的数字不影响回文（它总是与自己相等），所以我们可以简单地将其去除。
            return x == revertedNumber || x == revertedNumber / 10;
        }

        private int GetValue(int inValue, int index)
        {
            return (int)((inValue % Math.Pow(10, index + 1)) / Math.Pow(10, index));
        }
    }
}
