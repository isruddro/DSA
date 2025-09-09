cpp:
#include <iostream>
#include <string>
#include <algorithm> // for std::max
#include <vector>

using namespace std;

class Solution {
public:
    static const int D = 1001;
    int dp[D][D];

    // Recursive function with memoization to calculate LCS
    int LCS(const string &X, const string &Y, int n, int m) {
        // Base case
        if (n == 0 || m == 0)
            return 0;

        // If already computed
        if (dp[n][m] != -1)
            return dp[n][m];

        if (X[n - 1] == Y[m - 1])
            dp[n][m] = 1 + LCS(X, Y, n - 1, m - 1);
        else
            dp[n][m] = max(LCS(X, Y, n - 1, m), LCS(X, Y, n, m - 1));

        return dp[n][m];
    }
};

int main() {
    string X, Y;
    getline(cin, X);
    getline(cin, Y);

    Solution solution;

    // Initialize dp array with -1
    for (int i = 0; i < Solution::D; i++)
        for (int j = 0; j < Solution::D; j++)
            solution.dp[i][j] = -1;

    int result = solution.LCS(X, Y, X.length(), Y.length());
    cout << result << endl;

    return 0;
}



c#:

using System;

public class Solution
{
    // Memoization table
    private const int D = 1001;
    private int[,] dp = new int[D, D];

    // Recursive function with memoization to calculate the Longest Common Subsequence (LCS)
    public int LCS(string X, string Y, int n, int m)
    {
        // Base case: If either string is empty
        if (n == 0 || m == 0)
            return 0;

        // If the result is already computed, return it
        if (dp[n, m] != -1)
            return dp[n, m];

        // When last characters are the same, add 1 to the LCS of the remaining substrings
        if (X[n - 1] == Y[m - 1])
            dp[n, m] = 1 + LCS(X, Y, n - 1, m - 1);
        else
            // When last characters are not the same, take the max of excluding one character from either string
            dp[n, m] = Math.Max(LCS(X, Y, n - 1, m), LCS(X, Y, n, m - 1));

        return dp[n, m];
    }

    public static void Main(string[] args)
    {
        // Input strings
        string X = Console.ReadLine();
        string Y = Console.ReadLine();

        int n = X.Length;
        int m = Y.Length;

        // Create solution object
        Solution solution = new Solution();

        // Initialize the dp array with -1 (indicating uncomputed values)
        for (int i = 0; i < D; i++)
        {
            for (int j = 0; j < D; j++)
            {
                solution.dp[i, j] = -1;
            }
        }

        // Compute and output the LCS length
        int result = solution.LCS(X, Y, n, m);
        Console.WriteLine(result);
    }
}
