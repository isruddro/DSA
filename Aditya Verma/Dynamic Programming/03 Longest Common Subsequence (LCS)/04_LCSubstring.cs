https://www.geeksforgeeks.org/problems/longest-common-substring1452/1

# Things to rem:
    same as LCSe but: whenever we found any discontinuty on two strings we put zero and 
    recursion loop over.
        As:
            a b c d e
            a b f c e
            1+1+0 = here the moment last two char did not match, we put zero and move on.
                Here, two strings were abc and abf. last chars c and f did not match.

cpp:
O(n × m) time, O(n × m) space, where n = len(nums1) and m = len(nums2).
#include <vector>
#include <string>
#include <algorithm> // for std::max
using namespace std;

class Solution {
public:
    int longestCommonSubstr(string s1, string s2) {
        string X = s1, Y = s2;
        int n = X.size();
        int m = Y.size();

        // Create DP table
        vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));
        int mx = 0; // maximum length of common substring

        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= m; j++) {
                if (i == 0 || j == 0) {
                    dp[i][j] = 0;
                } else if (X[i - 1] == Y[j - 1]) {
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                } else {
                    dp[i][j] = 0;
                }
                mx = max(mx, dp[i][j]);
            }
        }

        return mx;
    }
};

py3:

O(n × m) time, O(n × m) space, where n = len(nums1) and m = len(nums2).

#User function Template for python3
class Solution:
    def longestCommonSubstr(self, s1, s2):
        X, Y = s1, s2
        n = len(X)
        m = len(Y)
        
        # Create DP table
        dp = [[0] * (m + 1) for _ in range(n + 1)]
        mx = 0  # maximum length of common substring

        for i in range(n + 1):
            for j in range(m + 1):
                if i == 0 or j == 0:
                    dp[i][j] = 0
                elif X[i - 1] == Y[j - 1]:
                    dp[i][j] = 1 + dp[i - 1][j - 1]
                else:
                    dp[i][j] = 0
                mx = max(mx, dp[i][j])
        
        return mx



cpp:

#include <iostream>
#include <string>
#include <vector>
#include <algorithm> // for std::max

using namespace std;

int LCSubstr(const string &X, const string &Y, int n, int m) {
    vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));
    int mx = 0; // maximum length of common substring

    for (int i = 0; i <= n; i++) {
        for (int j = 0; j <= m; j++) {
            if (i == 0 || j == 0)
                dp[i][j] = 0;
            else if (X[i - 1] == Y[j - 1])
                dp[i][j] = 1 + dp[i - 1][j - 1];
            else
                dp[i][j] = 0;

            mx = max(mx, dp[i][j]);
        }
    }

    return mx;
}

int main() {
    string X, Y;
    getline(cin, X);
    getline(cin, Y);

    int result = LCSubstr(X, Y, X.length(), Y.length());
    cout << result << endl;

    return 0;
}


c#:

using System;

public class Solution
{
    public static int LCSubstr(string X, string Y, int n, int m)
    {
        int[,] dp = new int[n + 1, m + 1]; // DP matrix
        int mx = int.MinValue;

        // Filling the DP table
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= m; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0;
                else if (X[i - 1] == Y[j - 1])
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = 0;

                mx = Math.Max(mx, dp[i, j]); // Update max length of common substring
            }
        }

        return mx;
    }

    public static void Main()
    {
        string X = Console.ReadLine();
        string Y = Console.ReadLine();

        int n = X.Length, m = Y.Length;

        // Output the length of the Longest Common Substring
        Console.WriteLine(LCSubstr(X, Y, n, m));
    }
}
