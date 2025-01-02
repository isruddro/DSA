using System;
using System.Collections.Generic;

public class Solution
{
    private static List<int> stack = new List<int>();
    private static int minElement = int.MaxValue;

    // Method to get the minimum element from the stack
    public static int GetMin()
    {
        if (stack.Count == 0)
        {
            return -1; // Stack is empty
        }
        return minElement;
    }

    // Method to push an element onto the stack
    public static void Push(int ele)
    {
        if (stack.Count == 0)
        {
            stack.Add(ele);
            minElement = ele;
        }
        else
        {
            // If the current element is greater than or equal to the minimum element
            if (ele >= minElement)
            {
                stack.Add(ele);
            }
            // If the current element is smaller than the minimum element
            else
            {
                stack.Add(2 * ele - minElement);
                minElement = ele;
            }
        }
    }

    // Method to pop an element from the stack
    public static void Pop()
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
            return;
        }

        int top = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);

        // If the popped element is smaller than the current minimum element
        if (top < minElement)
        {
            minElement = 2 * minElement - top;
        }
    }

    // Main method to test the functionality
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
            Pop();
            Console.WriteLine("Minimum after pop: " + GetMin());
        }
    }
}
