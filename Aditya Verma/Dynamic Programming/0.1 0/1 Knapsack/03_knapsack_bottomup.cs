#we initialize the first row and first column with base case of 2D matrix


py:

from typing import List

def knapsack(wt: List[int], val: List[int], W: int) -> int:
    n = len(wt)
    dp = [[0 for _ in range(W + 1)] for _ in range(n + 1)]

    for i in range(n + 1):
        for j in range(W + 1):
            if i == 0 or j == 0:
                dp[i][j] = 0  # Base case
            elif wt[i - 1] <= j:
                val1 = val[i - 1] + dp[i - 1][j - wt[i - 1]]  # Take item
                val2 = dp[i - 1][j]                            # Skip item
                dp[i][j] = max(val1, val2)
            else:
                dp[i][j] = dp[i - 1][j]  # Can't take item

    return dp[n][W]


if __name__ == "__main__":
    weights = [1, 3, 4, 5]
    values = [1, 4, 5, 7]
    capacity = 7

    max_value = knapsack(weights, values, capacity)
    print(max_value)  # Output: 9



cpp:

#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

// Iterative Bottom-Up DP for 0/1 Knapsack
int Knapsack(const vector<int>& wt, const vector<int>& val, int W) {
    int n = wt.size();
    vector<vector<int>> dp(n + 1, vector<int>(W + 1, 0));

    for (int i = 0; i <= n; i++) {
        for (int j = 0; j <= W; j++) {
            if (i == 0 || j == 0) {
                dp[i][j] = 0; // base case
            }
            else if (wt[i - 1] <= j) {
                int val1 = val[i - 1] + dp[i - 1][j - wt[i - 1]]; // take item
                int val2 = dp[i - 1][j];                           // skip item
                dp[i][j] = max(val1, val2);
            } else {
                dp[i][j] = dp[i - 1][j]; // can't take item
            }
        }
    }

    return dp[n][W];
}

int main() {
    vector<int> weights = {1, 3, 4, 5};
    vector<int> values = {1, 4, 5, 7};
    int capacity = 7;

    int maxValue = Knapsack(weights, values, capacity);
    cout << maxValue << endl; // Output: 9

    return 0;
}




c#:

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
