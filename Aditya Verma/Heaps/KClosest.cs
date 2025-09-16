https://www.geeksforgeeks.org/problems/k-closest-elements3619/0

# Think of this:
        5 6 6 8 9
abs (-) 7 7 7 7 7
    (=) 2 1 0 1 2
        finally on the basis of the diff we get: 7 6 8 are k(3) closest numbers. (here x is 7)

* Closest means smallest. So we keeping smallest numbers, that is why we deleting maximum numbers. (using maxheap)
    
    In this problem i need to consider abs diffs numbers of k. Both abs diffs (work as key) and the number I need to put on the heap.
    The results will be on the basis of the abs diffs.

py:

import heapq

def k_closest_numbers(arr, k, m):
    # Max-heap: store (-abs_diff, value) to simulate a max-heap
    maxhp = []

    for num in arr:
        diff = abs(num - m)
        heapq.heappush(maxhp, (-diff, -num))  # Use -num to handle tie-breaks if needed

        if len(maxhp) > k:
            heapq.heappop(maxhp)

    # Extract numbers from heap
    result = [-heapq.heappop(maxhp)[1] for _ in range(len(maxhp))]
    result.sort()  # Optional: sort to have them in order closest to farthest
    return result

# Example usage
if __name__ == "__main__":
    arr = [5, 6, 7, 8, 9]
    m = 7  # target
    k = int(input("Enter k: "))
    result = k_closest_numbers(arr, k, m)
    print("The k closest numbers are:", *result)



cpp:
#include <bits/stdc++.h>
using namespace std;

int main() {
    vector<int> arr = {5, 6, 7, 8, 9};
    int k;
    int m = 7; // target
    int n = arr.size();

    cout << "Enter k: ";
    cin >> k;

    // Max-heap: pair<abs_diff, value>, larger diff on top
    priority_queue<pair<int, int>> maxhp;

    for (int num : arr) {
        int diff = abs(num - m);
        maxhp.push({diff, num});

        if ((int)maxhp.size() > k)
            maxhp.pop();
    }

    cout << "The k closest numbers are: ";
    vector<int> result;

    while (!maxhp.empty()) {
        result.push_back(maxhp.top().second);
        maxhp.pop();
    }

    // Optional: sort to have them in order closest to farthest
    sort(result.begin(), result.end());
    for (int num : result)
        cout << num << " ";
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
