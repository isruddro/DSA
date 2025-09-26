This is a mountain array code:
https://leetcode.com/problems/find-in-mountain-array/solutions/

# Bitonic array has only one peek. It increases then decreases.
    On the basis of mid. There will be two sorted array in the bitonic array.
   * Mountain Array:
An array that strictly increases to a single peak, then strictly decreases.
There is exactly one peak.
Example: [1, 3, 5, 4, 2]

    * Bitonic Array:
A more general term for an array that first increases then decreases, but it can have:

A single peak (like a mountain array), or

Multiple equal peak elements (plateaus), or

Sometimes non-strict increases/decreases.
cpp:
Time Complexity: O(log n), Space Complexity: O(1)
    
/**
 * // This is the MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *   public:
 *     int get(int index);
 *     int length();
 * };
 */

class Solution {
public:
    // Find peak index in MountainArray
    int peakIndex(MountainArray &mountainArr) {
        int s = 0, e = mountainArr.length() - 1;
        while (s < e) {
            int m = s + (e - s) / 2;
            if (mountainArr.get(m) < mountainArr.get(m + 1)) {
                s = m + 1;
            } else {
                e = m;
            }
        }
        return s;
    }
    
    // Binary search: ascending or descending based on 'ascending' flag
    int binarySearch(MountainArray &mountainArr, int s, int e, int target, bool ascending) {
        while (s <= e) {
            int m = s + (e - s) / 2;
            int val = mountainArr.get(m);
            if (val == target) {
                return m;
            }
            if (val > target) {
                if (ascending) {
                    e = m - 1;
                } else {
                    s = m + 1;
                }
            } else {
                if (ascending) {
                    s = m + 1;
                } else {
                    e = m - 1;
                }
            }
        }
        return -1;
    }
    
    int findInMountainArray(int target, MountainArray &mountainArr) {
        int peak = peakIndex(mountainArr);
        
        // Search ascending part
        int idx = binarySearch(mountainArr, 0, peak, target, true);
        if (idx != -1) return idx;
        
        // Search descending part
        return binarySearch(mountainArr, peak + 1, mountainArr.length() - 1, target, false);
    }
};


py3:
Time Complexity: O(log n), Space Complexity: O(1)

    # This is the MountainArray's API interface.
# You should not implement it, or speculate about its implementation.
# class MountainArray:
#     def get(self, index: int) -> int:
#     def length(self) -> int:

class Solution:
    def peakIndex(self, mountainArr: 'MountainArray') -> int:
        s, e = 0, mountainArr.length() - 1
        while s < e:
            m = s + (e - s) // 2
            if mountainArr.get(m) < mountainArr.get(m + 1):
                s = m + 1
            else:
                e = m
        return s

    def binarySearch(self, mountainArr: 'MountainArray', s: int, e: int, target: int, ascending: bool) -> int:
        while s <= e:
            m = s + (e - s) // 2
            val = mountainArr.get(m)
            if val == target:
                return m
            if val > target:
                if ascending:
                    e = m - 1
                else:
                    s = m + 1
            else:
                if ascending:
                    s = m + 1
                else:
                    e = m - 1
        return -1

    def findInMountainArray(self, target: int, mountainArr: 'MountainArray') -> int:
        peak = self.peakIndex(mountainArr)
        # Search in ascending part
        idx = self.binarySearch(mountainArr, 0, peak, target, True)
        if idx != -1:
            return idx
        # Search in descending part
        return self.binarySearch(mountainArr, peak + 1, mountainArr.length() - 1, target, False)



        

cpp:
#include <iostream>
#include <vector>
using namespace std;

// Function to find the peak index in a bitonic array
int Peak(const vector<int>& arr) {
    int s = 0, e = arr.size() - 1;

    while (s < e) {
        int m = s + (e - s) / 2;
        if (m > 0 && arr[m] < arr[m - 1])
            e = m - 1;
        else if (m < arr.size() - 1 && arr[m] < arr[m + 1])
            s = m + 1;
        else
            return m;
    }

    return s;
}

// Binary search helper function
int Bs(const vector<int>& v, int s, int e, int x, bool dir) {
    while (s <= e) {
        int m = s + (e - s) / 2;
        if (v[m] == x) return m;

        if (v[m] > x) {
            if (dir) e = m - 1;  // ascending part
            else s = m + 1;      // descending part
        } else {
            if (dir) s = m + 1;  // ascending part
            else e = m - 1;      // descending part
        }
    }

    return -1;
}

// Main solution function
int Solve(const vector<int>& A, int B) {
    int s = 0;
    int e = A.size() - 1;
    int m = Peak(A);

    int i = Bs(A, s, m - 1, B, true);  //




c#:

using System;
using System.Collections.Generic;

class Solution
{
    // Function to find the peak index in the array
    static int Peak(List<int> arr)
    {
        int s = 0, e = arr.Count - 1;

        while (s < e)
        {
            int m = s + (e - s) / 2;
            if (m > 0 && arr[m] < arr[m - 1]) e = m - 1;
            else if (m < arr.Count - 1 && arr[m] < arr[m + 1]) s = m + 1;
            else return m;
        }

        return s;
    }

    // Binary search helper function
    static int Bs(List<int> v, int s, int e, int x, bool dir)
    {
        while (s < e)
        {
            int m = s + (e - s) / 2;
            if (v[m] == x) return m;
            if (v[m] > x)
            {
                if (dir) e = m - 1;
                else s = m + 1;
            }
            else
            {
                if (dir) s = m + 1;
                else e = m - 1;
            }
        }

        if (v[s] == x) return s;
        return -1;
    }

    // Main solution function
    public static int Solve(List<int> A, int B)
    {
        int s = 0, m, e = A.Count - 1;

        m = Peak(A);

        int i = Bs(A, s, m - 1, B, true);

        if (i != -1) return i;
        return Bs(A, m, e, B, false);
    }

    static void Main()
    {
        List<int> A = new List<int> { 1, 5, 8, 10, 9, 6, 2 }; // Example array
        int B = 9; // Element to search for

        int result = Solve(A, B);

        Console.WriteLine($"Element {B} found at index: {result}");
    }
}
