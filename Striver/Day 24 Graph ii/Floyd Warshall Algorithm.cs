using System;
using System.Collections.Generic;

public class Solution
{
    public void ShortestDistance(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        // Initialize the matrix for Floyd-Warshall
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == -1)
                {
                    matrix[i, j] = int.MaxValue; // Use a large value to represent infinity
                }
                if (i == j)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        // Perform Floyd-Warshall algorithm
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, k] != int.MaxValue && matrix[k, j] != int.MaxValue)
                    {
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i, k] + matrix[k, j]);
                    }
                }
            }
        }

        // Convert unreachable distances back to -1
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == int.MaxValue)
                {
                    matrix[i, j] = -1;
                }
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        int V = 4;
        int[,] matrix = new int[V, V]
        {
            { 0, 2, -1, -1 },
            { 1, 0, 3, -1 },
            { -1, -1, 0, -1 },
            { 3, 5, 4, 0 }
        };

        Solution obj = new Solution();
        obj.ShortestDistance(matrix);

        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
