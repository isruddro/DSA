using System;
using System.Collections.Generic;

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        // Create a min-heap with a capacity of k
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            // Add the current number to the heap
            minHeap.Enqueue(num, num);

            // If the heap size exceeds k, remove the smallest element
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        // The root of the heap is the kth largest element
        return minHeap.Peek();
    }
}