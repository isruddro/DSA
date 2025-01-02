using System;
using System.Collections.Generic;

class Solution
{
    public static List<int> NextSmallerElementToLeft(int[] arr)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        // Traverse the array from left to right
        for (int i = 0; i < arr.Length; i++)
        {
            // If stack is empty, no smaller element to the left
            if (stack.Count == 0)
            {
                ans.Add(-1);
            }
            // If the top element of stack is smaller than current element
            else if (stack.Peek() < arr[i])
            {
                ans.Add(stack.Peek());
            }
            // If the top element of stack is greater than or equal to the current element
            else
            {
                // Pop elements from the stack while they are greater than or equal to the current element
                while (stack.Count > 0 && stack.Peek() >= arr[i])
                {
                    stack.Pop();
                }

                // If the stack is empty, no smaller element to the left
                if (stack.Count == 0)
                {
                    ans.Add(-1);
                }
                else
                {
                    ans.Add(stack.Peek());
                }
            }

            // Push the current element onto the stack
            stack.Push(arr[i]);
        }

        return ans;
    }

    static void Main(string[] args)
    {
        int[] arr = { 4, 5, 2, 10, 8 };
        List<int> result = NextSmallerElementToLeft(arr);

        Console.WriteLine("Next Smaller Element to Left:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
