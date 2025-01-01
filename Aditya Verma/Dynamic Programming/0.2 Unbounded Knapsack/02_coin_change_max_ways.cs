using System;

public class Solution
{
    // Function to calculate the maximum number of ways to make change
    public int GetMaxNumberOfWays(int[] coins, int n, int sum)
    {
        int[,] dp = new int[n + 1, sum + 1];

        // Initialization: fill dp table
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0)
                    dp[i, j] = 0; // No ways to make change with 0 coins
                if (j == 0)
                    dp[i, j] = 1; // There's one way to make change for sum 0 (pick no coins)
            }
        }

        // Fill dp table based on the recurrence relation
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (coins[i - 1] <= j)
                    dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i - 1]]; // Include or exclude the current coin
                else
                    dp[i, j] = dp[i - 1, j]; // Exclude the current coin
            }
        }

        return dp[n, sum]; // Return the maximum number of ways to make change
    }

    public static void Main(string[] args)
    {
        // Input: number of coins
        int n = int.Parse(Console.ReadLine());
        int[] coins = new int[n];

        // Input: coin denominations
        string[] coinsInput = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
            coins[i] = int.Parse(coinsInput[i]);

        // Input: target sum
        int sum = int.Parse(Console.ReadLine());

        // Create solution object and calculate the maximum number of ways
        Solution solution = new Solution();
        int result = solution.GetMaxNumberOfWays(coins, n, sum);

        // Output the result
        Console.WriteLine(result);
    }
}
