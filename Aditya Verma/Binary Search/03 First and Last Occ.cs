using System;
using System.Collections.Generic;

class Program
{
    static int minIndex = int.MaxValue;
    static int maxIndex = int.MinValue;

    static void BinarySearch(int start, int end, List<int> nums, int target, bool leftBias)
    {
        if (start > end) return;

        int mid = (start + end) / 2;

        if (nums[mid] > target)
        {
            BinarySearch(start, mid - 1, nums, target, leftBias);
        }
        else if (nums[mid] < target)
        {
            BinarySearch(mid + 1, end, nums, target, leftBias);
        }
        else
        {
            if (leftBias)
            {
                minIndex = Math.Min(minIndex, mid);
                BinarySearch(start, mid - 1, nums, target, leftBias);
            }
            else
            {
                maxIndex = Math.Max(maxIndex, mid);
                BinarySearch(mid + 1, end, nums, target, leftBias);
            }
        }
    }

    static List<int> SearchRange(List<int> nums, int target)
    {
        BinarySearch(0, nums.Count - 1, nums, target, true);
        BinarySearch(0, nums.Count - 1, nums, target, false);

        if (minIndex == int.MaxValue) minIndex = -1;
        if (maxIndex == int.MinValue) maxIndex = -1;

        return new List<int> { minIndex, maxIndex };
    }

    static void Main()
    {
        List<int> nums = new List<int> { 5, 7, 7, 8, 8, 10 };
        int target = 8;

        List<int> result = SearchRange(nums, target);
        Console.WriteLine($"[{result[0]}, {result[1]}]");
    }
}
