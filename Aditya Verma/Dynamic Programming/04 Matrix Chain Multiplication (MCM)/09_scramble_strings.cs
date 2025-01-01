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
