using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LeetCodeCSharp
{
    //给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。

    //如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。

    //您可以假设除了数字 0 之外，这两个数都不会以 0 开头。

    //示例：

    //输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
    //输出：7 -> 0 -> 8
    //原因：342 + 465 = 807
    public class N002
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }

        [Test()]
        public void Test()
        {
            var l1 = new ListNode(9);
            var l2 = new ListNode(1);
            l2.next = new ListNode(9);
            var resultNode = AddTwoNumbers(l1, l2);

            Assert.AreEqual(resultNode.val, 1);
            Assert.AreEqual(resultNode.next.val, 8);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var list = new List<int>(l1.val + l2.val);
            int deep = 1;
            while (l1.next != null || l2.next != null)
            {
                var l1V = 0;
                if (l1.next != null)
                {
                    l1 = l1.next;
                    l1V = l1.val;
                }

                var l2v = 0;
                if (l2.next != null)
                {
                    l2 = l2.next;

                    l2v = l2.val;
                }
                list.Add(l1V + l2v);
            }

            var resultCharArray = resultValue.ToString().ToCharArray();
            ListNode result = new ListNode(resultCharArray[resultCharArray.Length - 1] - '0');
            var currentNode = result;
            for (int i = resultCharArray.Length - 2; i > -1; i--)
            {
                currentNode.next = new ListNode(resultCharArray[i] - '0');
                currentNode = currentNode.next;
            }

            return result;
        }
    }
}