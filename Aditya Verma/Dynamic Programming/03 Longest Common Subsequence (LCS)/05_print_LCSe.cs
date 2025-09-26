https://www.geeksforgeeks.org/problems/print-all-lcs-sequences3413/1
# Things to rem:
    * First is same as LCSe.
    * During printing (last cell to gradually going up:
        1. If both string same then we add that subse. Then we add and the go one back (both row and col).
                       i--, j--
        2. If both not equal we go towards the greter elements cell.
                       when i-1 greater we go i--. Or else.
        3. By that we got subse in reverse (bottom up). So we reverse that to get the correct subsequence.


cpp:
GFG working code:
#include <vector>
#include <string>
#include <unordered_map>
#include <set>
#include <algorithm>
using namespace std;

struct pair_hash {
    size_t operator()(const pair<int,int>& p) const {
        return hash<int>()(p.first) ^ (hash<int>()(p.second) << 1);
    }
};

class Solution {
public:
    vector<string> allLCS(string &s1, string &s2) {
        int n = (int)s1.size();
        int m = (int)s2.size();

        // DP table for LCS length calculation
        vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));
        for (int i = 1; i <= n; ++i)
            for (int j = 1; j <= m; ++j)
                dp[i][j] = (s1[i-1] == s2[j-1]) ? 1 + dp[i-1][j-1] : max(dp[i-1][j], dp[i][j-1]);

        unordered_map<pair<int,int>, set<string>, pair_hash> memo;

        // Backtracking with memoization to get all LCS strings
        function<set<string>(int,int)> backtrack = [&](int i, int j) -> set<string> {
            if (i == 0 || j == 0) return {""};

            auto key = make_pair(i, j);
            if (memo.find(key) != memo.end()) return memo[key];

            if (s1[i-1] == s2[j-1]) {
                set<string> prev = backtrack(i-1, j-1);
                set<string> res;
                for (auto &str : prev)
                    res.insert(str + s1[i-1]);
                return memo[key] = res;
            } else {
                set<string> res;
                if (dp[i-1][j] >= dp[i][j-1]) {
                    set<string> top = backtrack(i-1, j);
                    res.insert(top.begin(), top.end());
                }
                if (dp[i][j-1] >= dp[i-1][j]) {
                    set<string> left = backtrack(i, j-1);
                    res.insert(left.begin(), left.end());
                }
                return memo[key] = res;
            }
        };

        set<string> lcs_set = backtrack(n, m);
        vector<string> lcs_list(lcs_set.begin(), lcs_set.end());
        sort(lcs_list.begin(), lcs_list.end());
        return lcs_list;
    }
};


Default:
#include <vector>
#include <string>
#include <algorithm>
using namespace std;

string lcs(string X, string Y) {
    int n = X.size();
    int m = Y.size();

    // DP table initialization
    vector<vector<int>> dp(n + 1, vector<int>(m + 1, 0));

    // Fill the DP table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= m; j++) {
            if (X[i - 1] == Y[j - 1]) {
                dp[i][j] = 1 + dp[i - 1][j - 1];
            } else {
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]);
            }
        }
    }

    // Reconstruct the LCS string
    int i = n, j = m;
    string lcs_str = "";
    while (i > 0 && j > 0) {
        if (X[i - 1] == Y[j - 1]) {
            lcs_str.push_back(X[i - 1]);
            i--;
            j--;
        } else if (dp[i - 1][j] > dp[i][j - 1]) {
            i--;
        } else {
            j--;
        }
    }

    // Reverse to get correct order
    reverse(lcs_str.begin(), lcs_str.end());
    return lcs_str;
}


       
py3:
GFG working code:

#User function Template for python3
class Solution:
    def allLCS(self, s1, s2):
        X, Y = s1, s2
        n, m = len(X), len(Y)
        
        # DP table initialization
        dp = [[0] * (m + 1) for _ in range(n + 1)]

        # Fill the DP table
        for i in range(1, n + 1):
            for j in range(1, m + 1):
                if X[i - 1] == Y[j - 1]:
                    dp[i][j] = 1 + dp[i - 1][j - 1]
                else:
                    dp[i][j] = max(dp[i - 1][j], dp[i][j - 1])
        
        from functools import lru_cache

        @lru_cache(maxsize=None)
        def backtrack(i, j):
            if i == 0 or j == 0:
                return {""}  # Base case: empty string
            elif X[i - 1] == Y[j - 1]:
                return {z + X[i - 1] for z in backtrack(i - 1, j - 1)}
            else:
                result = set()
                if dp[i - 1][j] >= dp[i][j - 1]:
                    result.update(backtrack(i - 1, j))
                if dp[i][j - 1] >= dp[i - 1][j]:
                    result.update(backtrack(i, j - 1))
                return result
        
        lcs_set = backtrack(n, m)
        lcs_list = list(lcs_set)
        lcs_list.sort()
        
        return lcs_list

        
Default:

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
