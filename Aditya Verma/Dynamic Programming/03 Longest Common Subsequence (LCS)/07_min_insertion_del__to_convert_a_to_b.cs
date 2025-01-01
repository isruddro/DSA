using System;

public class Solution
{
    // Function to calculate LCS length
    public static int LCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1];

        // Base case initialization
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= m; j++)
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

        // Fill DP table for LCS
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (X[i - 1] == Y[j - 1])
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[n, m];
    }

    // Function to calculate the minimum insertions and deletions
    public static void MinInsertDel(string X, string Y, int n, int m)
    {
        int lcs_len = LCS(X, Y, n, m);
        
        int deletions = n - lcs_len; // Deletions required
        int insertions = m - lcs_len; // Insertions required

        Console.WriteLine("Deletions: " + deletions);
        Console.WriteLine("Insertions: " + insertions);
        Console.WriteLine("Total Operations: " + (deletions + insertions));
    }

    public static void Main()
    {
        string X = Console.ReadLine();
        string Y = Console.ReadLine();
        int n = X.Length, m = Y.Length;

        MinInsertDel(X, Y, n, m);
    }
}
