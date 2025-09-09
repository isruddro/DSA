py:

def lcs_length(X, Y):
    n, m = len(X), len(Y)
    dp = [[0] * (m + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if X[i - 1] == Y[j - 1]:
                dp[i][j] = 1 + dp[i - 1][j - 1]
            else:
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
    
    return dp[n][m]

def min_insert_delete(X, Y):
    n, m = len(X), len(Y)
    lcs_len = lcs_length(X, Y)
    
    deletions = n - lcs_len  # Characters to delete from X
    insertions = m - lcs_len # Characters to insert into X
    
    print(f"Deletions: {deletions}")
    print(f"Insertions: {insertions}")
    print(f"Total Operations: {deletions + insertions}")

# Example usage
X = input()
Y = input()
min_insert_delete(X, Y)




cpp:

#include <iostream>
#include <string>
#include <vector>
using namespace std;

// Function to calculate LCS length
int LCS(const string &X, const string &Y, int n, int m) {
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

// Function to calculate minimum insertions and deletions
void MinInsertDel(const string &X, const string &Y) {
    int n = X.length();
    int m = Y.length();
    int lcs_len = LCS(X, Y, n, m);

    int deletions = n - lcs_len;  // Characters to delete from X
    int insertions = m - lcs_len; // Characters to insert into X

    cout << "Deletions: " << deletions << endl;
    cout << "Insertions: " << insertions << endl;
    cout << "Total Operations: " << (deletions + insertions) << endl;
}

int main() {
    string X, Y;
    getline(cin, X);
    getline(cin, Y);

    MinInsertDel(X, Y);

    return 0;
}




c#:

using System;

public class Solution
{
    // Function to calculate LCS length
    public static int LCS(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1];

        // Base case initialization
        for (int i = 0; i <= n; i++)
            for (int j = 0; j <= m; j++)
                if (i == 0 || j == 0)
                    dp[i, j] = 0;

        // Fill DP table for LCS
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

        return dp[n, m];
    }

    // Function to calculate the minimum insertions and deletions
    public static void MinInsertDel(string X, string Y, int n, int m)
    {
        int lcs_len = LCS(X, Y, n, m);
        
        int deletions = n - lcs_len; // Deletions required
        int insertions = m - lcs_len; // Insertions required

        Console.WriteLine("Deletions: " + deletions);
        Console.WriteLine("Insertions: " + insertions);
        Console.WriteLine("Total Operations: " + (deletions + insertions));
    }

    public static void Main()
    {
        string X = Console.ReadLine();
        string Y = Console.ReadLine();
        int n = X.Length, m = Y.Length;

        MinInsertDel(X, Y, n, m);
    }
}
