https://www.geeksforgeeks.org/problems/sorting-elements-of-an-array-by-frequency-1587115621/1

py:

import heapq
from collections import Counter

def frequency_sort(arr):
    # Count frequency of each element
    freq = Counter(arr)

    # Max-heap: store (-frequency, element) so largest frequency comes first
    maxh = [(-f, num) for num, f in freq.items()]
    heapq.heapify(maxh)

    result = []

    # Extract elements from heap in frequency order
    while maxh:
        f, num = heapq.heappop(maxh)
        result.extend([num] * (-f))  # Multiply by -1 to get original frequency

    return result

# Example usage
if __name__ == "__main__":
    arr = [4, 4, 4, 4, 3, 3, 1, 1, 1, 2]
    print(*frequency_sort(arr))



cpp:
#include <bits/stdc++.h>
using namespace std;

int main() {
    // Initialize the array
    vector<int> arr = {4, 4, 4, 4, 3, 3, 1, 1, 1, 2};
    int n = arr.size();

    // Map to store the frequency of each element
    unordered_map<int, int> freq;
    for (int num : arr) {
        freq[num]++;
    }

    // Max-heap (priority queue) to store pairs of (frequency, element)
    priority_queue<pair<int, int>> maxh;

    for (auto &entry : freq) {
        // Push (frequency, element) pair; priority_queue sorts by first element of pair by default
        maxh.push({entry.second, entry.first});
    }

    // Print elements in frequency sorted order
    while (!maxh.empty()) {
        int f = maxh.top().first;
        int ele = maxh.top().second;
        maxh.pop();

        for (int i = 0; i < f; i++) {
            cout << ele << " ";
        }
    }
    cout << endl;

    return 0;
}


c#:

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
