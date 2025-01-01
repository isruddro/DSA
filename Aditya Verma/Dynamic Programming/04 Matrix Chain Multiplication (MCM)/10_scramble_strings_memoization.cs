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
