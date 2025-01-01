using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        // Initialize the array and the value of k
        List<int> arr = new List<int> { 6, 5, 3, 2, 8, 10, 9 };
        int k = 3;

        List<int> v = new List<int>();  // To store the sorted result
        int n = arr.Count;
        int m;

        // Min-heap (priority queue) to keep the smallest elements
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        // Traverse through the array
        foreach (var num in arr)
        {
            minHeap.Enqueue(num, num);  // Push each element into the min-heap

            // If heap size exceeds k, pop the smallest element and add it to the result
            if (minHeap.Count > k)
            {
                m = minHeap.Dequeue();  // Get the smallest element from the heap
                v.Add(m);  // Add it to the sorted result
            }
        }

        // Empty the heap and add remaining elements to the result
        while (minHeap.Count > 0)
        {
            m = minHeap.Dequeue();
            v.Add(m);
        }

        // Print the sorted array
        foreach (var num in v)
        {
            Console.Write(num + " ");
        }
    }
}
