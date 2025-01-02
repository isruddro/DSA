using System;
using System.Collections.Generic;

public class Solution
{
    public void GetSorted(string op, int one, int zero, int N, ref List<string> result)
    {
        if (N == 0)
        {
            result.Add(op);
            return;
        }

        string op1 = op;
        op1 += '1';
        GetSorted(op1, one + 1, zero, N - 1, ref result);

        if (one > zero)
        {
            string op2 = op;
            op2 += '0';
            GetSorted(op2, one, zero + 1, N - 1, ref result);
        }

        return;
    }

    public List<string> NBitBinary(int N)
    {
        string op = "1";
        N -= 1;
        List<string> result = new List<string>();
        int one = 1, zero = 0;
        GetSorted(op, one, zero, N, ref result);
        return result;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int N = int.Parse(Console.ReadLine());  // Input the value of N
        List<string> result = solution.NBitBinary(N);

        foreach (string binaryString in result)
        {
            Console.Write(binaryString + " ");
        }
    }
}
