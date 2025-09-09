cpp:


#include <iostream>
#include <vector>
using namespace std;

// Helper function to check if a subset with given sum exists
bool IsSubsetSumPossible(const vector<int>& arr, int n, int sum) {
    vector<vector<bool>> dp(n + 1, vector<bool>(sum + 1, false));

    // Initialization
    for (int i = 0; i <= n; i++) dp[i][0] = true; // sum = 0 is always possible
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

// Function to check if equal sum partition is possible
bool EqualSumPartitionPossible(const vector<int>& arr) {
    int sum = 0;
    for (int num : arr) sum += num;

    if (sum % 2 != 0) return false; // odd sum cannot be partitioned equally

    return IsSubsetSumPossible(arr, arr.size(), sum / 2);
}

int main() {
    vector<int> arr = {1, 5, 11, 5};

    bool result = EqualSumPartitionPossible(arr);
    cout << (result ? "YES" : "NO") << endl; // Output: YES

    return 0;
}


c#:

using System;

public class Solution
{
    // Helper method to check if a subset with the given sum exists
    public bool IsSubsetSumPossible(int[] arr, int n, int sum)
    {
        bool[,] dp = new bool[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) dp[i, j] = false; // No items, cannot form any sum > 0
                if (j == 0) dp[i, j] = true;  // Sum is zero, always possible
            }
        }

        // Build the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                    dp[i, j] = dp[i - 1, j - arr[i - 1]] || dp[i - 1, j]; // Include or exclude the element
                else
                    dp[i, j] = dp[i - 1, j]; // Exclude the element
            }
        }

        return dp[n, sum];
    }

    // Method to check if equal sum partition is possible
    public bool EqualSumPartitionPossible(int[] arr)
    {
        int sum = 0;

        // Calculate the total sum of the array
        foreach (int num in arr)
            sum += num;

        // If the total sum is odd, equal partition is not possible
        if (sum % 2 != 0) return false;

        // Check if a subset with sum = sum/2 exists
        return IsSubsetSumPossible(arr, arr.Length, sum / 2);
    }

    public static void Main(string[] args)
    {
        // Example array
        int[] arr = { 1, 5, 11, 5 };

        Solution solution = new Solution();
        bool result = solution.EqualSumPartitionPossible(arr);

        Console.WriteLine(result ? "YES" : "NO"); // Output: YES
    }
}
