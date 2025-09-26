https://leetcode.com/problems/longest-common-subsequence/description/
Bottom up:
    We just initialize every cell of the table with zero. And on the loop we start from the
    second to last for both row and column and we keep filling the dp table later when we
    recursively find any elements, so everything is inside the table.
cpp:
O(n × m) time, O(n × m) space, where n = len(text1) and m = len(text2).

#include <vector>
#include <string>
#include <algorithm>  // For std::max
using namespace std;

class Solution {
public:
    int longestCommonSubsequence(string text1, string text2) {
        string X = text1, Y = text2;
        int n = X.size();
        int m = Y.size();

        // Create DP table initialized to 0
        vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));

        // Fill the DP table
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                if (X[i - 1] == Y[j - 1]) {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                } else {
                    dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        return dp[n][m];
    }
};

py3:

O(n × m) time, O(n × m) space, where n = len(text1) and m = len(text2).

class Solution:
    def longestCommonSubsequence(self, text1: str, text2: str) -> int:
        X, Y = text1, text2
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
