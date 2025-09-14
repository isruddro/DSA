https://www.geeksforgeeks.org/dsa/find-position-element-sorted-array-infinite-numbers/

py:

from typing import List

def binary_search(arr: List[int], s: int, e: int, target: int) -> int:
    while s <= e:
        m = s + (e - s) // 2
        if arr[m] == target:
            return m  # Found target
        elif arr[m] < target:
            s = m + 1
        else:
            e = m - 1
    return -1  # Target not found

def find_position_in_infinite_array(arr: List[int], target: int) -> int:
    s, e = 0, 1

    # Expand the range exponentially
    while e < len(arr) and arr[e] < target:
        s = e
        e *= 2

    # Binary search within the identified range
    return binary_search(arr, s, min(e, len(arr) - 1), target)


if __name__ == "__main__":
    arr = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31]
    target = 19

    result = find_position_in_infinite_array(arr, target)
    if result != -1:
        print(f"Target {target} found at index {result}")
    else:
        print(f"Target {target} not found in the array")



cpp:

#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

// Binary Search function to find target within range [s, e]
int BinarySearch(const vector<int>& arr, int s, int e, int target) {
    while (s <= e) {
        int m = s + (e - s) / 2;
        if (arr[m] == target) return m;  // Found target
        if (arr[m] < target) s = m + 1; // Target in right half
        else e = m - 1;                 // Target in left half
    }
    return -1; // Target not found
}

// Exponential Search to find range and then binary search
int FindPositionInInfiniteArray(const vector<int>& arr, int target) {
    int s = 0, e = 1;

    // Expand the range exponentially
    while (e < arr.size() && arr[e] < target) {
        s = e;
        e *= 2;
    }

    // Binary search within the identified range
    return BinarySearch(arr, s, min(e, (int)arr.size() - 1), target);
}

int main() {
    vector<int> arr = {1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31};
    int target = 19;

    int result = FindPositionInInfiniteArray(arr, target);
    if (result != -1)
        cout << "Target " << target << " found at index " << result << endl;
    else
        cout << "Target " << target << " not found in the array" << endl;

    return 0;
}




c#:


using System;

class Program
{
    // Binary Search function to find the target within the range [s, e]
    static int BinarySearch(int[] arr, int s, int e, int target)
    {
        while (s <= e)
        {
            int m = s + (e - s) / 2;
            if (arr[m] == target) return m;  // Found the target, return the index
            if (arr[m] < target) s = m + 1;  // Target is in the right half
            else e = m - 1;  // Target is in the left half
        }
        return -1;  // Target not found
    }

    // Exponential Search to find the range where the target might be
    static int FindPositionInInfiniteArray(int[] arr, int target)
    {
        int s = 0, e = 1;

        // Expand the range exponentially to find the target's potential range
        while (arr[e] < target)
        {
            s = e;
            e *= 2;  // Double the end index to expand the range
        }

        // Apply binary search within the identified range [s, e]
        return BinarySearch(arr, s, Math.Min(e, arr.Length - 1), target);
    }

    static void Main()
    {
        // Example sorted array (with large size)
        int[] arr = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31 };

        // Let's search for the target value
        int target = 19;

        // Finding the position of the target in the array
        int result = FindPositionInInfiniteArray(arr, target);

        if (result != -1)
            Console.WriteLine($"Target {target} found at index {result}");
        else
            Console.WriteLine($"Target {target} not found in the array");
    }
}
