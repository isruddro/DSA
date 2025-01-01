using System;
using System.Collections.Generic;

class Solution
{
    public static List<int> StockSpanProblem(int[] stock)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < stock.Length; i++)
        {
            // Pop elements from the stack while they are smaller than or equal to the current element
            while (stack.Count > 0 && stock[stack.Peek()] <= stock[i])
            {
                stack.Pop();
            }

            // If stack is empty, it means no greater element to the left
            if (stack.Count == 0)
            {
                ans.Add(i + 1);  // Span is i + 1 as there are no elements greater than stock[i]
            }
            else
            {
                ans.Add(i - stack.Peek());  // Span is difference between current index and index of last greater element
            }

            // Push the current index onto the stack
            stack.Push(i);
        }

        return ans;
    }

    static void Main(string[] args)
    {
        int[] stock = { 100, 80, 60, 70, 60, 75, 85 };
        List<int> result = StockSpanProblem(stock);

        Console.WriteLine("Stock Span:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
