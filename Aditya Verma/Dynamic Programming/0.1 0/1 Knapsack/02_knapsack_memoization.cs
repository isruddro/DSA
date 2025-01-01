using System;
public class Solution
{
    const int D = 1000;
    static int[,] = new int[D,D];

    public int Knapsack(int[] wt, int[] val, int W)
    {
        int n = wt.Length;
        //initialization
        for(int i=0; i<=n; i++){
            for(int j=0; j<=W; j++){
                t[i,j] = -1;
            }
        }
        return KnapsackRecursive(wt, val, W, n);
    }

    public int KnapsackRecursive(int[] wt, int[] val, int W, int n)
    {
        //base case
        if(n==0 || W==0)
            return 0;
        
        //if already calculated
        if(t[n, W] !=-1)
            return t[n, W];

        //else calculate
        if(wt[n-1]<=W)
        {
            t[n, W] = Math.Max(val[n-1] + KnapsackRecursive(wt, val, W-wt[n-1], n-1),
                                          KnapsackRecursive(wt, val, W, n-1));
        }
        else
        {
            t[n, W] = KnapsackRecursive(wt, val, W, n-1);
        }
        return t[n, W];
    }
    public static void Main(string[] args)
    {
        // Example weights and values
        int[] weights = { 1, 3, 4, 5 };
        int[] values = { 1, 4, 5, 7 };
        int capacity = 7;

        Solution solution = new Solution();
        int maxValue = solution.Knapsack(weights, values, capacity);

        Console.WriteLine(maxValue); // Output: 9
    }
}