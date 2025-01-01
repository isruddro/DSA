using System;

class BooleanParenthesization
{
    // Create a 3D array to store the results of subproblems (dp[0/1][i][j])
    static int[,,] dp = new int[2, 1001, 1001];

    static int Solve(string X, int i, int j, bool isTrue)
    {
        // Base case: if i >= j, check if the character matches the expected value
        if (i >= j)
        {
            if (isTrue)
                dp[1, i, j] = (X[i] == 'T') ? 1 : 0;
            else
                dp[0, i, j] = (X[i] == 'F') ? 1 : 0;
            return dp[isTrue ? 1 : 0, i, j];
        }

        // If the result is already computed, return it
        if (dp[isTrue ? 1 : 0, i, j] != -1)
            return dp[isTrue ? 1 : 0, i, j];

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

        // Store the result for the current subproblem
        dp[isTrue ? 1 : 0, i, j] = ans;
        return ans;
    }

    static void Main()
    {
        string X = Console.ReadLine(); // Read input string

        // Initialize dp array to -1 (not calculated state)
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 1001; j++)
                for (int k = 0; k < 1001; k++)
                    dp[i, j, k] = -1;

        // Call Solve function with true as the target
        Console.WriteLine(Solve(X, 0, X.Length - 1, true));
    }
}
