using System;
using System.Collections.Generic;

class Solution
{
    // Function to find the kth smallest element in an array
    static int FindKthSmallest(List<int> arr, int k)
    {
        int n = arr.Count;

        // Max-heap (priority queue) to store the k smallest elements
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach (var num in arr)
        {
            maxHeap.Enqueue(num, -num);  // Invert the number to simulate max-heap behavior

            // If the heap size exceeds k, remove the largest element
            if (maxHeap.Count > k)
                maxHeap.Dequeue();
        }

        // The top of the max-heap contains the kth smallest element
        return maxHeap.Peek();
    }

    static void Main()
    {
        // Array of integers
        List<int> arr = new List<int> { 7, 12, 9, 4, 1, 8, 3, 5, 6, 10 };
        int k;

        Console.WriteLine("Enter position: ");
        k = Convert.ToInt32(Console.ReadLine());  // Input position k

        // Find and print the kth smallest element
        Console.WriteLine(FindKthSmallest(arr, k));
    }
}
