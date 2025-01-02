using System;
using System.Collections.Generic;

public class Solution
{
    private static List<int> stack = new List<int>();
    private static List<int> support = new List<int>();

    // Method to get the minimum element from the support stack
    public static int GetMin()
    {
        if (support.Count == 0)
        {
            return -1;
        }
        return support[support.Count - 1];
    }

    // Method to push an element onto the stack and support stack
    public static void Push(int ele)
    {
        stack.Add(ele);

        // If support is empty or the current element is less than or equal to the current minimum
        if (support.Count == 0 || support[support.Count - 1] >= ele)
        {
            support.Add(ele);
        }
    }

    // Method to pop an element from the stack and support stack
    public static int Pop()
    {
        if (stack.Count == 0)
        {
            return -1;
        }

        int ans = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);

        // If the popped element is the minimum element, pop it from the support stack
        if (support[support.Count - 1] == ans)
        {
            support.RemoveAt(support.Count - 1);
        }

        return ans;
    }

    // Main method to test the stack functionality
    public static void Main(string[] args)
    {
        int[] arr = { 18, 19, 29, 15, 16 };

        foreach (int num in arr)
        {
            Push(num);
            Console.WriteLine("Pushed: " + num + ", Minimum: " + GetMin());
        }

        Console.WriteLine("Popping elements...");
        while (stack.Count > 0)
        {
            int popped = Pop();
            Console.WriteLine("Popped: " + popped + ", Minimum: " + GetMin());
        }
    }
}
