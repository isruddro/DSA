https://www.geeksforgeeks.org/problems/longest-palindromic-subsequence-1612327878/1

# Things to rem:
    Here only one str? How can we apply LCS?
        Well just reverse the string to get new str = B and then apply LCS for both A and B.
            As:
                A = A str
                B = reverse(A str)
cpp:
O(n²) time, O(n²) space, where n = len(s).
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

class Solution {
public:
    int longestPalinSubseq(string s) {
        string X = s;
        string rev_X = X;
        reverse(rev_X.begin(), rev_X.end());
        int n = X.size();

        // DP table for LCS between X and its reverse
        vector<vector<int>> dp(n + 1, vector<int>(n + 1, 0));

        // Fill DP table
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= n; j++) {
                if (X[i - 1] == rev_X[j - 1]) {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                } else {
                    dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        return dp[n][n];
    }
};


py3:
O(n²) time, O(n²) space, where n = len(s).


#User function Template for python3
class Solution:
    def longestPalinSubseq(self, s):
        X = s
        rev_X = X[::-1]
        n = len(X)
        
        # DP table for LCS between X and its reverse
        dp = [[0] * (n + 1) for _ in range(n + 1)]

        # Fill DP table
        for i in range(1, n + 1):
            for j in range(1, n + 1):
                if X[i - 1] == rev_X[j - 1]:
                    dp[i][j] = 1 + dp[i - 1][j - 1]
                else:
                    dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
        
        return dp[n][n]



cpp:

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

// Function to calculate the LCS of two strings
int LCS(const string &X, const string &Y) {
    int n = X.size();
    int m = Y.size();
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

// Function to calculate the Longest Palindromic Subsequence
int LPS(const string &X) {
    string rev_X = X;
    reverse(rev_X.begin(), rev_X.end());
    return LCS(X, rev_X);
}

int main() {
    string X;
    getline(cin, X);

    cout << LPS(X) << endl;

    return 0;
}



c#:

using System;

class Program
{
    // Function to calculate the LCS
    static int LCS(string X, string Y, int n, int m)
    {
        // Create a DP matrix for storing lengths of longest common subsequence.
        int[,] dp = new int[n + 1, m + 1];

        // Fill the dp matrix based on LCS logic.
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0; // Base case initialization
                else if (X[i - 1] == Y[j - 1]) // When characters match
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else // When characters do not match, take max of top and left cell
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        // Return the length of LCS for the full strings.
        return dp[n, m];
    }

    // Function to calculate LPS (Longest Palindromic Subsequence)
    static int LPS(string X, int n)
    {
        // Reverse the string
        string rev_X = new string(X.ToCharArray().Reverse().ToArray());

        // Return the LCS of the string and its reverse
        return LCS(X, rev_X, n, n);
    }

    static void Main(string[] args)
    {
        // Read the input string
        string X = Console.ReadLine();
        int n = X.Length;

        // Call the LPS function and output the result
        Console.WriteLine(LPS(X, n));
    }
}
