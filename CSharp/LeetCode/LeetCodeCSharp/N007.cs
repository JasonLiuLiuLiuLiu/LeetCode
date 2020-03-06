using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeCSharp
{
    class N007
    {
        public int Reverse(int x)
        {
            int max = 0x7fffffff;
            long b = 0;
            while (x != 0)
            {
                b = b * 10 + x % 10;
                x = x / 10;
            }
            return (int)((b > max || b < (-1 * (max + 1))) ? 0 : b);
        }
    }
}
