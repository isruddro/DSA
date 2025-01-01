using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        // Initialize the array and other variables
        List<int> arr = new List<int> { 5, 6, 7, 8, 9 };
        int k; // Number of closest numbers to find
        int m = 7; // The target number to compare to
        int n = arr.Count;

        Console.Write("Enter k: "); // Prompt user for k
        k = int.Parse(Console.ReadLine());

        // Max-heap (priority queue) to store the absolute differences and corresponding numbers
        PriorityQueue<(int, int), int> maxhp = new PriorityQueue<(int, int), int>();

        // Loop through the array to calculate the absolute differences
        foreach (var num in arr)
        {
            maxhp.Enqueue((Math.Abs(num - m), num), -(Math.Abs(num - m))); // Store negative distance for max-heap

            if (maxhp.Count > k)
                maxhp.Dequeue(); // Pop the largest element if the size exceeds k
        }

        // Output the k closest numbers
        Console.WriteLine("The k closest numbers are:");
        while (maxhp.Count > 0)
        {
            Console.Write(maxhp.Dequeue().Item2 + " "); // Extract the number from the tuple
        }
    }
}
