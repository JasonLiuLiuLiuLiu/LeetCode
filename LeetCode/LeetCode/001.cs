using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    //    给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。

    //    你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

    //    示例:

    //    给定 nums = [2, 7, 11, 15], target = 9

    //因为 nums[0] + nums[1] = 2 + 7 = 9
    //所以返回[0, 1]
    internal class _001
    {
        [Test]
        [TestCase(new int[] { 3, 3 }, 6)]
        public int[] TwoSum(int[] nums, int target)
        {
            var numsDic = new Dictionary<int, List<KeyValuePair<int, int>>>(nums.Length);

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= target)
                {
                    if (!numsDic.ContainsKey(nums[i]))
                        numsDic.Add(nums[i], new List<KeyValuePair<int, int>>(2));
                    numsDic[nums[i]].Add(new KeyValuePair<int, int>(nums[i], i));
                }
            }

            foreach (var keyValuePair in numsDic)
            {
                if (numsDic.ContainsKey(target - keyValuePair.Key))
                {
                    var otherKey = target - keyValuePair.Key;
                    if (otherKey != keyValuePair.Key)
                        return new[] { keyValuePair.Value[0].Value, numsDic[otherKey][0].Value };
                    else
                    {
                        if (numsDic[otherKey].Count != 1)
                            return new int[] { numsDic[otherKey][0].Value, numsDic[otherKey][1].Value };
                    }
                }
            }

            return null;
        }
    }
}