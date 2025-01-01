using System;

public class Solution
{
    // Function to count the subsets with a given sum
    public int CountSubsetsWithSum(int[] arr, int n, int sum)
    {
        int[,] t = new int[n + 1, sum + 1]; // DP matrix
        t[0, 0] = 1; // Base case: There's one way to make sum 0 (empty subset)

        // Initialize first column (for all sums of 0, there is 1 way: the empty subset)
        for (int i = 1; i <= n; i++)
        {
            t[i, 0] = 1; // There is one way to make sum 0: by not including any elements
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

    // Function to count the subsets with the target sum based on the given difference
    public int TargetSum(int[] arr, int n, int diff)
    {
        int sumOfArray = 0;
        for (int i = 0; i < n; i++)
        {
            sumOfArray += arr[i]; // Sum of all elements in the array
        }

        // If (sumOfArray + diff) is odd, there's no valid solution
        if ((sumOfArray + diff) % 2 != 0)
            return 0;

        // Reduce the problem to counting subsets with sum (sumOfArray + diff) / 2
        return CountSubsetsWithSum(arr, n, (sumOfArray + diff) / 2);
    }

    public static void Main(string[] args)
    {
        // Input array and target sum (diff)
        int[] arr = { 1, 1, 2, 3 };
        int diff = 1;

        Solution solution = new Solution();
        int result = solution.TargetSum(arr, arr.Length, diff);

        Console.WriteLine(result); // Output: 3
    }
}
