using System;
using System.Collections.Generic;

public class Solution
{
    // Function to find all possible subset sums
    public List<int> IsSubsetPoss(int[] arr, int n, int sum)
    {
        bool[,] t = new bool[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) t[i, j] = false;
                if (j == 0) t[i, j] = true;
            }
        }

        // Fill the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                    t[i, j] = t[i - 1, j - arr[i - 1]] || t[i - 1, j];
                else
                    t[i, j] = t[i - 1, j];
            }
        }

        List<int> result = new List<int>(); // List to store all possible subset sums
        for (int j = 0; j <= sum; j++)
        {
            if (t[n, j]) result.Add(j); // Add all the sums which are possible
        }

        return result;
    }

    // Function to find the minimum subset sum difference
    public int MinSubsetSumDiff(int[] arr, int n)
    {
        int range = 0;
        for (int i = 0; i < n; i++)
        {
            range += arr[i]; // Calculate the total sum of the array
        }

        List<int> subsetSums = IsSubsetPoss(arr, n, range);
        int minDiff = int.MaxValue;

        // Find the minimum subset sum difference
        foreach (int sum in subsetSums)
        {
            minDiff = Math.Min(minDiff, Math.Abs(range - 2 * sum));
        }

        return minDiff;
    }

    public static void Main(string[] args)
    {
        // Input array
        int[] arr = { 1, 2, 3, 9 };
        
        Solution solution = new Solution();
        int result = solution.MinSubsetSumDiff(arr, arr.Length);

        Console.WriteLine(result); // Output: 3
    }
}
