using System;

public class Solution
{
    // Function to calculate the maximum profit from cutting the rod
    public int GetMaxProfit(int[] length, int[] price, int n, int L)
    {
        int[,] dp = new int[n + 1, L + 1]; // DP table

        // Initializing the DP table
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= L; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0;
            }
        }

        // Filling the DP table based on the recurrence relation
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= L; j++)
            {
                if (length[i - 1] <= j)
                    dp[i, j] = Math.Max(dp[i - 1, j], price[i - 1] + dp[i, j - length[i - 1]]);
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }

        return dp[n, L]; // Return the maximum profit
    }

    public static void Main(string[] args)
    {
        // Input number of different lengths
        int n = int.Parse(Console.ReadLine());
        int[] length = new int[n];
        int[] price = new int[n];

        // Input lengths
        string[] lengthsInput = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
            length[i] = int.Parse(lengthsInput[i]);

        // Input prices
        string[] pricesInput = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
            price[i] = int.Parse(pricesInput[i]);

        // Input total length of the rod
        int L = int.Parse(Console.ReadLine());

        // Create solution object and calculate maximum profit
        Solution solution = new Solution();
        int result = solution.GetMaxProfit(length, price, n, L);

        // Output the result
        Console.WriteLine(result);
    }
}
