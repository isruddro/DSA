# In this prob:
    We need to consider number and frequency.
        

py:


import heapq
from collections import Counter

def top_k_frequent(arr, k):
    # Count frequency of each element
    freq_map = Counter(arr)

    # Min-heap: store (frequency, number), smallest frequency on top
    min_heap = []

    for num, freq in freq_map.items():
        heapq.heappush(min_heap, (freq, num))
        if len(min_heap) > k:
            heapq.heappop(min_heap)  # Remove element with smallest frequency

    # Extract top k elements
    result = [heapq.heappop(min_heap)[1] for _ in range(len(min_heap))]
    result.reverse()  # Optional: from highest to lowest frequency
    return result

# Example usage
if __name__ == "__main__":
    arr = [1, 1, 1, 3, 3, 2, 4]
    k = 2
    result = top_k_frequent(arr, k)
    print(f"Top {k} frequent numbers:", *result)



cpp:
#include <bits/stdc++.h>
using namespace std;

int main() {
    vector<int> arr = {1, 1, 1, 3, 3, 2, 4};
    int n = arr.size();
    int k = 2; // top k frequent elements

    // Count frequency of each element
    unordered_map<int, int> freqMap;
    for (int num : arr) {
        freqMap[num]++;
    }

    // Min-heap: pair<frequency, number>, smallest frequency on top
    priority_queue<pair<int,int>, vector<pair<int,int>>, greater<pair<int,int>>> minHeap;

    for (auto &p : freqMap) {
        minHeap.push({p.second, p.first});
        if ((int)minHeap.size() > k)
            minHeap.pop(); // remove element with smallest frequency
    }

    // Extract top k elements
    vector<int> result;
    while (!minHeap.empty()) {
        result.push_back(minHeap.top().second);
        minHeap.pop();
    }

    cout << "Top " << k << " frequent numbers: ";
    for (int num : result) cout << num << " ";
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
        // Initialize the array and other variables
        List<int> arr = new List<int> { 1, 1, 1, 3, 3, 2, 4 };
        int n = arr.Count;
        int k = 2; // Number of top frequent elements to find

        // Dictionary to store frequency of each element
        Dictionary<int, int> freqMap = new Dictionary<int, int>();

        // Calculate frequencies of each element
        foreach (int num in arr)
        {
            if (freqMap.ContainsKey(num))
                freqMap[num]++;
            else
                freqMap[num] = 1;
        }

        // Min-heap (priority queue) to store top k frequent elements
        PriorityQueue<(int, int), int> minHeap = new PriorityQueue<(int, int), int>();

        // Push each element with its frequency into the heap
        foreach (var pair in freqMap)
        {
            minHeap.Enqueue((pair.Value, pair.Key), pair.Value); // Min-heap based on frequency
            if (minHeap.Count > k)
                minHeap.Dequeue(); // Remove the least frequent element if the size exceeds k
        }

        // Output the top k frequent numbers
        Console.WriteLine("Top " + k + " frequent numbers:");
        while (minHeap.Count > 0)
        {
            Console.Write(minHeap.Dequeue().Item2 + " "); // Extract the number from the tuple
        }
    }
}
