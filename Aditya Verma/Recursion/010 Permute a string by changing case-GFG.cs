using System;
using System.Collections.Generic;

public class Solution
{
    public void GetSolve(string op, ref string s, List<string> result)
    {
        if (s.Length == 0)
        {
            result.Add(op);
            return;
        }

        string op1 = op;
        string op2 = op;
        op1 += char.ToLower(s[0]);
        op2 += char.ToUpper(s[0]);
        s = s.Substring(1); // Remove the first character
        GetSolve(op1, ref s, result);
        GetSolve(op2, ref s, result);
        return;
    }

    public static void Main(string[] args)
    {
        string s = Console.ReadLine();  // Input the string
        List<string> result = new List<string>();
        string op = string.Empty;
        
        Solution solution = new Solution();
        solution.GetSolve(op, ref s, result);

        foreach (string res in result)
        {
            Console.Write(res + " ");
        }
    }
}
