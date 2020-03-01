
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCodeCSharp
{
    class N004
    {


       
        [TestCase(new[] { 1, 2 }, new[] { 1, 1 }, ExpectedResult = 1.0)]
        [TestCase(new[] { 1 }, new[] { 2, 3 }, ExpectedResult = 2)]
        [TestCase(new[] { 1 }, new[] { 2, 3, 4 }, ExpectedResult = 2.5)]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4 }, new[] { 1, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4 }, ExpectedResult = 3.0)]
        [TestCase(new[] { 2,3 }, new[] { 1,4,5 }, ExpectedResult = 3)]
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums1.Length == 0)
            {
                return GetFromSingleArray(nums2);
            }

            if (nums2 == null || nums2.Length == 0)
            {
                return GetFromSingleArray(nums1);
            }

            var index1 = nums1.Length;
            var index2 = nums2.Length;

            List<int> ordered=new List<int>(nums1.Length+nums2.Length);

            var max = index1 > index2 ? index1 : index2;

            for (int i = 0; i < max; i++)
            {
                if (i < nums1.Length && i < nums2.Length)
                {
                    if (nums1[i] < nums2[i])
                    {
                        PushItemToList(ordered,nums1[i]);
                        PushItemToList(ordered,nums2[i]);
                    }
                    else
                    {
                        PushItemToList(ordered, nums2[i]);
                        PushItemToList(ordered, nums1[i]);
                    }
                }
                else if(i<nums1.Length&&i>=nums2.Length)
                {
                    PushItemToList(ordered,nums1[i]);
                }
                else if(i>=nums1.Length&&i<nums2.Length)
                {
                    PushItemToList(ordered,nums2[i]);
                }
            }

            return GetFromSingleArray(ordered.ToArray());
        }

        private void PushItemToList(List<int> ordered,int value)
        {
            if (ordered.Count == 0)
            {
                ordered.Add(value);
                return;
            }

            if (ordered[ordered.Count - 1] < value)
            {
                ordered.Add(value);
                return;
            }

            for (int i = ordered.Count-2; i >-1; i--)
            {
                if (ordered[i] <= value)
                {
                    ordered.Insert(i + 1,value);
                    return;
                }
            }

            ordered.Insert(0,value);
        }



        private double GetFromSingleArray(int[] nums)
        {
            if (nums.Length % 2 == 0)
            {
                return (double)(nums[nums.Length / 2] + nums[nums.Length / 2 - 1]) / 2;
            }
            else
            {
                return nums[nums.Length / 2];
            }
        }


    }
}
