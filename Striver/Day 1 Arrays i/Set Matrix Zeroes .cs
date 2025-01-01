BF:

using System;
using System.Collections.Generic;

public class ZeroMatrix
{
    static void MarkRow(List<List<int>> matrix, int n, int m, int rowIndex)
    {
        // Set all non-zero elements as -1 in the specified row:
        for (int col = 0; col < m; col++)
        {
            if (matrix[rowIndex][col] != 0)
            {
                matrix[rowIndex][col] = -1;
            }
        }
    }

    static void MarkCol(List<List<int>> matrix, int n, int m, int colIndex)
    {
        // Set all non-zero elements as -1 in the specified column:
        for (int row = 0; row < n; row++)
        {
            if (matrix[row][colIndex] != 0)
            {
                matrix[row][colIndex] = -1;
            }
        }
    }

    static List<List<int>> ZeroMatrix(List<List<int>> matrix, int n, int m)
    {
        // Set -1 for rows and cols that contain 0. Don't mark any 0 as -1:
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                if (matrix[row][col] == 0)
                {
                    MarkRow(matrix, n, m, row);
                    MarkCol(matrix, n, m, col);
                }
            }
        }

        // Finally, mark all -1 as 0:
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                if (matrix[row][col] == -1)
                {
                    matrix[row][col] = 0;
                }
            }
        }

        return matrix;
    }

    public static void Main(string[] args)
    {
        List<List<int>> matrix = new List<List<int>>
        {
            new List<int> { 1, 1, 1 },
            new List<int> { 1, 0, 1 },
            new List<int> { 1, 1, 1 }
        };

        int n = matrix.Count;
        int m = matrix[0].Count;

        List<List<int>> result = ZeroMatrix(matrix, n, m);

        Console.WriteLine("The Final matrix is: ");
        foreach (var row in result)
        {
            foreach (var element in row)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}




Better:

using System;
using System.Collections.Generic;

public class ZeroMatrixOptimized
{
    static List<List<int>> ZeroMatrix(List<List<int>> matrix, int n, int m)
    {
        int[] row = new int[n]; // row array
        int[] col = new int[m]; // col array

        // Traverse the matrix:
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i][j] == 0)
                {
                    // Mark ith index of row with 1:
                    row[i] = 1;

                    // Mark jth index of col with 1:
                    col[j] = 1;
                }
            }
        }

        // Finally, mark all (i, j) as 0
        // if row[i] or col[j] is marked with 1.
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (row[i] == 1 || col[j] == 1)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        return matrix;
    }

    public static void Main(string[] args)
    {
        List<List<int>> matrix = new List<List<int>>
        {
            new List<int> { 1, 1, 1 },
            new List<int> { 1, 0, 1 },
            new List<int> { 1, 1, 1 }
        };

        int n = matrix.Count;
        int m = matrix[0].Count;

        List<List<int>> result = ZeroMatrix(matrix, n, m);

        Console.WriteLine("The Final matrix is: ");
        foreach (var row in result)
        {
            foreach (var element in row)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}


Optimal:

using System;
using System.Collections.Generic;

public class MainClass
{
    static List<List<int>> ZeroMatrix(List<List<int>> matrix, int n, int m)
    {
        // int[] row = new int[n]; --> matrix[..][0]
        // int[] col = new int[m]; --> matrix[0][..]

        int col0 = 1;
        // Step 1: Traverse the matrix and
        // mark 1st row & col accordingly:
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i][j] == 0)
                {
                    // Mark i-th row:
                    matrix[i][0] = 0;

                    // Mark j-th column:
                    if (j != 0)
                        matrix[0][j] = 0;
                    else
                        col0 = 0;
                }
            }
        }

        // Step 2: Mark with 0 from (1,1) to (n-1, m-1):
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                if (matrix[i][j] != 0)
                {
                    // Check for col & row:
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        // Step 3: Finally mark the 1st col & then 1st row:
        if (matrix[0][0] == 0)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[0][j] = 0;
            }
        }
        if (col0 == 0)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i][0] = 0;
            }
        }

        return matrix;
    }

    public static void Main(string[] args)
    {
        List<List<int>> matrix = new List<List<int>>
        {
            new List<int> { 1, 1, 1 },
            new List<int> { 1, 0, 1 },
            new List<int> { 1, 1, 1 }
        };

        int n = matrix.Count;
        int m = matrix[0].Count;

        List<List<int>> ans = ZeroMatrix(matrix, n, m);

        Console.WriteLine("The Final matrix is: ");
        foreach (var row in ans)
        {
            foreach (var ele in row)
            {
                Console.Write(ele + " ");
            }
            Console.WriteLine();
        }
    }
}
