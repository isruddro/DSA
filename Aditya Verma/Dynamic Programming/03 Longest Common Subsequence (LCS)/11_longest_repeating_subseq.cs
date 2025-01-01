using System;

class Program
{
    // Function to calculate Longest Repeated Subsequence (LRS)
    static int LCS(string X, int n)
    {
        int[,] dp = new int[n + 1, n + 1]; // DP matrix

        // Fill the DP matrix
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

                // i and j can't be same so:
                else if (X[i - 1] == X[j - 1] && i != j)
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[n, n];
    }

    static void Main()
    {
        // Read the input string
        string X = Console.ReadLine();
        int n = X.Length;

        // Call the LCS function and output the result
        Console.WriteLine(LCS(X, n));
    }
}
