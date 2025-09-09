py:

# Dictionary to memoize previously computed results
memo = {}

def solve(X, Y):
    key = X + " " + Y  # Unique key for memoization

    # Return cached result if available
    if key in memo:
        return memo[key]

    # Base case: strings are identical
    if X == Y:
        memo[key] = True
        return True

    # Base case: single character strings that aren't equal
    if len(X) <= 1:
        memo[key] = False
        return False

    n = len(X)
    flag = False

    # Try splitting the string at different positions
    for i in range(1, n):
        # Case 1: swap
        if solve(X[:i], Y[n-i:]) and solve(X[i:], Y[:n-i]):
            flag = True
            break
        # Case 2: no swap
        if solve(X[:i], Y[:i]) and solve(X[i:], Y[i:]):
            flag = True
            break

    memo[key] = flag
    return flag

# Input
X = input().strip()
Y = input().strip()

# Output
memo.clear()
if len(X) != len(Y):
    print("No")
else:
    print("Yes" if solve(X, Y) else "No")




cpp:
#include <bits/stdc++.h>
using namespace std;

// Memoization map for storing previously computed results
unordered_map<string, bool> ump;

// Recursive function to check if string X can be scrambled into string Y
bool Solve(const string &X, const string &Y) {
    string key = X + " " + Y; // Unique key for memoization

    // Check if result is already computed
    if (ump.find(key) != ump.end())
        return ump[key];

    // Base case: strings are identical
    if (X == Y) {
        ump[key] = true;
        return true;
    }

    // Base case: single character strings that aren't equal
    if (X.size() <= 1) {
        ump[key] = false;
        return false;
    }

    int n = X.size();
    bool flag = false;

    // Try splitting the string at different positions
    for (int i = 1; i <= n - 1; i++) {
        // Case 1: Swap
        if (Solve(X.substr(0, i), Y.substr(n - i, i)) &&
            Solve(X.substr(i), Y.substr(0, n - i))) {
            flag = true;
            break;
        }

        // Case 2: No swap
        if (Solve(X.substr(0, i), Y.substr(0, i)) &&
            Solve(X.substr(i), Y.substr(i))) {
            flag = true;
            break;
        }
    }

    // Store the result in the memoization map
    ump[key] = flag;
    return flag;
}

int main() {
    string X, Y;
    cin >> X >> Y;

    ump.clear(); // Clear the memoization map

    if (X.size() != Y.size())
        cout << "No\n";
    else
        cout << (Solve(X, Y) ? "Yes\n" : "No\n");

    return 0;
}


c#:

using System;
using System.Collections.Generic;

class Program
{
    // Dictionary to memoize the results for overlapping subproblems
    static Dictionary<string, bool> ump = new Dictionary<string, bool>();

    // Recursive function to check if string X can be scrambled into string Y
    static bool Solve(string X, string Y)
    {
        // Create a unique key for the pair of strings X and Y
        string key = X + " " + Y;

        // Check if result is already computed
        if (ump.ContainsKey(key))
            return ump[key];

        // Base case: If both strings are identical
        if (X.CompareTo(Y) == 0)
        {
            ump[key] = true;
            return true;
        }

        // Base case: If length is 1 and they are not the same
        if (X.Length <= 1)
        {
            ump[key] = false;
            return false;
        }

        int n = X.Length;
        bool flag = false;

        // Try splitting the strings at different points
        for (int i = 1; i <= n - 1; i++)
        {
            // Check both possible scenarios for scrambling
            if ((Solve(X.Substring(0, i), Y.Substring(n - i, i)) && Solve(X.Substring(i), Y.Substring(0, n - i))) ||
                (Solve(X.Substring(0, i), Y.Substring(0, i)) && Solve(X.Substring(i), Y.Substring(i))))
            {
                flag = true;
                break;
            }
        }

        // Memoize the result
        ump[key] = flag;
        return flag;
    }

    static void Main()
    {
        // Read input strings
        string X = Console.ReadLine();
        string Y = Console.ReadLine();

        // Clear the dictionary before starting the solve function
        ump.Clear();

        // Check if the lengths are the same
        if (X.Length != Y.Length)
            Console.WriteLine("No");
        else
            // Call Solve function and print the result
            Console.WriteLine(Solve(X, Y) ? "Yes" : "No");
    }
}
