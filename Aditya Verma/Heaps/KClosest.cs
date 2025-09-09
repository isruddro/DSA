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
