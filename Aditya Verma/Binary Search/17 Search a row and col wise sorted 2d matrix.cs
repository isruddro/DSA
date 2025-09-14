https://leetcode.com/problems/search-a-2d-matrix-ii/description/

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

bool SearchMatrix(const vector<vector<int>>& matrix, int target) {
    int i = 0;
    int j = matrix[0].size() - 1;

    while (i < matrix.size() && j >= 0) {
        if (matrix[i][j] == target)
            return true;
        else if (target < matrix[i][j])
            j--;
        else
            i++;
    }

    return false;
}

int main() {
    vector<vector<int>> matrix = {
        {1, 4, 7, 11},
        {2, 5, 8, 12},
        {3, 6, 9, 16},
        {10, 13, 14, 17}
    };
    int target = 5;

    bool result = SearchMatrix(matrix, target);
    cout << "Element " << target << " found: " << (result ? "true" : "false") << endl;

    return 0;
}



c#:


using System;
using System.Collections.Generic;

class Solution
{
    public static bool SearchMatrix(List<List<int>> matrix, int target)
    {
        int i = 0, j = matrix[0].Count - 1;

        while (i < matrix.Count && j >= 0)
        {
            if (target == matrix[i][j]) return true;
            else if (target < matrix[i][j]) j--;
            else i++;
        }

        return false;
    }

    static void Main()
    {
        var matrix = new List<List<int>>()
        {
            new List<int> { 1, 4, 7, 11 },
            new List<int> { 2, 5, 8, 12 },
            new List<int> { 3, 6, 9, 16 },
            new List<int> { 10, 13, 14, 17 }
        };
        int target = 5;

        bool result = SearchMatrix(matrix, target);

        Console.WriteLine($"Element {target} found: {result}");
    }
}
