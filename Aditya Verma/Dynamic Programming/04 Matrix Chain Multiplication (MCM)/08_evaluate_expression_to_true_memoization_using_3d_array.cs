https://www.geeksforgeeks.org/problems/boolean-parenthesization5610/1

cpp:
Time Complexity: O(N^3), Space Complexity: O(N^2)
    
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    int countWays(string s) {
        int n = s.size();
        int MAX = n + 1;

        // dp[isTrue][i][j]
        vector<vector<vector<int>>> dp(2, vector<vector<int>>(MAX, vector<int>(MAX, -1)));

        function<int(string&, int, int, bool)> solve = [&](string &X, int i, int j, bool is_true) {
            int idx = is_true ? 1 : 0;

            if (i > j) return 0;

            if (i == j) {
                dp[idx][i][j] = ((X[i] == 'T' && is_true) || (X[i] == 'F' && !is_true)) ? 1 : 0;
                return dp[idx][i][j];
            }

            if (dp[idx][i][j] != -1) return dp[idx][i][j];

            int ans = 0;
            for (int k = i + 1; k < j; k += 2) {
                int l_T = solve(X, i, k - 1, true);
                int l_F = solve(X, i, k - 1, false);
                int r_T = solve(X, k + 1, j, true);
                int r_F = solve(X, k + 1, j, false);

                if (X[k] == '|') {
                    if (is_true)
                        ans += l_T * r_T + l_T * r_F + l_F * r_T;
                    else
                        ans += l_F * r_F;
                } else if (X[k] == '&') {
                    if (is_true)
                        ans += l_T * r_T;
                    else
                        ans += l_T * r_F + l_F * r_T + l_F * r_F;
                } else if (X[k] == '^') {
                    if (is_true)
                        ans += l_T * r_F + l_F * r_T;
                    else
                        ans += l_T * r_T + l_F * r_F;
                }
            }

            dp[idx][i][j] = ans;
            return ans;
        };

        return solve(s, 0, n - 1, true);
    }
};

py3:

class Solution:
    def countWays(self, s):
        n = len(s)
        MAX = n + 1
        dp = [[[-1 for _ in range(MAX)] for _ in range(MAX)] for _ in range(2)]  # dp[isTrue][i][j]

        def solve(X, i, j, is_true):
            idx = 1 if is_true else 0

            if i > j:
                return 0
            if i == j:
                dp[idx][i][j] = 1 if (X[i] == 'T' and is_true) or (X[i] == 'F' and not is_true) else 0
                return dp[idx][i][j]

            if dp[idx][i][j] != -1:
                return dp[idx][i][j]

            ans = 0
            for k in range(i + 1, j, 2):
                l_T = solve(X, i, k - 1, True)
                l_F = solve(X, i, k - 1, False)
                r_T = solve(X, k + 1, j, True)
                r_F = solve(X, k + 1, j, False)

                if X[k] == '|':
                    ans += l_T * r_T + l_T * r_F + l_F * r_T if is_true else l_F * r_F
                elif X[k] == '&':
                    ans += l_T * r_T if is_true else l_T * r_F + l_F * r_T + l_F * r_F
                elif X[k] == '^':
                    ans += l_T * r_F + l_F * r_T if is_true else l_T * r_T + l_F * r_F

            dp[idx][i][j] = ans
            return ans

        return solve(s, 0, n - 1, True)



cpp:
#include <bits/stdc++.h>
using namespace std;

int dp[2][1001][1001]; // dp[isTrue][i][j]

// Recursive function with 3D DP
int Solve(const string &X, int i, int j, bool isTrue) {
    if (i >= j) {
        dp[isTrue ? 1 : 0][i][j] = (isTrue ? X[i] == 'T' : X[i] == 'F') ? 1 : 0;
        return dp[isTrue ? 1 : 0][i][j];
    }

    if (dp[isTrue ? 1 : 0][i][j] != -1)
        return dp[isTrue ? 1 : 0][i][j];

    int ans = 0;
    for (int k = i + 1; k < j; k += 2) {
        int l_T = Solve(X, i, k - 1, true);
        int l_F = Solve(X, i, k - 1, false);
        int r_T = Solve(X, k + 1, j, true);
        int r_F = Solve(X, k + 1, j, false);

        if (X[k] == '|') {
            ans += isTrue ? l_T * r_T + l_T * r_F + l_F * r_T : l_F * r_F;
        } else if (X[k] == '&') {
            ans += isTrue ? l_T * r_T : l_T * r_F + l_F * r_T + l_F * r_F;
        } else if (X[k] == '^') {
            ans += isTrue ? l_T * r_F + l_F * r_T : l_T * r_T + l_F * r_F;
        }
    }

    return dp[isTrue ? 1 : 0][i][j] = ans;
}

int main() {
    string X;
    cin >> X;

    // Initialize dp array to -1
    memset(dp, -1, sizeof(dp));

    cout << Solve(X, 0, X.size() - 1, true) << endl;
    return 0;
}




c#:

using System;

class BooleanParenthesization
{
    // Create a 3D array to store the results of subproblems (dp[0/1][i][j])
    static int[,,] dp = new int[2, 1001, 1001];

    static int Solve(string X, int i, int j, bool isTrue)
    {
        // Base case: if i >= j, check if the character matches the expected value
        if (i >= j)
        {
            if (isTrue)
                dp[1, i, j] = (X[i] == 'T') ? 1 : 0;
            else
                dp[0, i, j] = (X[i] == 'F') ? 1 : 0;
            return dp[isTrue ? 1 : 0, i, j];
        }

        // If the result is already computed, return it
        if (dp[isTrue ? 1 : 0, i, j] != -1)
            return dp[isTrue ? 1 : 0, i, j];

        int ans = 0;

        // Loop through all the operators in the expression
        for (int k = i + 1; k < j; k += 2)
        {
            // Calculate the number of ways to evaluate the left and right substrings
            int l_T = Solve(X, i, k - 1, true);
            int l_F = Solve(X, i, k - 1, false);
            int r_T = Solve(X, k + 1, j, true);
            int r_F = Solve(X, k + 1, j, false);

            // Evaluate based on the operator
            if (X[k] == '|')
            {
                if (isTrue)
                    ans += l_T * r_T + l_T * r_F + l_F * r_T;
                else
                    ans += l_F * r_F;
            }
            else if (X[k] == '&')
            {
                if (isTrue)
                    ans += l_T * r_T;
                else
                    ans += l_T * r_F + l_F * r_T + l_F * r_F;
            }
            else if (X[k] == '^')
            {
                if (isTrue)
                    ans += l_T * r_F + l_F * r_T;
                else
                    ans += l_T * r_T + l_F * r_F;
            }
        }

        // Store the result for the current subproblem
        dp[isTrue ? 1 : 0, i, j] = ans;
        return ans;
    }

    static void Main()
    {
        string X = Console.ReadLine(); // Read input string

        // Initialize dp array to -1 (not calculated state)
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 1001; j++)
                for (int k = 0; k < 1001; k++)
                    dp[i, j, k] = -1;

        // Call Solve function with true as the target
        Console.WriteLine(Solve(X, 0, X.Length - 1, true));
    }
}
