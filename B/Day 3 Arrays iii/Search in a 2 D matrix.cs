BF:

using System;
using System.Collections.Generic;

public class Program
{
    public static bool SearchMatrix(List<List<int>> matrix, int target)
    {
        int n = matrix.Count;
        int m = matrix[0].Count;

        // Traverse the matrix:
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i][j] == target)
                    return true;
            }
        }
        return false;
    }

    public static void Main()
    {
        List<List<int>> matrix = new List<List<int>>
        {
            new List<int> { 1, 2, 3, 4 },
            new List<int> { 5, 6, 7, 8 },
            new List<int> { 9, 10, 11, 12 }
        };

        bool result = SearchMatrix(matrix, 8);
        Console.WriteLine(result ? "true" : "false");
    }
}



Better:


using System;
using System.Collections.Generic;

public class Program
{
    // Binary Search to find the target in a row
    public static bool BinarySearch(List<int> nums, int target)
    {
        int n = nums.Count;
        int low = 0, high = n - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (nums[mid] == target)
                return true;
            else if (target > nums[mid])
                low = mid + 1;
            else
                high = mid - 1;
        }
        return false;
    }

    // Search the matrix for the target
    public static bool SearchMatrix(List<List<int>> matrix, int target)
    {
        int n = matrix.Count;
        int m = matrix[0].Count;

        for (int i = 0; i < n; i++)
        {
            // Check if the target could be in this row
            if (matrix[i][0] <= target && target <= matrix[i][m - 1])
            {
                return BinarySearch(matrix[i], target);
            }
        }
        return false;
    }

    public static void Main()
    {
        List<List<int>> matrix = new List<List<int>>()
        {
            new List<int> { 1, 2, 3, 4 },
            new List<int> { 5, 6, 7, 8 },
            new List<int> { 9, 10, 11, 12 }
        };

        bool result = SearchMatrix(matrix, 8);
        Console.WriteLine(result ? "true" : "false");
    }
}



Optimal:


using System;
using System.Collections.Generic;

public class Program
{
    // Binary Search on a flattened matrix
    public static bool SearchMatrix(List<List<int>> matrix, int target)
    {
        int n = matrix.Count; // Number of rows
        int m = matrix[0].Count; // Number of columns

        int low = 0, high = n * m - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int row = mid / m;  // Determine row
            int col = mid % m;  // Determine column

            if (matrix[row][col] == target)
                return true;
            else if (matrix[row][col] < target)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return false;
    }

    public static void Main()
    {
        List<List<int>> matrix = new List<List<int>>()
        {
            new List<int> { 1, 2, 3, 4 },
            new List<int> { 5, 6, 7, 8 },
            new List<int> { 9, 10, 11, 12 }
        };

        bool result = SearchMatrix(matrix, 8);
        Console.WriteLine(result ? "true" : "false");
    }
}


