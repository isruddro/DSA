cpp:
#include <bits/stdc++.h>
using namespace std;

const int MAX = 1001;
int t[MAX][MAX]; // DP table

// Function to check if a substring is palindrome
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
    if (i >= j || IsPalindrome(X, i, j))
        return 0;

    if (t[i][j] != -1)
        return t[i][j];

    int ans = INT_MAX;

    for (int k = i; k <= j - 1; k++) {
        int tempAns = Solve(X, i, k) + Solve(X, k + 1, j) + 1;
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
        // If substring is a palindrome or single character, no cuts needed
        if (i >= j || IsPalindrome(X, i, j))
        {
            t[i, j] = 0;
            return 0;
        }

        // If already computed, return the result from DP table
        if (t[i, j] != -1)
            return t[i, j];

        int ans = int.MaxValue;
        
        // Try partitioning the string at every possible position
        for (int k = i; k <= j - 1; k++)
        {
            int tempAns = Solve(X, i, k) + Solve(X, k + 1, j) + 1;
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
