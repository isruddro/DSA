using System;

class Program
{
    // Function to compute the length of the Longest Common Subsequence (LCS)
    static int LCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1]; // DP matrix

        // Initialize the DP matrix
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= m; j++)
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

        // Fill the DP matrix based on LCS logic
        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= m; j++)
                if (X[i - 1] == Y[j - 1]) // When last character is same
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else // When last character is not the same -> pick max
                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i - 1, j]);

        return dp[n, m];
    }

    // Function to compute the Longest Palindromic Subsequence (LPS)
    static int LPS(string X, int n)
    {
        string rev_X = new string(X.ToCharArray().Reverse().ToArray());
        return LCS(X, rev_X, n, n);
    }

    // Function to compute the minimum insertions required to make the string a palindrome
    static int MinInsertForPalindrome(string X, int n)
    {
        return n - LPS(X, n);
    }

    static void Main()
    {
        string X = Console.ReadLine();
        int n = X.Length;

        Console.WriteLine(MinInsertForPalindrome(X, n));
    }
}
