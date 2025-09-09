cpp:
#include <iostream>
#include <string>
#include <algorithm> // for std::max

using namespace std;

class Solution {
public:
    // Recursive function to calculate LCS
    int LCS(const string &X, const string &Y, int n, int m) {
        // Base case: If either string is empty
        if (n == 0 || m == 0)
            return 0;

        // If last characters of both strings match
        if (X[n - 1] == Y[m - 1])
            return 1 + LCS(X, Y, n - 1, m - 1);

        // If last characters don't match
        else
            return max(LCS(X, Y, n - 1, m), LCS(X, Y, n, m - 1));
    }
};

int main() {
    string X, Y;
    getline(cin, X); // Read first string
    getline(cin, Y); // Read second string

    Solution solution;
    int result = solution.LCS(X, Y, X.length(), Y.length());

    cout << result << endl;

    return 0;
}





c#:

using System;

public class Solution
{
    // Recursive function to calculate the Longest Common Subsequence (LCS)
    public int LCS(string X, string Y, int n, int m)
    {
        // Base case: If either string is empty
        if (n == 0 || m == 0)
            return 0;

        // If last characters of both strings match
        if (X[n - 1] == Y[m - 1])
            return 1 + LCS(X, Y, n - 1, m - 1);

        // If last characters don't match, consider two possibilities:
        // 1. Exclude current character of X
        // 2. Exclude current character of Y
        else
            return Math.Max(LCS(X, Y, n - 1, m), LCS(X, Y, n, m - 1));
    }

    public static void Main(string[] args)
    {
        // Input strings
        string X = Console.ReadLine();
        string Y = Console.ReadLine();
        
        int n = X.Length;
        int m = Y.Length;

        // Create solution object and calculate LCS
        Solution solution = new Solution();
        int result = solution.LCS(X, Y, n, m);

        // Output the result
        Console.WriteLine(result);
    }
}
