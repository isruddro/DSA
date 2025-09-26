BF:


using System;

public class Program
{
    static int[,] Rotate(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int[,] rotated = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                rotated[j, n - i - 1] = matrix[i, j];
            }
        }
        return rotated;
    }

    public static void Main(string[] args)
    {
        int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int[,] rotated = Rotate(arr);
        Console.WriteLine("Rotated Image:");
        for (int i = 0; i < rotated.GetLength(0); i++)
        {
            for (int j = 0; j < rotated.GetLength(1); j++)
            {
                Console.Write(rotated[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}



Optimal:


using System;

public class Program
{
    static void Rotate(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        
        // Transpose the matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[j, i];
                matrix[j, i] = temp;
            }
        }

        // Reverse each row
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                int temp = matrix[i, j];
                matrix[i, j] = matrix[i, n - 1 - j];
                matrix[i, n - 1 - j] = temp;
            }
        }
    }

    public static void Main(string[] args)
    {
        int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        Rotate(arr);
        Console.WriteLine("Rotated Image:");
        
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
