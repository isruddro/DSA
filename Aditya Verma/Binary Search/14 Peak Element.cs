https://leetcode.com/problems/peak-index-in-a-mountain-array/description/?utm_source=chatgpt.com

# Given array is unsorted array.
    * Peek element is greater than its neighbour.


py:


from typing import List

def find_peak_element(arr: List[int]) -> int:
    s, e = 0, len(arr) - 1

    while s < e:
        m = s + (e - s) // 2

        # If the element at m is smaller than the element at m-1, move left
        if m > 0 and arr[m] < arr[m - 1]:
            e = m - 1
        # If the element at m is smaller than the element at m+1, move right
        elif m < len(arr) - 1 and arr[m] < arr[m + 1]:
            s = m + 1
        # If neither, m is the peak
        else:
            return m

    # When s == e, we've found the peak
    return s


if __name__ == "__main__":
    arr = [1, 2, 3, 1]
    peak_index = find_peak_element(arr)
    print(f"Peak element is at index: {peak_index}")

        
        
cpp:

#include <iostream>
#include <vector>
using namespace std;

// Function to find the peak element in the array
int FindPeakElement(const vector<int>& arr) {
    int s = 0, e = arr.size() - 1;

    while (s < e) {
        int m = s + (e - s) / 2;

        // If the element at m is smaller than the element at m-1, move left
        if (m > 0 && arr[m] < arr[m - 1])
            e = m - 1;
        // If the element at m is smaller than the element at m+1, move right
        else if (m < arr.size() - 1 && arr[m] < arr[m + 1])
            s = m + 1;
        // If neither, m is the peak
        else
            return m;
    }

    // When s == e, we've found the peak
    return s;
}

int main() {
    vector<int> arr = {1, 2, 3, 1};

    int peakIndex = FindPeakElement(arr);
    cout << "Peak element is at index: " << peakIndex << endl;

    return 0;
}



c#:

using System;

class Program
{
    // Function to find the peak element in the array
    static int FindPeakElement(int[] arr)
    {
        int s = 0, e = arr.Length - 1;

        while (s < e)
        {
            int m = s + (e - s) / 2;

            // If the element at m is smaller than the element at m-1, move left
            if (m > 0 && arr[m] < arr[m - 1]) e = m - 1;
            // If the element at m is smaller than the element at m+1, move right
            else if (m < arr.Length - 1 && arr[m] < arr[m + 1]) s = m + 1;
            // If neither condition is true, m is the peak element
            else return m;
        }

        // When s == e, we've found the peak
        return s;
    }

    static void Main()
    {
        // Example array
        int[] arr = { 1, 2, 3, 1 };

        // Find the peak element
        int peakIndex = FindPeakElement(arr);

        // Output the index of the peak element
        Console.WriteLine($"Peak element is at index: {peakIndex}");
    }
}
