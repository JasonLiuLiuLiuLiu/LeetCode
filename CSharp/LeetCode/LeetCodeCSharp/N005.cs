using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    class N005
    {
        [TestCase("babad", ExpectedResult = "bab")]
        public string LongestPalindrome(string s)
        {
            var arrays = s.ToCharArray();
            string result = "";
            List<char> stack = new List<char>();
            for (int i = 0; i < arrays.Length; i++)
            {
                stack.Add(arrays[i]);
                var checkResult = CheckPalindrome(stack);
                if (checkResult != null && checkResult.Length > result.Length)
                {
                    result = checkResult;
                }
            }
            return result;
        }

        private string CheckPalindrome(List<char> stack)
        {
            List<char> result = new List<char>();
            int length = stack.Count;
            if (stack.Count > 1)
                for (int i = stack.Count - 1; i > -1; i--)
                {
                    var currentLength = length - i;
                    bool isPalindrome = false;
                    bool isDouble = false;
                    if (i - currentLength + 1 > 0)
                    {

                        for (int j = 0; j < currentLength; j++)
                        {
                            if (j == currentLength - 1)
                            {
                                isPalindrome = true;
                                break;
                            }
                            if ((i - currentLength + 1 + j) < 0)
                            {
                                break;
                            }
                            if (stack[length - 1 - j] != stack[i - currentLength + 1 + j])
                            {
                                break;
                            }

                        }
                    }

                    if (!isPalindrome && i - currentLength > 0)
                    {
                        for (int j = 0; j < currentLength; j++)
                        {
                            if (j == currentLength - 1)
                            {
                                isPalindrome = true;
                                isDouble = true;
                                break;
                            }

                            if ((i - currentLength + j) < 0)
                            {
                                break;
                            }

                            if (stack[length - 1 - j] != stack[i - currentLength + j])
                            {
                                break;
                            }

                        }
                    }

                    if (isPalindrome)
                    {
                        currentLength = currentLength * 2;
                        if (!isDouble)
                            currentLength = currentLength - 1;
                    }


                    if (isPalindrome && currentLength > result.Count)
                    {
                        result.Clear();
                        for (int j = 0; j < currentLength; j++)
                        {
                            result.Add(stack[length - currentLength + j]);
                        }
                    }
                }

            return result.ToString();
        }
    }
}
