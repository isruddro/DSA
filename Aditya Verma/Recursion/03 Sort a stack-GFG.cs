using System;
using System.Collections.Generic;

public class SortedStack
{
    private Stack<int> s = new Stack<int>();

    public void GetStack(Stack<int> stack, int to)
    {
        if (stack.Count == 0 || to >= stack.Peek())
        {
            stack.Push(to);
            return;
        }

        int t = stack.Peek();
        stack.Pop();
        GetStack(stack, to);
        stack.Push(t);
    }

    public void Sort()
    {
        if (s.Count == 0)
            return;

        int to = s.Peek();
        s.Pop();
        Sort();
        GetStack(s, to);
    }

    // Helper method to push values into the stack
    public void Push(int value)
    {
        s.Push(value);
    }

    // Helper method to print the stack
    public void PrintStack()
    {
        foreach (int item in s)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        SortedStack sortedStack = new SortedStack();

        // Input the stack elements
        int n = int.Parse(Console.ReadLine());
        string[] elements = Console.ReadLine().Split();
        foreach (string element in elements)
        {
            sortedStack.Push(int.Parse(element));
        }

        // Sorting the stack
        sortedStack.Sort();

        // Printing the sorted stack
        sortedStack.PrintStack();
    }
}
