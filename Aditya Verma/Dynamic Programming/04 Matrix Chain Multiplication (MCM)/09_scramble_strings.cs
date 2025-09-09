py:

# Recursive function to check if X can be scrambled into Y
def solve(X, Y):
    if X == Y:
        return True
    if len(X) <= 1:
        return False

    n = len(X)
    for i in range(1, n):
        # Case 1: swap
        if solve(X[:i], Y[n-i:]) and solve(X[i:], Y[:n-i]):
            return True
        # Case 2: no swap
        if solve(X[:i], Y[:i]) and solve(X[i:], Y[i:]):
            return True

    return False

# Input
X = input().strip()
Y = input().strip()

# Output
if len(X) != len(Y):
    print("No")
else:
    print("Yes" if solve(X, Y) else "No")




cpp:
#include <bits/stdc++.h>
using namespace std;

// Recursive function to check if X can be scrambled into Y
bool Solve(const string &X, const string &Y) {
    if (X == Y) return true;       // Strings are equal
    if (X.size() <= 1) return false; // Single char strings that aren't equal

    int n = X.size();
    for (int i = 1; i <= n - 1; i++) {
        // Case 1: Swap
        if (Solve(X.substr(0, i), Y.substr(n - i, i)) &&
            Solve(X.substr(i), Y.substr(0, n - i)))
            return true;

        // Case 2: No swap
        if (Solve(X.substr(0, i), Y.substr(0, i)) &&
            Solve(X.substr(i), Y.substr(i)))
            return true;
    }

    return false;
}

int main() {
    string X, Y;
    cin >> X >> Y;

    if (X.size() != Y.size()) {
        cout << "No\n";
    } else {
        cout << (Solve(X, Y) ? "Yes\n" : "No\n");
    }

    return 0;
}




c#:

using System;

class Program
{
    // Recursive function to check if string X can be scrambled into string Y
    static bool Solve(string X, string Y)
    {
        // If both strings are the same
        if (X.CompareTo(Y) == 0)
            return true;

        // Base case: if length is 1, they are not the same
        if (X.Length <= 1)
            return false;

        int n = X.Length;

        // Check all possible ways to split the strings
        for (int i = 1; i <= n - 1; i++)
        {
            // Two possible cases:
            // 1. First part of X is scrambled into second part of Y and second part of X is scrambled into first part of Y
            // 2. First part of X is scrambled into first part of Y and second part of X is scrambled into second part of Y
            if ((Solve(X.Substring(0, i), Y.Substring(n - i, i)) && Solve(X.Substring(i), Y.Substring(0, n - i))) ||
                (Solve(X.Substring(0, i), Y.Substring(0, i)) && Solve(X.Substring(i), Y.Substring(i))))
            {
                return true;  // Found a valid scramble
            }
        }

        // If no valid scramble found, return false
        return false;
    }

    static void Main()
    {
        // Read input strings
        string X = Console.ReadLine();
        string Y = Console.ReadLine();

        // Check if lengths are the same
        if (X.Length != Y.Length)
            Console.WriteLine("No");
        else
            // Call Solve function and print the result
            Console.WriteLine(Solve(X, Y) ? "Yes" : "No");
    }
}
