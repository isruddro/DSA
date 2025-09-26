https://www.geeksforgeeks.org/problems/sum-of-elements-between-k1th-and-k2th-smallest-elements3133/1

# Way is to:
    * Make function to find kth smallest element. Then find to k.
    * We need value between two k's. So make for loop and store those then later add to find res.



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

    // Top of max-heap is the kth smallest
    return maxHeap.top();
}

int main() {
    vector<int> arr = {7, 12, 9, 4, 1, 8, 3, 5, 6, 10};
    int k1 = 4, k2 = 8;
    int sum = 0;

    int s = FindKthSmallest(arr, k1);
    int f = FindKthSmallest(arr, k2);

    // Sum elements strictly between k1th and k2th smallest
    for (int num : arr) {
        if (num > s && num < f)
            sum += num;
    }

    cout << sum << endl;

    return 0;
}


py3:

import heapq

def find_kth_smallest(arr, k):
    # Max-heap to store k smallest elements
    max_heap = []

    for num in arr:
        heapq.heappush(max_heap, -num)  # Push negative to simulate max-heap

        if len(max_heap) > k:
            heapq.heappop(max_heap)  # Remove largest among k+1 elements

    # Top of max-heap is the kth smallest (invert back)
    return -max_heap[0]

if __name__ == "__main__":
    arr = [7, 12, 9, 4, 1, 8, 3, 5, 6, 10]
    k1, k2 = 4, 8
    sum_between = 0

    s = find_kth_smallest(arr, k1)
    f = find_kth_smallest(arr, k2)

    # Sum elements strictly between k1th and k2th smallest
    for num in arr:
        if s < num < f:
            sum_between += num

    print(sum_between)




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
        int k1 = 4, k2 = 8;
        int sum = 0;

        // Find the kth smallest elements
        int s = FindKthSmallest(arr, k1);
        int f = FindKthSmallest(arr, k2);

        // Sum elements between k1th and k2th smallest
        foreach (var num in arr)
        {
            if (num > s && num < f)
                sum += num;
        }

        // Output the sum
        Console.WriteLine(sum);
    }
}
