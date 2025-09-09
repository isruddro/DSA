cpp:
#include <bits/stdc++.h>
using namespace std;

void KLarge(vector<int>& arr, int k) {
    // Min-heap to store k largest elements
    priority_queue<int, vector<int>, greater<int>> minHeap;

    for (int num : arr) {
        minHeap.push(num);

        // If heap size exceeds k, remove the smallest
        if ((int)minHeap.size() > k)
            minHeap.pop();
    }

    // Print the k largest elements
    while (!minHeap.empty()) {
        cout << minHeap.top() << "\t";
        minHeap.pop();
    }
    cout << endl;
}

int main() {
    vector<int> arr = {30, 67, 28, 47, 19};

    int k;
    cout << "Enter k: ";
    cin >> k;

    KLarge(arr, k);

    return 0;
}



c#:
using System;
using System.Collections.Generic;

class Solution
{
    // Function to print K largest elements
    static void KLarge(List<int> arr, int k)
    {
        // Min-heap to store k largest elements
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        int n = arr.Count;

        // Traverse through the array
        foreach (var num in arr)
        {
            minHeap.Enqueue(num, num);  // Push elements into the min-heap

            // If the heap exceeds size k, remove the smallest element
            if (minHeap.Count > k)
                minHeap.Dequeue();
        }

        // Print the k largest elements
        while (minHeap.Count > 0)
        {
            Console.Write(minHeap.Dequeue() + "\t");
        }
    }

    static void Main()
    {
        // Array initialization
        List<int> arr = new List<int> { 30, 67, 28, 47, 19 };
        
        // Input for k (number of largest elements to find)
        Console.Write("Enter k: ");
        int k = Convert.ToInt32(Console.ReadLine());

        // Call the function to print K largest elements
        KLarge(arr, k);
    }
}
