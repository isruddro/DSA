using System;

class MatrixChainMultiplication
{
    const int D = 1000;
    static int[,] t = new int[D, D];

    static int Solve(int[] arr, int i, int j)
    {
        if (i >= j)
        {
            t[i, j] = 0;
            return 0;
        }

        if (t[i, j] != -1)
            return t[i, j];

        int ans = int.MaxValue;
        for (int k = i; k <= j - 1; k++)
        {
            int temp_ans = Solve(arr, i, k) + Solve(arr, k + 1, j) + arr[i - 1] * arr[k] * arr[j];
            ans = Math.Min(ans, temp_ans);
        }

        return t[i, j] = ans;
    }

    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Initialize memoization table with -1
        Array.Clear(t, 0, t.Length);
        
        Console.WriteLine(Solve(arr, 1, n - 1));
    }
}
