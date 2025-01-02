/*
    Here, i will go left to right and we dont need to make reverse as it will give the answer directly.
 */

using System;
using System.Collections.Generic;

class Solution
{
    public static List<int> NextGreaterElementToLeft(int[] arr)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            // If stack is empty, no greater element to the left
            if (stack.Count == 0)
            {
                ans.Add(-1);
            }
            // If the top element of stack is greater than current element
            else if (stack.Peek() > arr[i])
            {
                ans.Add(stack.Peek());
            }
            // If the top element of stack is less than or equal to the current element
            else
            {
                // Pop elements from the stack while they are smaller or equal to the current element
                while (stack.Count > 0 && stack.Peek() <= arr[i])
                {
                    stack.Pop();
                }

                // If the stack is empty, no greater element to the left
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
        int[] arr = { 1, 3, 2, 4 };
        List<int> result = NextGreaterElementToLeft(arr);

        Console.WriteLine("Next Greater Element to Left:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
