package site.iblogs;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

public class N004 {
    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        if (nums1 == null || nums1.length == 0)
        {
            return GetFromSingleArray(nums2);
        }

        if (nums2 == null || nums2.length == 0)
        {
            return GetFromSingleArray(nums1);
        }

        int index1 = nums1.length;
        int index2 = nums2.length;

        List<Integer> ordered=new LinkedList<>();

        int max = Math.max(index1, index2);

        for (int i = 0; i < max; i++)
        {
            if (i < nums1.length && i < nums2.length)
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
            else if(i < nums1.length)
            {
                PushItemToList(ordered,nums1[i]);
            }
            else {
                PushItemToList(ordered,nums2[i]);
            }
        }


        return GetFromSingleArray(ordered.stream().mapToInt(Integer::intValue).toArray());
    }

    private void PushItemToList(List<Integer> ordered, int value) {
        if (ordered.size() == 0) {
            ordered.add(value);
            return;
        }

        if (ordered.get(ordered.size() - 1) < value) {
            ordered.add(value);
            return;
        }

        for (int i = ordered.size() - 2; i > -1; i--) {
            if (ordered.get(i) <= value) {
                ordered.add(i + 1, value);
                return;
            }
        }

        ordered.add(0, value);
    }


    private double GetFromSingleArray(int[] nums) {
        if (nums.length % 2 == 0) {
            return (double) (nums[nums.length / 2] + nums[nums.length / 2 - 1]) / 2;
        } else {
            return nums[nums.length / 2];
        }
    }
}