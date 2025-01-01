using System;

public class Solution
{
    // Function to count the subsets with a given sum
    public int CountSubsetsWithSum(int[] arr, int n, int sum)
    {
        int[,] t = new int[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) t[i, j] = 0;
                if (j == 0) t[i, j] = 1;
            }
        }

        // DP filling
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                    t[i, j] = t[i - 1, j - arr[i - 1]] + t[i - 1, j];
                else
                    t[i, j] = t[i - 1, j];
            }
        }

        return t[n, sum];
    }

    // Function to count the subsets with a given difference
    public int CountSubsetsWithDiff(int[] arr, int n, int diff)
    {
        int sumOfArray = 0;
        for (int i = 0; i < n; i++)
        {
            sumOfArray += arr[i]; // Sum of all elements in the array
        }

        // If (sumOfArray + diff) is odd, there is no valid subset
        if ((sumOfArray + diff) % 2 != 0)
            return 0;

        // Count subsets with sum (sumOfArray + diff) / 2
        return CountSubsetsWithSum(arr, n, (sumOfArray + diff) / 2);
    }

    public static void Main(string[] args)
    {
        // Input array
        int[] arr = { 1, 1, 2, 3 };

        Solution solution = new Solution();
        int diff = 1;
        int result = solution.CountSubsetsWithDiff(arr, arr.Length, diff);

        Console.WriteLine(result); // Output: 3
    }
}
