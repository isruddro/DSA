using System;

class Program
{
    static int FindFloor(long[] v, long n, long x)
    {
        long start = 0, end = n - 1;
        int ans = -1;

        while (start <= end)
        {
            int mid = (int)(start + (end - start) / 2);

            if (v[mid] == x)
                return mid;

            if (v[mid] > x)
                end = mid - 1;
            else
            {
                if (ans == -1 || v[mid] > v[ans])
                    ans = mid;

                start = mid + 1;
            }
        }

        return ans;
    }

    static void Main()
    {
        long[] v = { 1, 2, 8, 10, 10, 12, 19 };
        long n = v.Length;
        long x = 5;

        int result = FindFloor(v, n, x);
        Console.WriteLine(result != -1 
            ? $"Floor of {x} is {v[result]} at index {result}" 
            : "No floor found.");
    }
}
