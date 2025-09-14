https://www.geeksforgeeks.org/problems/perfect-sum-problem5633/1

py:

from typing import List

def count_subsets(arr: List[int], n: int, target: int) -> int:
    dp = [[0 for _ in range(target + 1)] for _ in range(n + 1)]

    # Initialization
    for i in range(n + 1):
        dp[i][0] = 1  # sum = 0, one subset (empty set)
    for j in range(1, target + 1):
        dp[0][j] = 0  # no items, 0 subsets for non-zero sum

    # Fill DP table
    for i in range(1, n + 1):
        for j in range(1, target + 1):
            if arr[i - 1] <= j:
                dp[i][j] = dp[i - 1][j - arr[i - 1]] + dp[i - 1][j]  # include or exclude
            else:
                dp[i][j] = dp[i - 1][j]  # exclude

    return dp[n][target]

if __name__ == "__main__":
    arr = [2, 3, 5, 6, 8, 10]
    target = 10
    result = count_subsets(arr, len(arr), target)
    print(result)  # Output: 3



cpp:
#include <iostream>
#include <vector>
using namespace std;

int CountSubsets(const vector<int>& arr, int n, int sum) {
    vector<vector<int>> dp(n + 1, vector<int>(sum + 1, 0));

    // Initialization
    for (int i = 0; i <= n; i++) dp[i][0] = 1; // sum = 0, one subset (empty set)
    for (int j = 1; j <= sum; j++) dp[0][j] = 0; // no items, 0 subsets for non-zero sum

    // Fill DP table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= sum; j++) {
            if (arr[i - 1] <= j) {
                dp[i][j] = dp[i - 1][j - arr[i - 1]] + dp[i - 1][j]; // include or exclude
            } else {
                dp[i][j] = dp[i - 1][j]; // exclude
            }
        }
    }

    return dp[n][sum];
}

int main() {
    vector<int> arr = {2, 3, 5, 6, 8, 10};
    int sum = 10;

    int result = CountSubsets(arr, arr.size(), sum);
    cout << result << endl; // Output: 3

    return 0;
}




c#:

using System;

public class Solution
{
    public int CountSubsets(int[] arr, int n, int sum)
    {
        int[,] dp = new int[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) dp[i, j] = 0; // No items, 0 subsets with non-zero sum
                if (j == 0) dp[i, j] = 1; // Sum is zero, always one subset (empty set)
            }
        }

        // Fill the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                {
                    // Include the current item or exclude it
                    dp[i, j] = dp[i - 1, j - arr[i - 1]] + dp[i - 1, j];
                }
                else
                {
                    // Exclude the current item
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        return dp[n, sum];
    }

    public static void Main(string[] args)
    {
        // Input array and sum
        int[] arr = { 2, 3, 5, 6, 8, 10 };
        int sum = 10;

        Solution solution = new Solution();
        int result = solution.CountSubsets(arr, arr.Length, sum);

        Console.WriteLine(result); // Output: 3
    }
}
