using System;
using System.Collections.Generic;

public class Solution
{
    public int[] DistinctNumbersInWindow(int[] A, int B)
    {
        // If B is greater than the length of the array, return an empty array
        if (B > A.Length)
        {
            return new int[0];
        }

        List<int> result = new List<int>();
        Dictionary<int, int> countMap = new Dictionary<int, int>();
        
        // Initialize the first window
        for (int i = 0; i < B; i++)
        {
            if (countMap.ContainsKey(A[i]))
            {
                countMap[A[i]]++;
            }
            else
            {
                countMap[A[i]] = 1;
            }
        }
        
        // Add the count of distinct elements in the first window
        result.Add(countMap.Count);

        // Slide the window across the array
        for (int i = B; i < A.Length; i++)
        {
            // Remove the element going out of the window
            int outElement = A[i - B];
            if (countMap[outElement] == 1)
            {
                countMap.Remove(outElement);
            }
            else
            {
                countMap[outElement]--;
            }

            // Add the new element coming into the window
            int inElement = A[i];
            if (countMap.ContainsKey(inElement))
            {
                countMap[inElement]++;
            }
            else
            {
                countMap[inElement] = 1;
            }

            // Add the current distinct count to the result
            result.Add(countMap.Count);
        }

        // Return the result as an array
        return result.ToArray();
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();
        
        // Test case 1
        int[] A1 = {1, 2, 1, 3, 4, 3};
        int B1 = 3;
        int[] result1 = solution.DistinctNumbersInWindow(A1, B1);
        Console.WriteLine("Output 1: " + string.Join(", ", result1));
        
        // Test case 2
        int[] A2 = {1, 1, 2, 2};
        int B2 = 1;
        int[] result2 = solution.DistinctNumbersInWindow(A2, B2);
        Console.WriteLine("Output 2: " + string.Join(", ", result2));
    }
}
