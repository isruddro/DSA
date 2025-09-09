py:

def lcs(X, Y):
    n, m = len(X), len(Y)
    dp = [[0] * (m + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if X[i - 1] == Y[j - 1]:
                dp[i][j] = 1 + dp[i - 1][j - 1]
            else:
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
    return dp[n][m]

def longest_palindromic_subsequence(X):
    rev_X = X[::-1]
    return lcs(X, rev_X)

def min_deletions_to_palindrome(X):
    n = len(X)
    return n - longest_palindromic_subsequence(X)

# Example usage
X = input()
print(min_deletions_to_palindrome(X))



cpp:
#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
using namespace std;

// Function to calculate LCS (Longest Common Subsequence)
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

// Function to calculate LPS (Longest Palindromic Subsequence)
int LPS(const string &X) {
    string rev_X = X;
    reverse(rev_X.begin(), rev_X.end());
    return LCS(X, rev_X);
}

// Function to calculate minimum deletions to make the string a palindrome
int MinDelForPalindrome(const string &X) {
    int n = X.size();
    return n - LPS(X);
}

int main() {
    string X;
    getline(cin, X);

    cout << MinDelForPalindrome(X) << endl;

    return 0;
}






c#:

using System;

class Program
{
    // Function to calculate the LCS (Longest Common Subsequence)
    static int LCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1]; // DP - matrix

        // Initialize the dp matrix
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0;
            }
        }

        // Fill the dp matrix based on LCS logic
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (X[i - 1] == Y[j - 1]) // When characters match
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else // When characters don't match, take max of top and left cell
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        // Return the length of LCS for the full strings
        return dp[n, m];
    }

    // Function to calculate LPS (Longest Palindromic Subsequence)
    static int LPS(string X, int n)
    {
        string rev_X = new string(X.ToCharArray().Reverse().ToArray()); // Reverse the string
        return LCS(X, rev_X, n, n); // LCS between the original string and its reverse
    }

    // Function to calculate minimum deletions to make the string a palindrome
    static int MinDelForPalindrome(string X, int n)
    {
        return n - LPS(X, n); // Minimum deletions = length of string - LPS length
    }

    static void Main(string[] args)
    {
        // Read the input string
        string X = Console.ReadLine();
        int n = X.Length;

        // Call the MinDelForPalindrome function and output the result
        Console.WriteLine(MinDelForPalindrome(X, n));
    }
}
