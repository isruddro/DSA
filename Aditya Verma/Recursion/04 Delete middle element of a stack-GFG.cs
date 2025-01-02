using System;
using System.Collections.Generic;

public class Solution
{
    // Function to delete the middle element of a stack
    public void GetDeleted(Stack<int> s, int k)
    {
        // Base case: If k reaches 0, pop the top element of the stack
        if (k == 0)
        {
            s.Pop();
            return;
        }
        
        // Pop the top element and recursively call the function with k-1
        int t = s.Peek();
        s.Pop();
        GetDeleted(s, k - 1);
        
        // Push the element back after deleting the middle one
        s.Push(t);
    }

    public void DeleteMid(Stack<int> s, int sizeOfStack)
    {
        // Calculate the index of the middle element
        int k = (int)Math.Ceiling(sizeOfStack / 2.0) - 1;
        
        // Call GetDeleted to delete the middle element
        GetDeleted(s, k);
    }
}
