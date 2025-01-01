using System;
using System.Collections.Generic;

public class Solution
{
    public void GetSolve(Stack<int> st, int t)
    {
        if (st.Count == 0)
        {
            st.Push(t);
            return;
        }

        int to = st.Peek();
        st.Pop();
        GetSolve(st, t);
        st.Push(to);
    }

    public void Solve(Stack<int> st)
    {
        if (st.Count == 0)
            return;

        int t = st.Peek();
        st.Pop();
        Solve(st);
        GetSolve(st, t);
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> st = new Stack<int>();
        string[] input = Console.ReadLine().Split();

        foreach (string value in input)
        {
            st.Push(int.Parse(value));
        }

        Solution solution = new Solution();
        solution.Solve(st);

        while (st.Count > 0)
        {
            Console.Write(st.Pop() + " ");
        }
    }
}
