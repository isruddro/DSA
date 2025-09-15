https://leetcode.com/problems/longest-common-subsequence/description/

#special about subsequence is: it counts with gaps too but needs to come one after another.

py:

def LCS(X: str, Y: str) -> int:
    n = len(X)
    m = len(Y)
    
    # Create DP table initialized to 0
    dp = [[0] * (m + 1) for _ in range(n + 1)]

    # Fill the DP table
    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if X[i - 1] == Y[j - 1]:
                dp[i][j] = 1 + dp[i - 1][j - 1]
            else:
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
    
    return dp[n][m]


if __name__ == "__main__":
    X = input().strip()
    Y = input().strip()
    
    result = LCS(X, Y)
    print(result)


cpp:
#include <iostream>
#include <string>
#include <vector>
#include <algorithm> // for std::max

using namespace std;

int LCS(const string &X, const string &Y, int n, int m) {
    vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));

    // Fill the DP table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= m; j++) {
            if (X[i - 1] == Y[j - 1])
                dp[i][j] = 1 + dp[i - 1][j - 1];
            else
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
        }
    }

    return dp[n][m];
}

int main() {
    string X, Y;
    getline(cin, X);
    getline(cin, Y);

    int result = LCS(X, Y, X.length(), Y.length());
    cout << result << endl;

    return 0;
}



c#:

using System;

public class Solution
{
    public static int LCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1]; // DP - matrix

        // base case initialization of dp matrix
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= m; j++)
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

        // Filling the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (X[i - 1] == Y[j - 1]) // when last characters are same
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else // when last characters are different, pick max
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[n, m];
    }

    public static void Main()
    {
        // Input strings
        string X = Console.ReadLine();
        string Y = Console.ReadLine();

        int n = X.Length, m = Y.Length;

        // Output the length of the Longest Common Subsequence
        Console.WriteLine(LCS(X, Y, n, m));
    }
}
