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
