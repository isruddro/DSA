using System;

class Solution
{
    // Function to check if it's possible to allocate pages such that no student
    // reads more than 'Pages' pages within 'days' days
    static bool Check(int[] A, int N, int days, int Pages)
    {
        int curr = 0, d = 1;

        for (int i = 0; i < N; i++)
        {
            curr += A[i];
            if (curr > Pages)
            {
                curr = A[i];
                d++;
                if (d > days) return false;
            }
        }

        return true;
    }

    // Function to find the minimum number of pages that can be assigned
    // to each student
    static int FindPages(int[] A, int N, int M)
    {
        if (M > N) return -1;

        int mx = 0, mn = int.MinValue;

        for (int i = 0; i < N; i++)
        {
            mn = Math.Max(mn, A[i]);
            mx += A[i];
        }

        // Binary search to find the answer
        while (mn < mx)
        {
            int mid = mn + (mx - mn) / 2;
            if (Check(A, N, M, mid)) mx = mid;
            else mn = mid + 1;
        }

        return mn;
    }

    static void Main()
    {
        int[] A = { 12, 34, 67, 90 };  // Number of pages in books
        int N = A.Length;              // Number of books
        int M = 2;                     // Number of students

        int result = FindPages(A, N, M);

        Console.WriteLine($"The minimum number of pages that can be assigned: {result}");
    }
}
