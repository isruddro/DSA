https://leetcode.com/problems/target-sum/description/



cpp:

#include <iostream>
#include <vector>
using namespace std;

// Function to count subsets with a given sum
int CountSubsetsWithSum(const vector<int>& arr, int n, int sum) {
    vector<vector<int>> t(n + 1, vector<int>(sum + 1, 0));

    // Base case: sum = 0, one way (empty subset)
    for (int i = 0; i <= n; i++) t[i][0] = 1;

    // Fill DP table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= sum; j++) {
            if (arr[i - 1] <= j)
                t[i][j] = t[i - 1][j - arr[i - 1]] + t[i - 1][j]; // include or exclude
            else
                t[i][j] = t[i - 1][j]; // exclude
        }
    }

    return t[n][sum];
}

// Function to count subsets with the target sum based on difference
int TargetSum(const vector<int>& arr, int n, int diff) {
    int sumOfArray = 0;
    for (int num : arr) sumOfArray += num;

    // If (sum + diff) is odd, no valid solution
    if ((sumOfArray + diff) % 2 != 0) return 0;

    // Reduce to subset sum problem
    return CountSubsetsWithSum(arr, n, (sumOfArray + diff) / 2);
}

int main() {
    vector<int> arr = {1, 1, 2, 3};
    int diff = 1;

    int result = TargetSum(arr, arr.size(), diff);
    cout << result << endl; // Output: 3

    return 0;
}



py3:

from typing import List

def count_subsets_with_sum(arr: List[int], n: int, target_sum: int) -> int:
    # DP table: t[i][j] = number of subsets using first i elements to sum j
    t = [[0] * (target_sum + 1) for _ in range(n + 1)]

    # Base case: sum = 0 can always be formed with empty subset
    for i in range(n + 1):
        t[i][0] = 1

    # Fill DP table
    for i in range(1, n + 1):
        for j in range(1, target_sum + 1):
            if arr[i - 1] <= j:
                t[i][j] = t[i - 1][j - arr[i - 1]] + t[i - 1][j]  # include or exclude
            else:
                t[i][j] = t[i - 1][j]  # exclude

    return t[n][target_sum]

def target_sum(arr: List[int], diff: int) -> int:
    total_sum = sum(arr)

    # If (sum + diff) is odd, no valid subset exists
    if (total_sum + diff) % 2 != 0:
        return 0

    target = (total_sum + diff) // 2
    return count_subsets_with_sum(arr, len(arr), target)

if __name__ == "__main__":
    arr = [1, 1, 2, 3]
    diff = 1
    result = target_sum(arr, diff)
    print(result)  # Output: 3





c#:


using System;

public class Solution
{
    // Function to count the subsets with a given sum
    public int CountSubsetsWithSum(int[] arr, int n, int sum)
    {
        int[,] t = new int[n + 1, sum + 1]; // DP matrix
        t[0, 0] = 1; // Base case: There's one way to make sum 0 (empty subset)

        // Initialize first column (for all sums of 0, there is 1 way: the empty subset)
        for (int i = 1; i <= n; i++)
        {
            t[i, 0] = 1; // There is one way to make sum 0: by not including any elements
        }

        // DP filling
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                    t[i, j] = t[i - 1, j - arr[i - 1]] + t[i - 1, j];
                else
                    t[i, j] = t[i - 1, j];
            }
        }

        return t[n, sum];
    }

    // Function to count the subsets with the target sum based on the given difference
    public int TargetSum(int[] arr, int n, int diff)
    {
        int sumOfArray = 0;
        for (int i = 0; i < n; i++)
        {
            sumOfArray += arr[i]; // Sum of all elements in the array
        }

        // If (sumOfArray + diff) is odd, there's no valid solution
        if ((sumOfArray + diff) % 2 != 0)
            return 0;

        // Reduce the problem to counting subsets with sum (sumOfArray + diff) / 2
        return CountSubsetsWithSum(arr, n, (sumOfArray + diff) / 2);
    }

    public static void Main(string[] args)
    {
        // Input array and target sum (diff)
        int[] arr = { 1, 1, 2, 3 };
        int diff = 1;

        Solution solution = new Solution();
        int result = solution.TargetSum(arr, arr.Length, diff);

        Console.WriteLine(result); // Output: 3
    }
}
