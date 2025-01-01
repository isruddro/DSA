using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        // Initialize the array
        List<int> arr = new List<int> { 4, 4, 4, 4, 3, 3, 1, 1, 1, 2 };
        int n = arr.Count;

        // Dictionary to store the frequency of each element
        Dictionary<int, int> mp = new Dictionary<int, int>();

        // Populate the dictionary with the frequency of each element
        foreach (int num in arr)
        {
            if (mp.ContainsKey(num))
                mp[num]++;
            else
                mp[num] = 1;
        }

        // Max-heap (priority queue) to store the frequency and element pair
        PriorityQueue<int, int> maxh = new PriorityQueue<int, int>();

        // Push each element and its frequency into the priority queue
        foreach (var entry in mp)
        {
            maxh.Enqueue(entry.Key, entry.Value);
        }

        // Print the elements in frequency sorted order
        while (maxh.Count > 0)
        {
            int ele = maxh.Dequeue();
            int freq = mp[ele];

            for (int i = 0; i < freq; i++)
            {
                Console.Write(ele + " ");
            }
        }
    }
}
