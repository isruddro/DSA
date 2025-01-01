using System;
using System.Collections.Generic;

public class Solution
{
    // Recursive helper function to generate all subsets
    private void GetSorted(List<int> op, List<int> nums, List<List<int>> result)
    {
        // If no numbers left in nums, add the current subset (op) to the result
        if (nums.Count == 0)
        {
            result.Add(new List<int>(op));
            return;
        }

        // Include the first element of nums in the current subset (op)
        List<int> op1 = new List<int>(op);
        op1.Add(nums[0]);

        // Exclude the first element of nums from the current subset (op)
        List<int> op2 = new List<int>(op);

        // Remove the first element of nums (simulating taking it out)
        nums.RemoveAt(0);

        // Recurse with the two choices: including or excluding the first element
        GetSorted(op1, nums, result); // Including
        GetSorted(op2, nums, result); // Excluding

        // Restore the nums list after recursion (backtrack)
        nums.Insert(0, op[0]);
    }

    // Function to generate all subsets of nums
    public IList<IList<int>> Subsets(IList<int> nums)
    {
        List<int> op = new List<int>();
        List<List<int>> result = new List<List<int>>();
        GetSorted(op, new List<int>(nums), result);
        return result;
    }
}
