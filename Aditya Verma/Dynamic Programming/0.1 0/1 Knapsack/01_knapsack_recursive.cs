using System;
class Program
{
    static int Knapsack(int[] wt, int[] val, int W, int n)
    {
        //base case
        if(n==0 || W==0)
            return 0;
        
        //recursive case
        if(wt[n-1]<=W)
        {
            return Math.Max(val(n-1) + Knapsack(wt, val, W-wt[n-1], n-1),
                                       Knapsack(wt, val, W, n-1));
        }
        else
        {
            return Knapsack(wt, val, W, n-1);
        }
    }
     static void Main(string[] args)
    {
        // Hardcoded weights, values, and capacity
        int[] wt = { 1, 3, 4, 5 }; // Weights
        int[] val = { 1, 4, 5, 7 }; // Values
        int W = 7; // Knapsack capacity

        int n = wt.Length; // Number of items

        // Output result
        Console.WriteLine(Knapsack(wt, val, W, n));
    }
}