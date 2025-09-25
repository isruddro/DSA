https://leetcode.com/problems/search-a-2d-matrix-ii/description/

# So, we start from the last element of the first row (n-1)
    This is to check the 2D array bounds:   while 0 <= i < m and 0 <= j < n:
    We will check three things:
        * If that element is key then we return that index
        * If that element is greater than key we will go left side
        * Else we go down side

# 2D array.
    Every row and column sorted.

Time: O(m + n) — because we move at most m down steps and n left steps.

Space: O(1) — constant extra space.

from typing import List

class Solution:
    def searchMatrix(self, matrix: List[List[int]], target: int) -> bool:
        if not matrix or not matrix[0]:
            return False

        m, n = len(matrix), len(matrix[0])
        i, j = 0, n - 1  # Start from top-right corner

        while i < m and j >= 0:
            if matrix[i][j] == target:
                return True
            elif matrix[i][j] > target:
                j -= 1
            else:  # matrix[i][j] < target
                i += 1

        return False


cpp:

#include <iostream>
#include <vector>
using namespace std;

vector<int> search(vector<vector<int>>& mat, int m, int n, int key) {
    int i = 0, j = n - 1;
    vector<int> res(2, 0);

    while (i >= 0 && i < m && j >= 0 && j < n) {
        if (mat[i][j] == key) {
            res[0] = j; // column index
            res[1] = i; // row index
            return res;
        } else if (mat[i][j] > key) {
            j--;
        } else {
            i++;
        }
    }

    return {}; // not found
}

int main() {
    vector<vector<int>> mat = {
        {10, 20, 30, 40},
        {15, 25, 35, 45},
        {27, 29, 37, 48},
        {32, 33, 39, 50}
    };
    int key = 29;
    int m = mat.size(), n = mat[0].size();

    vector<int> result = search(mat, m, n, key);

    if (!result.empty())
        cout << "Position: [" << result[1] << ", " << result[0] << "]" << endl;
    else
        cout << "Not found" << endl;

    return 0;
}



c#:


using System;

public class Solution {
    public static int[] Search(int[,] mat, int m, int n, int key) {
        int i = 0, j = n - 1;
        int[] res = new int[2];

        while (i >= 0 && i < m && j >= 0 && j < n) {
            if (mat[i, j] == key) {
                res[0] = j; // column index
                res[1] = i; // row index
                return res;
            } else if (mat[i, j] > key) {
                j--;
            } else {
                i++;
            }
        }

        return new int[0]; // not found
    }

    public static void Main(string[] args) {
        int[,] mat = {
            {10, 20, 30, 40},
            {15, 25, 35, 45},
            {27, 29, 37, 48},
            {32, 33, 39, 50}
        };
        int key = 29;
        int m = mat.GetLength(0), n = mat.GetLength(1);

        int[] result = Search(mat, m, n, key);

        if (result.Length > 0)
            Console.WriteLine($"Position: [{result[1]}, {result[0]}]");
        else
            Console.WriteLine("Not found");
    }
}
