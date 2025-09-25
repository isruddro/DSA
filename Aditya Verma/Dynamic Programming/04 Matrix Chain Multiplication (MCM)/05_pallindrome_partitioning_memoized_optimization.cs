https://www.geeksforgeeks.org/problems/palindromic-patitioning4845/1

py:
Working code:
class Solution:
    def palPartition(self, X):
        n = len(X)
        # Precompute palindrome table
        is_pal = [[False]*n for _ in range(n)]
        for i in range(n):
            is_pal[i][i] = True
        for i in range(n-1):
            is_pal[i][i+1] = (X[i] == X[i+1])
        for length in range(3, n+1):
            for i in range(n-length+1):
                j = i + length - 1
                is_pal[i][j] = (X[i] == X[j]) and is_pal[i+1][j-1]

        # dp[i] = min cuts for substring X[0:i+1]
        dp = [0]*n
        for i in range(n):
            if is_pal[0][i]:
                dp[i] = 0
            else:
                dp[i] = float('inf')
                for j in range(i):
                    if is_pal[j+1][i]:
                        dp[i] = min(dp[i], dp[j]+1)
        return dp[n-1]


TLE:
import sys
sys.setrecursionlimit(10**6)

# DP table for memoization
t = [[-1 for _ in range(1001)] for _ in range(1001)]

# Function to check if a substring is a palindrome
def is_palindrome(X, i, j):
    while i <= j:
        if X[i] != X[j]:
            return False
        i += 1
        j -= 1
    return True

# Recursive function with memoization
def solve(X, i, j):
    if t[i][j] != -1:
        return t[i][j]

    if i >= j or is_palindrome(X, i, j):
        t[i][j] = 0
        return 0

    ans = float('inf')
    for k in range(i, j):
        left = t[i][k] if t[i][k] != -1 else solve(X, i, k)
        right = t[k + 1][j] if t[k + 1][j] != -1 else solve(X, k + 1, j)
        temp_ans = left + right + 1
        ans = min(ans, temp_ans)

    t[i][j] = ans
    return ans

# Input
X = input().strip()

# Compute and print minimum cuts
print(solve(X, 0, len(X) - 1))




cpp:
#include <bits/stdc++.h>
using namespace std;

const int MAX = 1001;
int t[MAX][MAX]; // DP table

// Function to check if a substring is a palindrome
bool IsPalindrome(const string &X, int i, int j) {
    while (i <= j) {
        if (X[i] != X[j])
            return false;
        i++;
        j--;
    }
    return true;
}

// Recursive function with memoization
int Solve(const string &X, int i, int j) {
    if (t[i][j] != -1)
        return t[i][j];

    if (i >= j || IsPalindrome(X, i, j)) {
        t[i][j] = 0;
        return 0;
    }

    int ans = INT_MAX;

    for (int k = i; k < j; k++) {
        int left = (t[i][k] == -1) ? Solve(X, i, k) : t[i][k];
        int right = (t[k + 1][j] == -1) ? Solve(X, k + 1, j) : t[k + 1][j];

        int tempAns = left + right + 1;
        ans = min(ans, tempAns);
    }

    return t[i][j] = ans;
}

int main() {
    string X;
    cin >> X;

    // Initialize DP table with -1
    memset(t, -1, sizeof(t));

    cout << Solve(X, 0, X.size() - 1) << endl;

    return 0;
}




c#:

using System;

class PalindromePartition
{
    static int[,] t = new int[1001, 1001];  // DP table

    // Function to check if a substring is a palindrome
    static bool IsPalindrome(string X, int i, int j)
    {
        while (i <= j)
        {
            if (X[i] != X[j])
                return false;
            i++;
            j--;
        }
        return true;
    }

    // Recursive function to solve the problem using DP
    static int Solve(string X, int i, int j)
    {
        // If already computed, return the result from DP table
        if (t[i, j] != -1)
            return t[i, j];

        // If substring is a palindrome or single character, no cuts needed
        if (i >= j || IsPalindrome(X, i, j))
        {
            t[i, j] = 0;
            return 0;
        }

        int ans = int.MaxValue;

        // Try partitioning the string at every possible position
        for (int k = i; k < j; k++)
        {
            int left = (t[i, k] == -1) ? Solve(X, i, k) : t[i, k];
            int right = (t[k + 1, j] == -1) ? Solve(X, k + 1, j) : t[k + 1, j];

            int tempAns = left + right + 1;
            ans = Math.Min(ans, tempAns);
        }

        return t[i, j] = ans;
    }

    static void Main()
    {
        string X = Console.ReadLine(); // Read input string

        // Initialize DP table to -1 (indicating not computed yet)
        Array.Clear(t, 0, t.Length);

        // Call the Solve function and print the result
        Console.WriteLine(Solve(X, 0, X.Length - 1));
    }
}
