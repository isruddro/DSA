S3:

using System;
using System.Collections.Generic;
using System.Linq;

public class NextGreaterPermutation
{
    public static List<int> NextGreaterPermutation(List<int> A)
    {
        int n = A.Count;

        // Step 1: Find the break point
        int ind = -1;
        for (int i = n - 2; i >= 0; i--)
        {
            if (A[i] < A[i + 1])
            {
                ind = i;
                break;
            }
        }

        // If no break point exists, reverse the entire list
        if (ind == -1)
        {
            A.Reverse();
            return A;
        }

        // Step 2: Find the next greater element and swap it with A[ind]
        for (int i = n - 1; i > ind; i--)
        {
            if (A[i] > A[ind])
            {
                int temp = A[i];
                A[i] = A[ind];
                A[ind] = temp;
                break;
            }
        }

        // Step 3: Reverse the right half
        A.Reverse(ind + 1, n - (ind + 1));

        return A;
    }

    public static void Main(string[] args)
    {
        List<int> A = new List<int> { 2, 1, 5, 4, 3, 0, 0 };
        List<int> ans = NextGreaterPermutation(A);

        Console.Write("The next permutation is: [");
        for (int i = 0; i < ans.Count; i++)
        {
            Console.Write(ans[i] + (i < ans.Count - 1 ? " " : ""));
        }
        Console.WriteLine("]");
    }
}
