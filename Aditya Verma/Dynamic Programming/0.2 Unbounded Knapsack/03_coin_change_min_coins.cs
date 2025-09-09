//on this question we need to check the second row initialization for overflow, that's why we need to check and use INF.
//as it it working on the coin so we need to add 1, not the dp[i-1] that we used to do.
cpp:
#include <bits/stdc++.h>
using namespace std;

int GetMinNumberOfCoins(vector<int>& coins, int n, int sum) {
    int INF = INT_MAX - 1; // Avoid overflow
    vector<vector<int>> dp(n + 1, vector<int>(sum + 1, 0));

    // Initialization
    for (int i = 0; i <= n; i++) {
        for (int j = 0; j <= sum; j++) {
            if (j == 0)
                dp[i][j] = 0; // 0 coins needed to make sum 0
            else if (i == 0)
                dp[i][j] = INF; // Impossible with 0 coins
            else if (i == 1)
                dp[i][j] = (j % coins[0] == 0) ? j / coins[0] : INF; // Only first coin available
        }
    }

    // DP filling
    for (int i = 2; i <= n; i++) {
        for (int j = 1; j <= sum; j++) {
            if (coins[i - 1] <= j)
                dp[i][j] = min(dp[i - 1][j], 1 + dp[i][j - coins[i - 1]]);
            else
                dp[i][j] = dp[i - 1][j];
        }
    }

    return dp[n][sum] == INF ? -1 : dp[n][sum]; // If INF, sum is impossible
}

int main() {
    int n;
    cin >> n;
    vector<int> coins(n);
    for (int i = 0; i < n; i++)
        cin >> coins[i];
    int sum;
    cin >> sum;

    int result = GetMinNumberOfCoins(coins, n, sum);
    cout << result << endl;
    return 0;
}





c#:

using System;

public class Solution
{
    // Function to calculate the minimum number of coins required to make the target sum
    public int GetMinNumberOfCoins(int[] coins, int n, int sum)
    {
        int INF = int.MaxValue - 1; // To avoid overflow
        int[,] dp = new int[n + 1, sum + 1];

        // Initialization
        //first row
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (j == 0)
                    dp[i, j] = 0; // No coins needed to make sum 0
                else if (i == 0)
                    dp[i, j] = INF; // Impossible to make sum with 0 coins

                    //initialization second row
                else if (i == 1)
                {
                    //3/3 where sum is 3 and array of 0 is 3 as well
                    if (j % coins[i - 1] == 0)
                        dp[i, j] = j / coins[i - 1]; // If divisible, use that many coins
                    //4/3 where sum is 4 and array of 0 is 3, not possible to devide, so infinity
                    else
                        dp[i, j] = INF; // Otherwise, it's impossible to make this sum
                }
            }
        }

        // Fill the dp table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (coins[i - 1] <= j)
                    dp[i, j] = Math.Min(dp[i - 1, j], 1 + dp[i, j - coins[i - 1]]);
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }

        // If the value is INF, it means it's impossible to make that sum
        return dp[n, sum] == INF ? -1 : dp[n, sum];
    }

    public static void Main(string[] args)
    {
        // Input: number of coins
        int n = int.Parse(Console.ReadLine());
        int[] coins = new int[n];

        // Input: coin denominations
        string[] coinsInput = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
            coins[i] = int.Parse(coinsInput[i]);

        // Input: target sum
        int sum = int.Parse(Console.ReadLine());

        // Create solution object and calculate the minimum number of coins
        Solution solution = new Solution();
        int result = solution.GetMinNumberOfCoins(coins, n, sum);

        // Output the result
        Console.WriteLine(result);
    }
}
