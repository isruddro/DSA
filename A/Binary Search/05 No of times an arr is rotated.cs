https://www.geeksforgeeks.org/problems/rotation4723/1

# No. of times array is rotated depends on smallest element
    Cos: Rotation count is index of smallest element

    For example:
    ind:    0   1  2  3  4  5  6  7     (sorted)
            2   5  6  8  11 12 15 18
    ind:    0   1  2  3  4  5  6  7     (roated)
            11  12 15 18 2  5  6  8    
cpp:
Time	O(log n)
Space	O(1)

#include <vector>
using namespace std;

class Solution {
public:
    int findKRotation(vector<int>& arr) {
        int n = arr.size();
        int start = 0, end = n - 1;

        // If the array is already sorted (no rotation)
        if (arr[start] <= arr[end]) {
            return 0;
        }

        while (start <= end) {
            int mid = start + (end - start) / 2;
            int next_idx = (mid + 1) % n;
            int prev_idx = (mid - 1 + n) % n;

            // Check if mid is the minimum element
            if (arr[mid] <= arr[next_idx] && arr[mid] <= arr[prev_idx]) {
                return mid;
            }

            // Decide which side to go
            if (arr[mid] <= arr[end]) {
                end = mid - 1;  // minimum on the left side
            } else {
                start = mid + 1;  // minimum on the right side
            }
        }

        return 0;  // fallback, should not happen if array has distinct elements
    }
};



py3:
Time	O(log n)
Space	O(1)

from typing import List

class Solution:
    def findKRotation(self, arr: List[int]) -> int:
        n = len(arr)
        start, end = 0, n - 1

        # If the array is already sorted (no rotation)
        if arr[start] <= arr[end]:
            return 0

        while start <= end:
            mid = start + (end - start) // 2
            next_idx = (mid + 1) % n
            prev_idx = (mid - 1 + n) % n

            # Check if mid is the minimum element
            if arr[mid] <= arr[next_idx] and arr[mid] <= arr[prev_idx]:
                return mid

            # Decide which side to go
            if arr[mid] <= arr[end]:
                end = mid - 1  # minimum on the left side
            else:
                start = mid + 1  # minimum on the right side

        return 0  # fallback, should not happen if array has distinct elements


        
cpp:

#include <iostream>
#include <vector>
using namespace std;

int FindKRotation(const vector<int>& arr, int n) {
    int start = 0, end = n - 1;

    // If the array is already sorted (no rotation)
    if (arr[start] <= arr[end])
        return 0;

    while (start < end) {
        int mid = start + (end - start) / 2;

        // If the mid element is greater than the start, rotation is on the right side
        if (arr[mid] > arr[start]) {
            start = mid;
        } else {
            // Otherwise, rotation point is on the left side
            end = mid;
        }
    }

    // Rotation count is index of smallest element
    return start + 1;
}

int main() {
    vector<int> arr = {15, 18, 2, 3, 6, 12};
    int n = arr.size();

    int rotations = FindKRotation(arr, n);
    cout << "The array is rotated " << rotations << " times." << endl;

    return 0;
}










c#:

using System;

class Program
{
    static int FindKRotation(int[] arr, int n)
    {
        int start = 0, end = n - 1;

        // If the array is already sorted
        if (arr[start] <= arr[end]) 
            return 0;

        while (start < end)
        {
            int mid = start + (end - start) / 2;

            // If the mid element is greater than the start, the rotation point is to the right
            if (arr[mid] > arr[start])
            {
                start = mid;
            }
            else
            {
                // Otherwise, the rotation point is to the left
                end = mid;
            }
        }

        // Return the index of the rotation point
        return start + 1;
    }

    static void Main()
    {
        int[] arr = { 15, 18, 2, 3, 6, 12 };
        int n = arr.Length;

        int rotations = FindKRotation(arr, n);
        Console.WriteLine($"The array is rotated {rotations} times.");
    }
}
