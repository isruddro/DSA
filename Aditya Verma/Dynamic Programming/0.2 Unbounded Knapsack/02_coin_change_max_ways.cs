https://leetcode.com/problems/coin-change-ii/description/

# In the include case, we don’t move to i-1, we stay at i. (that is the diff from 0/1 knapsack)

py:
O(n × amount) time, O(n × amount) space, where n = len(coins) and amount is the target sum.


from typing import List

def get_max_number_of_ways(coins: List[int], n: int, target: int) -> int:
    # dp[i][j] = number of ways to make sum j using first i coins
    dp = [[0] * (target + 1) for _ in range(n + 1)]

    # Base case: sum = 0 can always be made with 0 coins
    for i in range(n + 1):
        dp[i][0] = 1

    # Fill DP table
    for i in range(1, n + 1):
        for j in range(target + 1):  # include 0 to handle zeros correctly
            if coins[i - 1] <= j:
                dp[i][j] = dp[i - 1][j] + dp[i][j - coins[i - 1]]  # include or exclude coin
            else:
                dp[i][j] = dp[i - 1][j]  # exclude coin

    return dp[n][target]

class Solution:
    def change(self, amount: int, coins: List[int]) -> int:
        return get_max_number_of_ways(coins, len(coins), amount)


cpp:
#include <iostream>
#include <vector>
using namespace std;

// Function to calculate the maximum number of ways to make change
int GetMaxNumberOfWays(const vector<int>& coins, int n, int sum) {
    vector<vector<int>> dp(n + 1, vector<int>(sum + 1, 0));

    // Initialize base cases
    for (int i = 0; i <= n; i++)
        dp[i][0] = 1; // 1 way to make sum 0: pick no coins

    // Fill dp table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= sum; j++) {
            if (coins[i - 1] <= j)
                dp[i][j] = dp[i - 1][j] + dp[i][j - coins[i - 1]]; // Include or exclude coin
            else
                dp[i][j] = dp[i - 1][j]; // Exclude coin
        }
    }

    return dp[n][sum];
}

int main() {
    int n;
    cin >> n; // Number of coins
    vector<int> coins(n);

    for (int i = 0; i < n; i++)
        cin >> coins[i]; // Coin denominations

    int sum;
    cin >> sum; // Target sum

    int result = GetMaxNumberOfWays(coins, n, sum);
    cout << result << endl;

    return 0;
}





c#:


using System;

public class Solution
{
    // Function to calculate the maximum number of ways to make change
    public int GetMaxNumberOfWays(int[] coins, int n, int sum)
    {
        int[,] dp = new int[n + 1, sum + 1];

        // Initialization: fill dp table
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0)
                    dp[i, j] = 0; // No ways to make change with 0 coins
                if (j == 0)
                    dp[i, j] = 1; // There's one way to make change for sum 0 (pick no coins)
            }
        }

        // Fill dp table based on the recurrence relation
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (coins[i - 1] <= j)
                    dp[i, j] = dp[i - 1, j] + dp[i, j - coins[i - 1]]; // Include or exclude the current coin
                else
                    dp[i, j] = dp[i - 1, j]; // Exclude the current coin
            }
        }

        return dp[n, sum]; // Return the maximum number of ways to make change
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

        // Create solution object and calculate the maximum number of ways
        Solution solution = new Solution();
        int result = solution.GetMaxNumberOfWays(coins, n, sum);

        // Output the result
        Console.WriteLine(result);
    }
}
