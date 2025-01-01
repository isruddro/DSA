using System;
using System.Collections.Generic;

public class Solution
{
    public void GetSorted(string op, ref string S, List<string> result)
    {
        if (S.Length == 0)
        {
            result.Add(op);
            return;
        }

        string op1 = op;
        string op2 = op;
        op1 += " " + S[0];
        op2 += S[0];
        S = S.Substring(1); // Remove the first character
        GetSorted(op1, ref S, result);
        GetSorted(op2, ref S, result);
        return;
    }

    public List<string> Permutation(string S)
    {
        List<string> result = new List<string>();
        string op = S[0].ToString();
        S = S.Substring(1); // Remove the first character
        GetSorted(op, ref S, result);
        return result;
    }
}
