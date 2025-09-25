https://www.geeksforgeeks.org/problems/rod-cutting0840/1

py:
O(n × n) time, O(n × n) space, where n = len(price)

#User function Template for python3
class Solution:
    def cutRod(self, price):
        n = len(price)
        L = n  # Rod length is equal to number of price entries
        length = [i + 1 for i in range(n)]  # lengths 1, 2, ..., n

        # DP table: dp[i][j] = max profit using first i lengths and rod length j
        dp = [[0] * (L + 1) for _ in range(n + 1)]

        for i in range(1, n + 1):
            for j in range(1, L + 1):
                if length[i - 1] <= j:
                    dp[i][j] = max(dp[i - 1][j], price[i - 1] + dp[i][j - length[i - 1]])
                else:
                    dp[i][j] = dp[i - 1][j]

        return dp[n][L]



cpp:

#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

// Function to calculate the maximum profit from cutting the rod
int GetMaxProfit(const vector<int>& length, const vector<int>& price, int n, int L) {
    vector<vector<int>> dp(n + 1, vector<int>(L + 1, 0));

    // Fill the DP table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= L; j++) {
            if (length[i - 1] <= j)
                dp[i][j] = max(dp[i - 1][j], price[i - 1] + dp[i][j - length[i - 1]]);
            else
                dp[i][j] = dp[i - 1][j];
        }
    }

    return dp[n][L]; // Return the maximum profit
}

int main() {
    int n;
    cin >> n; // Number of different lengths
    vector<int> length(n), price(n);

    for (int i = 0; i < n; i++) cin >> length[i]; // Input lengths
    for (int i = 0; i < n; i++) cin >> price[i];  // Input prices

    int L;
    cin >> L; // Total length of the rod

    int result = GetMaxProfit(length, price, n, L);
    cout << result << endl;

    return 0;
}



c#:


using System;

public class Solution
{
    // Function to calculate the maximum profit from cutting the rod
    public int GetMaxProfit(int[] length, int[] price, int n, int L)
    {
        int[,] dp = new int[n + 1, L + 1]; // DP table

        // Initializing the DP table
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= L; j++)
            {
                if (i == 0 || j == 0)
                    dp[i, j] = 0;
            }
        }

        // Filling the DP table based on the recurrence relation
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= L; j++)
            {
                if (length[i - 1] <= j)
                    dp[i, j] = Math.Max(dp[i - 1, j], price[i - 1] + dp[i, j - length[i - 1]]);
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }

        return dp[n, L]; // Return the maximum profit
    }

    public static void Main(string[] args)
    {
        // Input number of different lengths
        int n = int.Parse(Console.ReadLine());
        int[] length = new int[n];
        int[] price = new int[n];

        // Input lengths
        string[] lengthsInput = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
            length[i] = int.Parse(lengthsInput[i]);

        // Input prices
        string[] pricesInput = Console.ReadLine().Split();
        for (int i = 0; i < n; i++)
            price[i] = int.Parse(pricesInput[i]);

        // Input total length of the rod
        int L = int.Parse(Console.ReadLine());

        // Create solution object and calculate maximum profit
        Solution solution = new Solution();
        int result = solution.GetMaxProfit(length, price, n, L);

        // Output the result
        Console.WriteLine(result);
    }
}
