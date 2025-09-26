cpp:
#include <bits/stdc++.h>
using namespace std;

// Function to find the kth largest element
int FindKthLargest(vector<int>& arr, int k) {
    // Min-heap to store the k largest elements
    priority_queue<int, vector<int>, greater<int>> minHeap;

    for (int num : arr) {
        minHeap.push(num);

        // If heap size exceeds k, remove the smallest element
        if ((int)minHeap.size() > k)
            minHeap.pop();
    }

    // Top of min-heap is the kth largest element
    return minHeap.top();
}

int main() {
    vector<int> arr = {56, 89, 44, 65, 33};
    int k;

    cout << "Enter k: ";
    cin >> k;

    cout << FindKthLargest(arr, k) << endl;

    return 0;
}

py3:

import heapq

def find_kth_largest(arr, k):
    # Min-heap to store k largest elements
    min_heap = []

    for num in arr:
        heapq.heappush(min_heap, num)

        # If heap size exceeds k, remove the smallest element
        if len(min_heap) > k:
            heapq.heappop(min_heap)

    # Top of min-heap is the kth largest element
    return min_heap[0]

if __name__ == "__main__":
    arr = [56, 89, 44, 65, 33]
    k = int(input("Enter k: "))
    print(find_kth_largest(arr, k))





c#:

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
