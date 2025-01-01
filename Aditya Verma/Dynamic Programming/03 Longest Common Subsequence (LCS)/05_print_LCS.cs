using System;
using System.Collections.Generic;

public class Solution
{
    public static string LCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1]; // DP matrix

        // Initialize the DP table
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= m; j++)
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

        // Fill the DP table
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

        // Reconstruct the LCS from the DP table
        int x = n, y = m;
        List<char> lcs = new List<char>();
        while (x > 0 && y > 0)
        {
            if (X[x - 1] == Y[y - 1])
            {
                lcs.Add(X[x - 1]); // Push the character to the list
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
                x--;
            else
                y--;
        }

        lcs.Reverse(); // Reverse the list to get the correct LCS
        return new string(lcs.ToArray()); // Convert the list to a string
    }

    public static void Main()
    {
        string X = Console.ReadLine();
        string Y = Console.ReadLine();
        int n = X.Length, m = Y.Length;

        Console.WriteLine(LCS(X, Y, n, m));
    }
}
