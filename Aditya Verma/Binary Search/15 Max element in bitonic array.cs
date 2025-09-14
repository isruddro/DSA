https://leetcode.com/problems/peak-index-in-a-mountain-array/description/?utm_source=chatgpt.com

py:

from typing import List

def peak_index_in_mountain_array(arr: List[int]) -> int:
    s, e = 0, len(arr) - 1

    while s < e:
        m = s + (e - s) // 2

        # If element at m is less than element at m-1, move left
        if m > 0 and arr[m] < arr[m - 1]:
            e = m - 1
        # If element at m is less than element at m+1, move right
        elif m < len(arr) - 1 and arr[m] < arr[m + 1]:
            s = m + 1
        # Otherwise, m is the peak
        else:
            return m

    # When s == e, we've found the peak index
    return s


if __name__ == "__main__":
    arr = [0, 2, 3, 4, 3, 1, 0]
    peak_index = peak_index_in_mountain_array(arr)
    print(f"Peak index is: {peak_index}")


cpp:
#include <iostream>
#include <vector>
using namespace std;

// Function to find the peak index in a mountain array
int PeakIndexInMountainArray(const vector<int>& arr) {
    int s = 0, e = arr.size() - 1;

    while (s < e) {
        int m = s + (e - s) / 2;

        // If element at m is less than element at m-1, move left
        if (m > 0 && arr[m] < arr[m - 1])
            e = m - 1;
        // If element at m is less than element at m+1, move right
        else if (m < arr.size() - 1 && arr[m] < arr[m + 1])
            s = m + 1;
        // Otherwise, m is the peak
        else
            return m;
    }

    // When s == e, we've found the peak index
    return s;
}

int main() {
    vector<int> arr = {0, 2, 3, 4, 3, 1, 0};

    int peakIndex = PeakIndexInMountainArray(arr);
    cout << "Peak index is: " << peakIndex << endl;

    return 0;
}






c#:

using System;

class Program
{
    // Function to find the peak index in a mountain array
    static int PeakIndexInMountainArray(int[] arr)
    {
        int s = 0, e = arr.Length - 1;

        while (s < e)
        {
            int m = s + (e - s) / 2;

            // If the element at m is less than the element at m-1, move left
            if (m > 0 && arr[m] < arr[m - 1]) e = m - 1;
            // If the element at m is less than the element at m+1, move right
            else if (m < arr.Length - 1 && arr[m] < arr[m + 1]) s = m + 1;
            // If neither condition is true, m is the peak index
            else return m;
        }

        // When s == e, we've found the peak index
        return s;
    }

    static void Main()
    {
        // Example array
        int[] arr = { 0, 2, 3, 4, 3, 1, 0 };

        // Find the peak index in the mountain array
        int peakIndex = PeakIndexInMountainArray(arr);

        // Output the peak index
        Console.WriteLine($"Peak index is: {peakIndex}");
    }
}
