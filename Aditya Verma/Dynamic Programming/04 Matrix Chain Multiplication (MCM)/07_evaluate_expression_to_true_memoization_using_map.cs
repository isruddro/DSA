using System;
using System.Collections.Generic;

class BooleanParenthesization
{
    // Create a Dictionary to store the results of subproblems
    static Dictionary<string, int> ump = new Dictionary<string, int>();

    static int Solve(string X, int i, int j, bool isTrue)
    {
        // Create the key to store the result in the dictionary
        string key = i + " " + j + " " + (isTrue ? "T" : "F");

        // Check if the result is already computed
        if (ump.ContainsKey(key))
            return ump[key];

        // Base case: when i >= j, check if the character matches the expected value
        if (i >= j)
        {
            ump[key] = (isTrue ? X[i] == 'T' : X[i] == 'F') ? 1 : 0;
            return ump[key];
        }

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

        // Store the result for the current subproblem in the dictionary
        ump[key] = ans;
        return ans;
    }

    static void Main()
    {
        string X = Console.ReadLine(); // Read input string
        ump.Clear(); // Clear the memoization dictionary
        Console.WriteLine(Solve(X, 0, X.Length - 1, true)); // Call Solve function with true as the target
    }
}
