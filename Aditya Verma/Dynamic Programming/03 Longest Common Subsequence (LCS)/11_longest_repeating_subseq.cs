https://www.geeksforgeeks.org/problems/longest-repeating-subsequence2004/1


py:

def LRS(X):
    n = len(X)
    dp = [[0] * (n + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        for j in range(1, n + 1):
            # Characters match and indices are different
            if X[i - 1] == X[j - 1] and i != j:
                dp[i][j] = 1 + dp[i - 1][j - 1]
            else:
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])

    return dp[n][n]

# Example usage
X = input()
print(LRS(X))



cpp:
#include <iostream>
#include <vector>
#include <string>
using namespace std;

// Function to calculate Longest Repeated Subsequence (LRS)
int LRS(const string &X) {
    int n = X.size();
    vector<vector<int>> dp(n + 1, vector<int>(n + 1, 0));

    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= n; j++) {
            // Characters match and indices are different
            if (X[i - 1] == X[j - 1] && i != j)
                dp[i][j] = 1 + dp[i - 1][j - 1];
            else
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
        }
    }

    return dp[n][n];
}

int main() {
    string X;
    getline(cin, X);

    cout << LRS(X) << endl;

    return 0;
}




c#:

using System;

class Program
{
    // Function to calculate Longest Repeated Subsequence (LRS)
    static int LCS(string X, int n)
    {
        int[,] dp = new int[n + 1, n + 1]; // DP matrix

        // Fill the DP matrix
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

                // i and j can't be same so:
                else if (X[i - 1] == X[j - 1] && i != j)
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        return dp[n, n];
    }

    static void Main()
    {
        // Read the input string
        string X = Console.ReadLine();
        int n = X.Length;

        // Call the LCS function and output the result
        Console.WriteLine(LCS(X, n));
    }
}
