cpp:
#include <bits/stdc++.h>
using namespace std;

struct Pair {
    int first, second;
    Pair(int f, int s) : first(f), second(s) {}
};

// Comparator for max-heap based on squared distance
struct Compare {
    bool operator()(const pair<int, Pair>& a, const pair<int, Pair>& b) {
        return a.first < b.first; // max-heap: larger distance comes first
    }
};

int main() {
    vector<Pair> arr = {
        Pair(1, 3),
        Pair(-2, 2),
        Pair(5, 8),
        Pair(0, 3)
    };
    int k = 2;

    priority_queue<pair<int, Pair>, vector<pair<int, Pair>>, Compare> maxh;

    for (auto &point : arr) {
        int dis = point.first * point.first + point.second * point.second;
        maxh.push({dis, point});

        if ((int)maxh.size() > k)
            maxh.pop();
    }

    vector<Pair> result;
    while (!maxh.empty()) {
        result.push_back(maxh.top().second);
        maxh.pop();
    }

    // Optional: reverse to get points from closest to farthest
    reverse(result.begin(), result.end());

    for (auto &p : result) {
        cout << p.first << ", " << p.second << "; ";
    }
    cout << endl;

    return 0;
}


c#:
using System;
using System.Collections.Generic;

class Solution
{
    public class Pair
    {
        public int First { get; set; }
        public int Second { get; set; }
        
        public Pair(int first, int second)
        {
            First = first;
            Second = second;
        }
    }
    
    static void Main()
    {
        // Initialize the vector of pairs
        List<Pair> arr = new List<Pair>
        {
            new Pair(1, 3),
            new Pair(-2, 2),
            new Pair(5, 8),
            new Pair(0, 3)
        };
        int k = 2;

        // Max-heap (priority queue) to store the distance and pair
        PriorityQueue<(int, Pair), int> maxh = new PriorityQueue<(int, Pair), int>();

        foreach (var point in arr)
        {
            // Calculate the squared distance
            int dis = (point.First * point.First) + (point.Second * point.Second);

            // Push the squared distance and point into the priority queue
            maxh.Enqueue((dis, point), -dis); // Negative distance to simulate max-heap

            // If the size of the priority queue exceeds k, remove the largest element
            if (maxh.Count > k)
            {
                maxh.Dequeue();
            }
        }

        // Output the k closest points
        while (maxh.Count > 0)
        {
            var temp = maxh.Dequeue().Item2; // Extract the point
            Console.Write(temp.First + ", " + temp.Second + "; ");
        }
    }
}
