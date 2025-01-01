using System;

public class Solution
{
    public int Knapsack(int[] wt, int[] val, int W)
    {
        int n = wt.Length;
        int[,] dp = new int[n+1, W+1];

        for(int i=0; i<=n; i++){
            for(int j=0; j<=W; j++){
                //base case of recursive, initialization of bottom up
                if(i==0 || j==0)
                {
                    dp[i, j] = 0;
                }
                
                else if(wt[i-1]<=j)
                {
                    //take current weight
                    int val1 = val[i-1] + dp[i-1, j-wt[i-1]];
                    //skip current weight
                    int val2 = dp[i-1, j];
                    dp[i,j] = Math.Max(val1, val2);
                }

                else{
                    dp[i,j] = dp[i-1, j];
                }
            }
        }
        return dp[n, W];
    }
    public static void Main(string[] args)
    {
        // Example: number of items, weights, values, and capacity
        int[] weights = { 1, 3, 4, 5 };
        int[] values = { 1, 4, 5, 7 };
        int capacity = 7;

        Solution solution = new Solution();
        int maxValue = solution.Knapsack(weights, values, capacity);

        Console.WriteLine(maxValue); // Output: 9
    }
}