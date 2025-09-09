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
