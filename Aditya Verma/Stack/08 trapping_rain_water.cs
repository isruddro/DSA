https://leetcode.com/problems/trapping-rain-water/description/

cpp:
Time Complexity: O(n)
Space Complexity: O(n)

#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    int trap(vector<int>& height) {
        int n = height.size();
        if (n == 0) return 0;

        vector<int> maxL(n), maxR(n);

        // Fill maxL array (max height to the left of each element)
        maxL[0] = height[0];
        for (int i = 1; i < n; i++) {
            maxL[i] = max(maxL[i - 1], height[i]);
        }

        // Fill maxR array (max height to the right of each element)
        maxR[n - 1] = height[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            maxR[i] = max(maxR[i + 1], height[i]);
        }

        // Calculate total trapped water
        int total_water = 0;
        for (int i = 0; i < n; i++) {
            total_water += min(maxL[i], maxR[i]) - height[i];
        }

        return total_water;
    }
};


py3:
Time Complexity: O(n)
Space Complexity: O(n)

    
from typing import List

class Solution:
    def trap(self, height: List[int]) -> int:
        n = len(height)
        if n == 0:
            return 0

        maxL = [0] * n
        maxR = [0] * n

        # Fill maxL array (max height to the left of each element)
        maxL[0] = height[0]
        for i in range(1, n):
            maxL[i] = max(maxL[i - 1], height[i])

        # Fill maxR array (max height to the right of each element)
        maxR[n - 1] = height[n - 1]
        for i in range(n - 2, -1, -1):
            maxR[i] = max(maxR[i + 1], height[i])

        # Calculate total trapped water
        total_water = 0
        for i in range(n):
            total_water += min(maxL[i], maxR[i]) - height[i]

        return total_water



cpp:
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

int RainWaterTrapping(const vector<int>& arr) {
    int n = arr.size();
    if (n == 0) return 0;

    vector<int> maxL(n), maxR(n);

    // Initialize first and last elements
    maxL[0] = arr[0];
    maxR[n - 1] = arr[n - 1];

    // Fill maxL array (max height to the left)
    for (int i = 1; i < n; i++) {
        maxL[i] = max(maxL[i - 1], arr[i]);
    }

    // Fill maxR array (max height to the right)
    for (int i = n - 2; i >= 0; i--) {
        maxR[i] = max(maxR[i + 1], arr[i]);
    }

    // Calculate total trapped water
    int totalWater = 0;
    for (int i = 0; i < n; i++) {
        totalWater += min(maxL[i], maxR[i]) - arr[i];
    }

    return totalWater;
}

int main() {
    vector<int> arr = {3, 0, 0, 2, 0, 4};
    int result = RainWaterTrapping(arr);
    cout << "Total trapped rainwater: " << result << endl;
    return 0;
}


c#:
using System;

class Solution
{
    public static int RainWaterTrapping(int[] arr)
    {
        int n = arr.Length;
        int[] maxL = new int[n];
        int[] maxR = new int[n];

        // Initialize the first element of maxL and last element of maxR
        maxL[0] = arr[0];
        maxR[n - 1] = arr[n - 1];

        // Fill maxL array (maximum height to the left of each element)
        for (int i = 1; i < n; i++)
        {
            maxL[i] = Math.Max(maxL[i - 1], arr[i]);
        }

        // Fill maxR array (maximum height to the right of each element)
        for (int i = n - 2; i >= 0; i--)
        {
            maxR[i] = Math.Max(maxR[i + 1], arr[i]);
        }

        // Calculate the total trapped water
        int totalWater = 0;
        for (int i = 0; i < n; i++)
        {
            totalWater += Math.Min(maxL[i], maxR[i]) - arr[i];
        }

        return totalWater;
    }

    static void Main(string[] args)
    {
        int[] arr = { 3, 0, 0, 2, 0, 4 };
        int result = RainWaterTrapping(arr);

        Console.WriteLine("Total trapped rainwater: " + result);
    }
}
