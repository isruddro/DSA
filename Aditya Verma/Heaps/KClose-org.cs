using System;
using System.Collections.Generic;

class Solution
{
    public class Pair
    {
        public int First { get; set; }
        public int Second { get; set; }
        
        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }
    }
    
    static void Main()
    {
        // Initialize the vector of pairs
        List<Pair> arr = new List<Pair>
        {
            new Pair(1, 3),
            new Pair(-2, 2),
            new Pair(5, 8),
            new Pair(0, 3)
        };
        int k = 2;

        // Max-heap (priority queue) to store the distance and pair
        PriorityQueue<(int, Pair), int> maxh = new PriorityQueue<(int, Pair), int>();

        foreach (var point in arr)
        {
            // Calculate the squared distance
            int dis = (point.First * point.First) + (point.Second * point.Second);

            // Push the squared distance and point into the priority queue
            maxh.Enqueue((dis, point), -dis); // Negative distance to simulate max-heap

            // If the size of the priority queue exceeds k, remove the largest element
            if (maxh.Count > k)
            {
                maxh.Dequeue();
            }
        }

        // Output the k closest points
        while (maxh.Count > 0)
        {
            var temp = maxh.Dequeue().Item2; // Extract the point
            Console.Write(temp.First + ", " + temp.Second + "; ");
        }
    }
}
