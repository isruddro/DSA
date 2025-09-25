https://leetcode.com/problems/shortest-common-supersequence/description/

# Things to rem:
        Previous concepts apply here. Be flexible.
        In short:
                1. Code for SCS from LCS.
                2. During filling DP table, think of going last cell to gradually up and:
                            * If the same element then: i--, j--
                            * If not same then whereever we find greater element we go towards
                                that cell. if [a][b-1] greater then we go b--
                                    else: alternate
                3. Don't forget to reverse as during filling the DP we get in reverse!

py:
O(n × m) time, O(n × m) space, where n = len(str1) and m = len(str2).

        
class Solution:
    def shortestCommonSupersequence(self, str1: str, str2: str) -> str:
        def lcs_dp(X, Y):
            n, m = len(X), len(Y)
            dp = [[0] * (m + 1) for _ in range(n + 1)]

            for i in range(1, n + 1):
                for j in range(1, m + 1):
                    if X[i - 1] == Y[j - 1]:
                        dp[i][j] = 1 + dp[i - 1][j - 1]
                    else:
                        dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
            return dp

        def scs(X, Y):
            n, m = len(X), len(Y)
            dp = lcs_dp(X, Y)
            
            a, b = n, m
            scs_str = []

            # Backtracking to build SCS
            while a > 0 and b > 0:
                if X[a - 1] == Y[b - 1]:
                    scs_str.append(X[a - 1])
                    a -= 1
                    b -= 1
                elif dp[a][b - 1] > dp[a - 1][b]:
                    scs_str.append(Y[b - 1])
                    b -= 1
                else:
                    scs_str.append(X[a - 1])
                    a -= 1

            # Add remaining characters
            while a > 0:
                scs_str.append(X[a - 1])
                a -= 1
            while b > 0:
                scs_str.append(Y[b - 1])
                b -= 1

            return ''.join(reversed(scs_str))

        return scs(str1, str2)



cpp:
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

// Function to calculate the Longest Common Subsequence (LCS)
vector<vector<int>> LCS_DP(const string &X, const string &Y) {
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
    return dp;
}

// Function to build the Shortest Common Supersequence (SCS)
string SCS(const string &X, const string &Y) {
    int n = X.size();
    int m = Y.size();
    vector<vector<int>> dp = LCS_DP(X, Y);

    int a = n, b = m;
    string scs;

    // Backtracking to build SCS
    while (a > 0 && b > 0) {
        if (X[a - 1] == Y[b - 1]) {
            scs.push_back(X[a - 1]);
            a--; b--;
        } else if (dp[a][b - 1] > dp[a - 1][b]) {
            scs.push_back(Y[b - 1]);
            b--;
        } else {
            scs.push_back(X[a - 1]);
            a--;
        }
    }

    // Add remaining characters
    while (a > 0) {
        scs.push_back(X[a - 1]);
        a--;
    }
    while (b > 0) {
        scs.push_back(Y[b - 1]);
        b--;
    }

    reverse(scs.begin(), scs.end());
    return scs;
}

int main() {
    string X, Y;
    getline(cin, X);
    getline(cin, Y);

    cout << SCS(X, Y) << endl;

    return 0;
}






c#:

using System;
using System.Text;

class Program
{
    // Function to calculate the Shortest Common Supersequence (SCS)
    static string SCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1]; // DP matrix

        // Initialize the DP matrix
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0;
            }
        }

        // Fill the DP matrix based on LCS logic
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

        // Backtrack to build the Shortest Common Supersequence
        int a = n, b = m;
        StringBuilder scs = new StringBuilder();
        while (a > 0 && b > 0)
        {
            if (X[a - 1] == Y[b - 1])
            {
                scs.Append(X[a - 1]);
                a--;
                b--;
            }
            else if (dp[a, b - 1] > dp[a - 1, b])
            {
                scs.Append(Y[b - 1]);
                b--;
            }
            else
            {
                scs.Append(X[a - 1]);
                a--;
            }
        }

        // Add remaining characters from X or Y
        // Printing can end at the middle somewhere so:
        while (a > 0)
        {
            scs.Append(X[a - 1]);
            a--;
        }
        while (b > 0)
        {
            scs.Append(Y[b - 1]);
            b--;
        }

        // Reverse the result string
        char[] result = scs.ToString().ToCharArray();
        Array.Reverse(result);
        return new string(result);
    }

    static void Main()
    {
        // Read the input strings
        string X = Console.ReadLine();
        string Y = Console.ReadLine();
        int n = X.Length, m = Y.Length;

        // Call the SCS function and output the result
        Console.WriteLine(SCS(X, Y, n, m));
    }
}
