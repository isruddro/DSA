py:

import heapq

def find_kth_smallest(arr, k):
    # Max-heap to store k smallest elements (invert values)
    max_heap = []

    for num in arr:
        # Push inverted number to simulate max-heap
        heapq.heappush(max_heap, -num)

        # If heap size exceeds k, remove the largest (smallest negative)
        if len(max_heap) > k:
            heapq.heappop(max_heap)

    # Top of max-heap (inverted back) is the kth smallest element
    return -max_heap[0]

if __name__ == "__main__":
    arr = [7, 12, 9, 4, 1, 8, 3, 5, 6, 10]
    k = int(input("Enter position: "))
    print(find_kth_smallest(arr, k))



cpp:
#include <bits/stdc++.h>
using namespace std;

// Function to find the kth smallest element
int FindKthSmallest(vector<int>& arr, int k) {
    // Max-heap to store the k smallest elements
    priority_queue<int> maxHeap;

    for (int num : arr) {
        maxHeap.push(num);

        // If heap size exceeds k, remove the largest element
        if ((int)maxHeap.size() > k)
            maxHeap.pop();
    }

    // Top of max-heap is the kth smallest element
    return maxHeap.top();
}

int main() {
    vector<int> arr = {7, 12, 9, 4, 1, 8, 3, 5, 6, 10};
    int k;

    cout << "Enter position: ";
    cin >> k;

    cout << FindKthSmallest(arr, k) << endl;

    return 0;
}



c#:
using System;
using System.Collections.Generic;

class Solution
{
    // Function to find the kth smallest element in an array
    static int FindKthSmallest(List<int> arr, int k)
    {
        int n = arr.Count;

        // Max-heap (priority queue) to store the k smallest elements
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        foreach (var num in arr)
        {
            maxHeap.Enqueue(num, -num);  // Invert the number to simulate max-heap behavior

            // If the heap size exceeds k, remove the largest element
            if (maxHeap.Count > k)
                maxHeap.Dequeue();
        }

        // The top of the max-heap contains the kth smallest element
        return maxHeap.Peek();
    }

    static void Main()
    {
        // Array of integers
        List<int> arr = new List<int> { 7, 12, 9, 4, 1, 8, 3, 5, 6, 10 };
        int k;

        Console.WriteLine("Enter position: ");
        k = Convert.ToInt32(Console.ReadLine());  // Input position k

        // Find and print the kth smallest element
        Console.WriteLine(FindKthSmallest(arr, k));
    }
}
