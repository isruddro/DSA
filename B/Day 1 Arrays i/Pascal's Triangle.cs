V1:


using System;

public class PascalTriangle
{
    public static long NCr(int n, int r)
    {
        long res = 1;

        // Calculate nCr:
        for (int i = 0; i < r; i++)
        {
            res = res * (n - i);
            res = res / (i + 1);
        }
        return res;
    }

    public static int PascalTriangleElement(int r, int c)
    {
        int element = (int)NCr(r - 1, c - 1);
        return element;
    }

    public static void Main(string[] args)
    {
        int r = 5; // Row number
        int c = 3; // Column number
        int element = PascalTriangleElement(r, c);
        Console.WriteLine($"The element at position ({r},{c}) is: {element}");
    }
}



V2:


using System;

public class PascalTriangle
{
    public static long NCr(int n, int r)
    {
        long res = 1;

        // Calculate nCr:
        for (int i = 0; i < r; i++)
        {
            res = res * (n - i);
            res = res / (i + 1);
        }
        return res;
    }

    public static void PascalTriangleRow(int n)
    {
        // Print the nth row of Pascal's Triangle:
        for (int c = 1; c <= n; c++)
        {
            Console.Write(NCr(n - 1, c - 1) + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int n = 5;
        PascalTriangleRow(n);
    }
}


Optimal:

using System;

public class PascalTriangle
{
    static void PrintPascalTriangleRow(int n)
    {
        long ans = 1;
        Console.Write(ans + " "); // Printing the 1st element

        // Printing the rest of the row:
        for (int i = 1; i < n; i++)
        {
            ans = ans * (n - i);
            ans = ans / i;
            Console.Write(ans + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int n = 5;
        PrintPascalTriangleRow(n);
    }
}


V3:


using System;
using System.Collections.Generic;

public class PascalTriangleGenerator
{
    public static int NCr(int n, int r)
    {
        long res = 1;

        // Calculate nCr:
        for (int i = 0; i < r; i++)
        {
            res = res * (n - i);
            res = res / (i + 1);
        }
        return (int)res;
    }

    public static List<List<int>> GeneratePascalTriangle(int n)
    {
        var ans = new List<List<int>>();

        // Store the entire Pascal's Triangle:
        for (int row = 1; row <= n; row++)
        {
            var tempList = new List<int>(); // Temporary list
            for (int col = 1; col <= row; col++)
            {
                tempList.Add(NCr(row - 1, col - 1));
            }
            ans.Add(tempList);
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        int n = 5;
        var ans = GeneratePascalTriangle(n);

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


Optimal:

using System;
using System.Collections.Generic;

public class PascalTriangleGenerator
{
    public static List<int> GenerateRow(int row)
    {
        long ans = 1;
        var ansRow = new List<int>();
        ansRow.Add(1); // Inserting the 1st element

        // Calculate the rest of the elements:
        for (int col = 1; col < row; col++)
        {
            ans = ans * (row - col);
            ans = ans / col;
            ansRow.Add((int)ans);
        }
        return ansRow;
    }

    public static List<List<int>> GeneratePascalTriangle(int n)
    {
        var ans = new List<List<int>>();

        // Store the entire Pascal's Triangle:
        for (int row = 1; row <= n; row++)
        {
            ans.Add(GenerateRow(row));
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        int n = 5;
        var ans = GeneratePascalTriangle(n);

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
