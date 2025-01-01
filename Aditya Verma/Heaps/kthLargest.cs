using System;
using System.Collections.Generic;

class Solution
{
    // Function to find the kth largest element in an array
    static int FindKthLargest(List<int> arr, int k)
    {
        int n = arr.Count;

        // Min-heap (priority queue) to store the k largest elements
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (var num in arr)
        {
            minHeap.Enqueue(num, num);  // Push each element into the min-heap

            // If the heap size exceeds k, remove the smallest element
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        // The top of the min-heap contains the kth largest element
        return minHeap.Peek();
    }

    static void Main()
    {
        // Array of integers
        List<int> arr = new List<int> { 56, 89, 44, 65, 33 };
        int k;

        Console.WriteLine("Enter k: ");
        k = Convert.ToInt32(Console.ReadLine());  // Input k

        // Find and print the kth largest element
        Console.WriteLine(FindKthLargest(arr, k));
    }
}
