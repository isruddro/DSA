# Things to rem:
    * First is same as LCSe.
    * During printing (last cell to gradually going up:
        1. If both string same then we add that subse. Then we go one back (both row and col).
                       i--, j--
        2. If both not equal we go towards the greter elements cell.
                       when i-1 greater we go i--. Or else.
        3. By that we a subse in reverse. So we reverse that to get the correct subsequence.



py:

def lcs(X, Y):
    n = len(X)
    m = len(Y)
    
    # DP table initialization
    dp = [[0] * (m + 1) for _ in range(n + 1)]

    # Fill the DP table
    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if X[i - 1] == Y[j - 1]:
                dp[i][j] = 1 + dp[i - 1][j - 1]
            else:
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])

    # Reconstruct the LCS string
    i, j = n, m
    lcs_str = []
    while i > 0 and j > 0:
        if X[i - 1] == Y[j - 1]:
            lcs_str.append(X[i - 1])
            i -= 1
            j -= 1
        elif dp[i - 1][j] > dp[i][j - 1]:
            i -= 1
        else:
            j -= 1

    # Reverse to get correct order
    lcs_str.reverse()
    return ''.join(lcs_str)

# Example usage
X = input()
Y = input()
print(lcs(X, Y))


cpp:

#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

string LCS(const string &X, const string &Y, int n, int m) {
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

    // Reconstruct the LCS string
    int x = n, y = m;
    string lcs = "";
    while (x > 0 && y > 0) {
        if (X[x - 1] == Y[y - 1]) {
            lcs.push_back(X[x - 1]);
            x--;
            y--;
        }
        else if (dp[x - 1][y] > dp[x][y - 1])
            x--;
        else
            y--;
    }

    reverse(lcs.begin(), lcs.end()); // Reverse to get correct order
    return lcs;
}

int main() {
    string X, Y;
    getline(cin, X);
    getline(cin, Y);

    cout << LCS(X, Y, X.length(), Y.length()) << endl;

    return 0;
}


c#:

using System;
using System.Collections.Generic;

public class Solution
{
    public static string LCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1]; // DP matrix

        // Initialize the DP table
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= m; j++)
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

        // Fill the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (X[i - 1] == Y[j - 1])
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }

        // Reconstruct the LCS from the DP table
        int x = n, y = m;
        List<char> lcs = new List<char>();
        while (x > 0 && y > 0)
        {
            if (X[x - 1] == Y[y - 1])
            {
                lcs.Add(X[x - 1]); // Push the character to the list
                x--;
                y--;
            }
            else if (dp[x - 1, y] > dp[x, y - 1])
                x--;
            else
                y--;
        }

        lcs.Reverse(); // Reverse the list to get the correct LCS
        return new string(lcs.ToArray()); // Convert the list to a string
    }

    public static void Main()
    {
        string X = Console.ReadLine();
        string Y = Console.ReadLine();
        int n = X.Length, m = Y.Length;

        Console.WriteLine(LCS(X, Y, n, m));
    }
}
