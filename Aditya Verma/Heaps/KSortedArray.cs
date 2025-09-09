py:

import heapq

def sort_using_minheap(arr, k):
    min_heap = []
    result = []

    for num in arr:
        heapq.heappush(min_heap, num)

        # If heap size exceeds k, pop the smallest and add to result
        if len(min_heap) > k:
            result.append(heapq.heappop(min_heap))

    # Empty remaining elements in the heap
    while min_heap:
        result.append(heapq.heappop(min_heap))

    return result

# Example usage
if __name__ == "__main__":
    arr = [6, 5, 3, 2, 8, 10, 9]
    k = 3
    sorted_arr = sort_using_minheap(arr, k)
    print("Sorted array:", *sorted_arr)



cpp:
#include <bits/stdc++.h>
using namespace std;

int main() {
    vector<int> arr = {6, 5, 3, 2, 8, 10, 9};
    int k = 3;

    vector<int> v; // To store the sorted result
    int n = arr.size();

    // Min-heap to keep the smallest elements
    priority_queue<int, vector<int>, greater<int>> minHeap;

    for (int num : arr) {
        minHeap.push(num);

        // If heap size exceeds k, pop the smallest element and add to result
        if ((int)minHeap.size() > k) {
            v.push_back(minHeap.top());
            minHeap.pop();
        }
    }

    // Empty the heap and add remaining elements to result
    while (!minHeap.empty()) {
        v.push_back(minHeap.top());
        minHeap.pop();
    }

    // Print the sorted array
    for (int num : v) {
        cout << num << " ";
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
