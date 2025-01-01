using System;

class Program
{
    static int SearchInsert(int[] nums, int target)
    {
        int start = 0, end = nums.Length - 1;
        int ans = nums.Length; // If the target is greater than all elements, it should be inserted at the end.

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] < target)
                start = mid + 1;
            else
            {
                if (ans == nums.Length || nums[mid] < nums[ans])
                    ans = mid;

                end = mid - 1;
            }
        }

        return ans;
    }

    static void Main()
    {
        int[] nums = { 1, 3, 5, 6 };
        int target = 5;

        int result = SearchInsert(nums, target);
        Console.WriteLine($"Insert position for {target} is {result}");
    }
}
