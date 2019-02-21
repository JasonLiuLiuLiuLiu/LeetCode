using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class N001
    {
        [TestCase(new[] { 3, 3 }, 6, ExpectedResult = new[] { 0, 1 })]
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