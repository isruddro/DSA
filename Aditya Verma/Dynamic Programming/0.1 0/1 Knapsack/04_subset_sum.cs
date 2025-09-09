cpp:

#include <iostream>
#include <vector>
using namespace std;

bool IsSubsetSumPossible(const vector<int>& arr, int sum) {
    int n = arr.size();
    vector<vector<bool>> dp(n + 1, vector<bool>(sum + 1, false));

    // Initialization
    for (int i = 0; i <= n; i++) dp[i][0] = true; // sum = 0 can always be formed
    for (int j = 1; j <= sum; j++) dp[0][j] = false; // no items cannot form sum > 0

    // Build DP table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= sum; j++) {
            if (arr[i - 1] <= j)
                dp[i][j] = dp[i - 1][j - arr[i - 1]] || dp[i - 1][j]; // include or exclude
            else
                dp[i][j] = dp[i - 1][j]; // exclude
        }
    }

    return dp[n][sum];
}

int main() {
    vector<int> arr = {2, 3, 7, 8, 10};
    int sum = 11;

    bool result = IsSubsetSumPossible(arr, sum);
    cout << (result ? "Yes" : "No") << endl; // Output: Yes

    return 0;
}



c#:


using System;

public class Solution
{
    public bool IsSubsetSumPossible(int[] arr, int sum)
    {
        int n = arr.Length;
        bool[,] dp = new bool[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) dp[i, j] = false; // No items, cannot form any sum
                if (j == 0) dp[i, j] = true;  // Sum is zero, can always be formed (by taking no items)
            }
        }

        // Build the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                    dp[i, j] = dp[i - 1, j - arr[i - 1]] || dp[i - 1, j]; // Include or exclude current item
                else
                    dp[i, j] = dp[i - 1, j]; // Exclude current item
            }
        }

        return dp[n, sum];
    }

    public static void Main(string[] args)
    {
        // Example: Array and target sum
        int[] arr = { 2, 3, 7, 8, 10 };
        int sum = 11;

        Solution solution = new Solution();
        bool result = solution.IsSubsetSumPossible(arr, sum);

        Console.WriteLine(result ? "Yes" : "No"); // Output: Yes
    }
}
