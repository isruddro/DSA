using System;

public class Solution
{
    public int CountSubsets(int[] arr, int n, int sum)
    {
        int[,] dp = new int[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) dp[i, j] = 0; // No items, 0 subsets with non-zero sum
                if (j == 0) dp[i, j] = 1; // Sum is zero, always one subset (empty set)
            }
        }

        // Fill the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                {
                    // Include the current item or exclude it
                    dp[i, j] = dp[i - 1, j - arr[i - 1]] + dp[i - 1, j];
                }
                else
                {
                    // Exclude the current item
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        return dp[n, sum];
    }

    public static void Main(string[] args)
    {
        // Input array and sum
        int[] arr = { 2, 3, 5, 6, 8, 10 };
        int sum = 10;

        Solution solution = new Solution();
        int result = solution.CountSubsets(arr, arr.Length, sum);

        Console.WriteLine(result); // Output: 3
    }
}
