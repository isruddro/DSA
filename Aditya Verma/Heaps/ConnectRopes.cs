using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        // Initialize the rope lengths
        List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6 };
        int n = arr.Count;
        int cost = 0;

        // Min-heap to store the rope lengths
        PriorityQueue<int, int> minh = new PriorityQueue<int, int>();

        // Push all elements of the array into the min-heap
        foreach (var len in arr)
        {
            minh.Enqueue(len, len);
        }

        // Connect ropes until there is more than one rope
        while (minh.Count >= 2)
        {
            int len1 = minh.Dequeue();
            int len2 = minh.Dequeue();

            // Add the cost of connecting the two smallest ropes
            cost += len1 + len2;

            // Push the new connected rope back into the heap
            minh.Enqueue(len1 + len2, len1 + len2);
        }

        // Output the minimum cost
        Console.WriteLine(cost);
    }
}
