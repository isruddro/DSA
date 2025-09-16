# Things to rem:
    At any time we have to choose two minimum number to add. Then overall cost will be minimum at the end.


py:

import heapq

def min_cost_to_connect_ropes(arr):
    cost = 0

    # Convert the list into a min-heap
    heapq.heapify(arr)

    # Connect ropes until there is more than one rope
    while len(arr) >= 2:
        len1 = heapq.heappop(arr)
        len2 = heapq.heappop(arr)

        cost += len1 + len2
        heapq.heappush(arr, len1 + len2)

    return cost

# Example usage
if __name__ == "__main__":
    arr = [1, 2, 3, 4, 5, 6]
    print(min_cost_to_connect_ropes(arr))



cpp:
#include <bits/stdc++.h>
using namespace std;

int main() {
    // Initialize the rope lengths
    vector<int> arr = {1, 2, 3, 4, 5, 6};
    int cost = 0;

    // Min-heap to store the rope lengths
    priority_queue<int, vector<int>, greater<int>> minh;

    // Push all elements into the min-heap
    for (int len : arr) {
        minh.push(len);
    }

    // Connect ropes until there is more than one rope
    while (minh.size() >= 2) {
        int len1 = minh.top(); minh.pop();
        int len2 = minh.top(); minh.pop();

        // Add the cost of connecting the two smallest ropes
        cost += len1 + len2;

        // Push the new connected rope back into the heap
        minh.push(len1 + len2);
    }

    // Output the minimum cost
    cout << cost << endl;

    return 0;
}


c#:
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
