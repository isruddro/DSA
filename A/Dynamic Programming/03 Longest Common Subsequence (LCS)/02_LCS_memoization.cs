# We only make table for memo in which the variable changes. Here its n and m. Both reducing.
    So we made dp table of n, m. dp[n][m]

* For dp table:
    Normally 2D matrix last cell has: n-1, m-1. But if we want to put n and m we need to add extra 1.
    Thats why for input 1000 for both n and m. We adding 1 to it and it becomes 1001 for both n and m.


py:

import sys
sys.setrecursionlimit(10**6)  # Increase recursion limit if strings are large

class Solution:
    D = 1001  # Maximum dimension for dp table

    def __init__(self):
        # Initialize dp table with -1
        self.dp = [[-1 for _ in range(self.D)] for _ in range(self.D)]

    def LCS(self, X: str, Y: str, n: int, m: int) -> int:
        # Base case
        if n == 0 or m == 0:
            return 0

        # If already computed
        if self.dp[n][m] != -1:
            return self.dp[n][m]

        if X[n - 1] == Y[m - 1]:
            self.dp[n][m] = 1 + self.LCS(X, Y, n - 1, m - 1)
        else:
            self.dp[n][m] = max(self.LCS(X, Y, n - 1, m), self.LCS(X, Y, n, m - 1))

        return self.dp[n][m]


if __name__ == "__main__":
    X = input().strip()
    Y = input().strip()

    solution = Solution()
    result = solution.LCS(X, Y, len(X), len(Y))
    print(result)

        

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
