https://leetcode.com/problems/minimum-insertion-steps-to-make-a-string-palindrome/description/

# Things to rem:
    * We need extra char from the total string to make a LPS palindrome,
        that is why we substract LPS from n to get insertion number.
    * Rest of the process is same like LPS previous problem.

cpp:
Time Complexity: O(n²) — DP for LCS between string and its reverse.

Space Complexity: O(n²) — full DP table stored.

#include <vector>
#include <string>
#include <algorithm>
using namespace std;

class Solution {
public:
    int minInsertions(string s) {
        int n = (int)s.size();

        // Function to compute LCS length between X and Y
        auto LCS = [](const string &X, const string &Y, int n, int m) -> int {
            vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));

            for (int i = 1; i <= n; ++i) {
                for (int j = 1; j <= m; ++j) {
                    if (X[i - 1] == Y[j - 1]) {
                        dp[i][j] = 1 + dp[i - 1][j - 1];
                    } else {
                        dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
                    }
                }
            }
            return dp[n][m];
        };

        // Function to compute Longest Palindromic Subsequence length
        auto LPS = [&](const string &X, int n) -> int {
            string rev_X = X;
            reverse(rev_X.begin(), rev_X.end());
            return LCS(X, rev_X, n, n);
        };

        // Minimum insertions = string length - length of LPS
        int MinInsertForPalindrome = n - LPS(s, n);

        return MinInsertForPalindrome;
    }
};


py3:
Time Complexity: O(n²) — DP for LCS between string and its reverse.

Space Complexity: O(n²) — full DP table stored.

class Solution:
    def minInsertions(self, s: str) -> int:
        n = len(s)
        
        # Function to compute the length of the Longest Common Subsequence (LCS)
        def LCS(X, Y, n, m):
            dp = [[0 for _ in range(m + 1)] for _ in range(n + 1)]
            
            for i in range(1, n + 1):
                for j in range(1, m + 1):
                    if X[i - 1] == Y[j - 1]:
                        dp[i][j] = 1 + dp[i - 1][j - 1]
                    else:
                        dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
            return dp[n][m]

        # Function to compute the Longest Palindromic Subsequence (LPS)
        def LPS(X, n):
            rev_X = X[::-1]
            return LCS(X, rev_X, n, n)

        # Function to compute the minimum insertions required to make the string a palindrome
        def MinInsertForPalindrome(X, n):
            return n - LPS(X, n)

        return MinInsertForPalindrome(s, n)

        


cpp:
#include <bits/stdc++.h>
using namespace std;

// Function to compute the length of the Longest Common Subsequence (LCS)
int LCS(const string &X, const string &Y) {
    int n = X.length();
    int m = Y.length();
    vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));

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

// Function to compute the Longest Palindromic Subsequence (LPS)
int LPS(const string &X) {
    string rev_X = X;
    reverse(rev_X.begin(), rev_X.end());
    return LCS(X, rev_X);
}

// Function to compute the minimum insertions required to make the string a palindrome
int MinInsertForPalindrome(const string &X) {
    return X.length() - LPS(X);
}

int main() {
    string X;
    cin >> X;

    cout << MinInsertForPalindrome(X) << endl;

    return 0;
}



c#:

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
