
# Bitonic array has only one peek. It increases then decreases.
    On the basis of mid. There will be two sorted array in the bitonic array.


py:
from typing import List

def peak(arr: List[int]) -> int:
    s, e = 0, len(arr) - 1
    while s < e:
        m = s + (e - s) // 2
        if m > 0 and arr[m] < arr[m - 1]:
            e = m - 1
        elif m < len(arr) - 1 and arr[m] < arr[m + 1]:
            s = m + 1
        else:
            return m
    return s

def bs(v: List[int], s: int, e: int, x: int, ascending: bool) -> int:
    while s <= e:
        m = s + (e - s) // 2
        if v[m] == x:
            return m
        if v[m] > x:
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

def solve(A: List[int], B: int) -> int:
    m = peak(A)
    # Search in ascending part
    idx = bs(A, 0, m, B, True)
    if idx != -1:
        return idx
    # Search in descending part
    return bs(A, m + 1, len(A) - 1, B, False)

if __name__ == "__main__":
    A = [1, 3, 8, 12, 4, 2]
    B = 4
    result = solve(A, B)
    print(f"Element {B} found at index: {result}" if result != -1 else f"Element {B} not found")




        

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
