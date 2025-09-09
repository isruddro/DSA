py:

import sys
sys.setrecursionlimit(10**6)

# Function to check if a substring is palindrome
def is_palindrome(X, i, j):
    while i <= j:
        if X[i] != X[j]:
            return False
        i += 1
        j -= 1
    return True

# Recursive function to compute minimum cuts
def solve(X, i, j):
    if i >= j or is_palindrome(X, i, j):
        return 0

    ans = float('inf')
    for k in range(i, j):
        temp_ans = solve(X, i, k) + solve(X, k + 1, j) + 1
        ans = min(ans, temp_ans)

    return ans

# Input
X = input().strip()

# Compute and print minimum cuts
print(solve(X, 0, len(X) - 1))




cpp:
#include <bits/stdc++.h>
using namespace std;

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

// Recursive function to compute minimum cuts
int Solve(const string &X, int i, int j) {
    // Base case: already palindrome or length <= 1
    if (i >= j || IsPalindrome(X, i, j))
        return 0;

    int ans = INT_MAX;

    // Try all possible partitions
    for (int k = i; k <= j - 1; k++) {
        int tempAns = Solve(X, i, k) + Solve(X, k + 1, j) + 1;
        ans = min(ans, tempAns);
    }

    return ans;
}

int main() {
    string X;
    cin >> X;

    cout << Solve(X, 0, X.length() - 1) << endl;

    return 0;
}




c#:

using System;

class PalindromePartition
{
    // Function to check if a string is palindrome
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

    // Recursive function to solve the problem
    static int Solve(string X, int i, int j)
    {
        // Base case: If the string is already a palindrome or if the length is 1 or less
        if (i >= j || IsPalindrome(X, i, j))
            return 0;

        int ans = int.MaxValue;
        
        // Try partitioning the string at every possible position
        for (int k = i; k <= j - 1; k++)
        {
            int tempAns = Solve(X, i, k) + Solve(X, k + 1, j) + 1;
            ans = Math.Min(ans, tempAns);
        }
        
        return ans;
    }

    static void Main()
    {
        string X = Console.ReadLine();

        // Call the Solve function and print the result
        Console.WriteLine(Solve(X, 0, X.Length - 1));
    }
}
