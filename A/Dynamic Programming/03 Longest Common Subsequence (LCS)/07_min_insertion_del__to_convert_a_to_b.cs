https://www.geeksforgeeks.org/problems/minimum-number-of-deletions-and-insertions0209/1

Too easy to rem:
    What is common to both str? Of course their LCS! Just keep in mind.
    * Think about this: why we need to delete or insert? Cos, both str are not same sized!
    * From the longer str length we substract LCS length (common seq) = deletion number!
    * From the shorter string length we substract the LCS length (common seq) = insertion number!

        As:
            deletions = n - lcs_len;
            insertions = m - lcs_len;

cpp:
O(n × m) time, O(n × m) space, where n = len(s1) and m = len(s2).
#include <vector>
#include <string>
using namespace std;

class Solution {
public:
    int minOperations(string s1, string s2) {
        string X = s1, Y = s2;
        int n = X.size();
        int m = Y.size();

        // Step 1: Compute LCS DP table
        vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                if (X[i - 1] == Y[j - 1]) {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                } else {
                    dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        int lcs_len = dp[n][m];

        // Step 2: Minimum deletions and insertions
        int deletions = n - lcs_len;
        int insertions = m - lcs_len;

        return deletions + insertions;
    }
};

py3:
O(n × m) time, O(n × m) space, where n = len(s1) and m = len(s2).


#User function Template for python3
class Solution:
    def minOperations(self, s1, s2):
        X, Y = s1, s2
        n, m = len(X), len(Y)
        
        # Step 1: Compute LCS DP table
        dp = [[0] * (m + 1) for _ in range(n + 1)]
        for i in range(1, n + 1):
            for j in range(1, m + 1):
                if X[i - 1] == Y[j - 1]:
                    dp[i][j] = 1 + dp[i - 1][j - 1]
                else:
                    dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
        
        lcs_len = dp[n][m]
        
        # Step 2: Minimum deletions and insertions
        deletions = n - lcs_len
        insertions = m - lcs_len
        
        return deletions + insertions



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
