https://leetcode.com/problems/target-sum/description/


# two eq:
    from question  :s1-s2 = diff
    we know        :s1+s2 = total
    adding two eq: we get: s1= (total+diff) //2
    we can say this in other way: target_sum = (total_sum + diff) // 2

py:

from typing import List

def count_subsets_with_sum(arr: List[int], n: int, target_sum: int) -> int:
    # DP table: t[i][j] = number of subsets using first i elements to sum j
    t = [[0] * (target_sum + 1) for _ in range(n + 1)]

    # Initialization
    for i in range(n + 1):
        t[i][0] = 1  # sum = 0, empty subset

    for j in range(1, target_sum + 1):
        t[0][j] = 0  # no items cannot form sum > 0

    # Fill DP table
    for i in range(1, n + 1):
        for j in range(1, target_sum + 1):
            if arr[i - 1] <= j:
                t[i][j] = t[i - 1][j - arr[i - 1]] + t[i - 1][j]  # include or exclude
            else:
                t[i][j] = t[i - 1][j]  # exclude

    return t[n][target_sum]

def count_subsets_with_diff(arr: List[int], diff: int) -> int:
    total_sum = sum(arr)

    # Check if a valid partition exists
    if (total_sum + diff) % 2 != 0:
        return 0

    target_sum = (total_sum + diff) // 2
    return count_subsets_with_sum(arr, len(arr), target_sum)

if __name__ == "__main__":
    arr = [1, 1, 2, 3]
    diff = 1
    result = count_subsets_with_diff(arr, diff)
    print(result)  # Output: 3



cpp:

#include <iostream>
#include <vector>
using namespace std;

// Function to count subsets with a given sum
int CountSubsetsWithSum(const vector<int>& arr, int n, int sum) {
    vector<vector<int>> t(n + 1, vector<int>(sum + 1, 0));

    // Initialization
    for (int i = 0; i <= n; i++) t[i][0] = 1; // sum = 0 always 1 subset (empty set)
    for (int j = 1; j <= sum; j++) t[0][j] = 0; // no items cannot form sum > 0

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

// Function to count subsets with a given difference
int CountSubsetsWithDiff(const vector<int>& arr, int n, int diff) {
    int sumOfArray = 0;
    for (int num : arr) sumOfArray += num;

    // If (sum + diff) is odd, no valid subset exists
    if ((sumOfArray + diff) % 2 != 0) return 0;

    return CountSubsetsWithSum(arr, n, (sumOfArray + diff) / 2);
}

int main() {
    vector<int> arr = {1, 1, 2, 3};
    int diff = 1;

    int result = CountSubsetsWithDiff(arr, arr.size(), diff);
    cout << result << endl; // Output: 3

    return 0;
}



c#:

using System;

public class Solution
{
    // Function to count the subsets with a given sum
    public int CountSubsetsWithSum(int[] arr, int n, int sum)
    {
        int[,] t = new int[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) t[i, j] = 0;
                if (j == 0) t[i, j] = 1;
            }
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

    // Function to count the subsets with a given difference
    public int CountSubsetsWithDiff(int[] arr, int n, int diff)
    {
        int sumOfArray = 0;
        for (int i = 0; i < n; i++)
        {
            sumOfArray += arr[i]; // Sum of all elements in the array
        }

        // If (sumOfArray + diff) is odd, there is no valid subset
        if ((sumOfArray + diff) % 2 != 0)
            return 0;

        // Count subsets with sum (sumOfArray + diff) / 2
        return CountSubsetsWithSum(arr, n, (sumOfArray + diff) / 2);
    }

    public static void Main(string[] args)
    {
        // Input array
        int[] arr = { 1, 1, 2, 3 };

        Solution solution = new Solution();
        int diff = 1;
        int result = solution.CountSubsetsWithDiff(arr, arr.Length, diff);

        Console.WriteLine(result); // Output: 3
    }
}
