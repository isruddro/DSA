https://leetcode.com/problems/is-subsequence/description/

# Things to rem:
    We can solve this q using recursion too!
    But its better to know the LCS connection.

        * Logic is simple: 
            Return after checking, if the shorter str is the LCS of both.
py:

def LCS(X, Y):
    n = len(X)
    m = len(Y)
    dp = [[0] * (m + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if X[i - 1] == Y[j - 1]:
                dp[i][j] = 1 + dp[i - 1][j - 1]
            else:
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
    return dp[n][m]

def SeqPatternMatching(X, Y):
    return LCS(X, Y) == min(len(X), len(Y))

# Example usage
X = input()
Y = input()

print("YES" if SeqPatternMatching(X, Y) else "NO")


        

cpp:

#include <bits/stdc++.h>
using namespace std;

int LCS(string X, string Y, int n, int m) {
    int dp[n + 1][m + 1]; // DP matrix

    // base case of recursion --> for initialization of dp matrix
    for (int i = 0; i <= n; i++)
        for (int j = 0; j <= m; j++)
            if (i == 0 || j == 0)
                dp[i][j] = 0;

    for (int i = 1; i <= n; i++)
        for (int j = 1; j <= m; j++)
            if (X[i - 1] == Y[j - 1])
                dp[i][j] = 1 + dp[i - 1][j - 1];
            else
                dp[i][j] = max(dp[i][j - 1], dp[i - 1][j]);

    return dp[n][m];
}

bool SeqPatternMatching(string X, string Y, int n, int m) {
    return LCS(X, Y, n, m) == min(n, m); // If LCS equals length of the shorter string, Y is a subsequence of X
}

signed main() {
    string X, Y; 
    cin >> X >> Y; 
    int n = X.length(), m = Y.length();

    // Output result based on the SeqPatternMatching result
    cout << (SeqPatternMatching(X, Y, n, m) ? "YES\n" : "NO\n");
    return 0;
}
