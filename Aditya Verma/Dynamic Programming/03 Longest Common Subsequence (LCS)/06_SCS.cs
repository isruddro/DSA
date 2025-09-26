https://www.geeksforgeeks.org/problems/shortest-common-supersequence0322/1

# Things to rem:
    Its too easy that only asked to print the length in int!
        So, from both string's length (n+m) if we substract the LCS length then we get SCS length!
    Its like a bag with both n and m elements and we just substract length of LCS to get 
            length of SCS.
            As: SCS Length = n + m - LCS Length

# Things to rem:
    It's sequence, so order matters here but not necessary continous.


cpp:
O(n × m) time, O(n × m) space, where n = len(s1) and m = len(s2).

#include <vector>
#include <string>
using namespace std;

class Solution {
public:
    // Function to find length of shortest common supersequence of two strings.
    int shortestCommonSupersequence(string s1, string s2) {
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

        // Step 2: Length of SCS = n + m - LCS
        return n + m - dp[n][m];
    }
};

py3:

O(n × m) time, O(n × m) space, where n = len(s1) and m = len(s2).
#User function Template for python3
class Solution:
    # Function to find length of shortest common supersequence of two strings.
    def shortestCommonSupersequence(self, s1, s2):
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
        
        # Step 2: Length of SCS = n + m - LCS
        return n + m - dp[n][m]



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

// Function to calculate SCS length
int SCSLength(const string &X, const string &Y) {
    int n = X.length();
    int m = Y.length();
    return n + m - LCS(X, Y, n, m);
}

int main() {
    string X, Y;
    getline(cin, X);
    getline(cin, Y);

    cout << SCSLength(X, Y) << endl;

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

    // Function to calculate SCS length
    public static int SCS(string X, string Y, int n, int m)
    {
        return n + m - LCS(X, Y, n, m); // Formula for SCS length
    }

    public static void Main()
    {
        string X = Console.ReadLine();
        string Y = Console.ReadLine();
        int n = X.Length, m = Y.Length;

        Console.WriteLine(SCS(X, Y, n, m));
    }
}
