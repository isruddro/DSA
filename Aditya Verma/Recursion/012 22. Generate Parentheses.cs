using System;
using System.Collections.Generic;

public class Solution
{
    // Recursive helper function to generate the combinations
    private void GetSolved(string opt, int op, int cl, List<string> result)
    {
        // If no more open and close parentheses to add, add the current combination to the result
        if (op == 0 && cl == 0)
        {
            result.Add(opt);
            return;
        }

        // If there are open parentheses remaining, add an open parenthesis
        if (op != 0)
        {
            string op1 = opt + "(";
            GetSolved(op1, op - 1, cl, result);
        }

        // If there are more closing parentheses than open ones, add a closing parenthesis
        if (cl > op)
        {
            string op1 = opt + ")";
            GetSolved(op1, op, cl - 1, result);
        }
    }

    // Function to generate all combinations of parentheses
    public IList<string> GenerateParenthesis(int n)
    {
        int op = n, cl = n;
        List<string> result = new List<string>();
        string opt = string.Empty;
        GetSolved(opt, op, cl, result);
        return result;
    }
}
