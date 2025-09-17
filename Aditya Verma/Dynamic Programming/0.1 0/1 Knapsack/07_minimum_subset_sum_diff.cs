https://www.geeksforgeeks.org/problems/minimum-sum-partition3317/1

#here we need subset1 and subset2
Suppose you partition the array into two subsets S1 and S2.

sum(S1) = s

sum(S2) = total_sum - s

The difference is |sum(S2) - sum(S1)| = |total_sum - 2*s|.

That’s why we check abs(total_sum - 2*s).





py:

from typing import List

def subset_sums(arr: List[int], n: int, total_sum: int) -> List[int]:
    # DP table: t[i][j] = True if sum j is possible with first i elements
    t = [[False] * (total_sum + 1) for _ in range(n + 1)]

    # Initialization
    for i in range(n + 1):
        t[i][0] = True  # sum = 0 is always possible

    for j in range(1, total_sum + 1):
        t[0][j] = False  # no items cannot form sum > 0

    # Fill DP table
    for i in range(1, n + 1):
        for j in range(1, total_sum + 1):
            if arr[i - 1] <= j:
                t[i][j] = t[i - 1][j - arr[i - 1]] or t[i - 1][j]  # include or exclude
            else:
                t[i][j] = t[i - 1][j]  # exclude

    result = [j for j in range(total_sum + 1) if t[n][j]]
    return result

def min_subset_sum_diff(arr: List[int]) -> int:
    n = len(arr)
    total_sum = sum(arr)

    possible_sums = subset_sums(arr, n, total_sum)
    min_diff = min(abs(total_sum - 2 * s) for s in possible_sums)

    return min_diff

if __name__ == "__main__":
    arr = [1, 2, 3, 9]
    result = min_subset_sum_diff(arr)
    print(result)  # Output: 3





cpp:
#include <iostream>
#include <vector>
#include <cmath>
#include <algorithm>
using namespace std;

// Function to find all possible subset sums
vector<int> IsSubsetPoss(const vector<int>& arr, int n, int sum) {
    vector<vector<bool>> t(n + 1, vector<bool>(sum + 1, false));

    // Initialization
    for (int i = 0; i <= n; i++) t[i][0] = true; // sum = 0 is always possible
    for (int j = 1; j <= sum; j++) t[0][j] = false; // no items cannot form sum > 0

    // Fill DP table
    for (int i = 1; i <= n; i++) {
        for (int j = 1; j <= sum; j++) {
            if (arr[i - 1] <= j)
                t[i][j] = t[i - 1][j - arr[i - 1]] || t[i - 1][j]; // include or exclude
            else
                t[i][j] = t[i - 1][j]; // exclude
        }
    }

    vector<int> result;
    for (int j = 0; j <= sum; j++) {
        if (t[n][j]) result.push_back(j);
    }

    return result;
}

// Function to find the minimum subset sum difference
int MinSubsetSumDiff(const vector<int>& arr) {
    int n = arr.size();
    int range = 0;
    for (int num : arr) range += num;

    vector<int> subsetSums = IsSubsetPoss(arr, n, range);
    int minDiff = INT_MAX;

    for (int s : subsetSums) {
        minDiff = min(minDiff, abs(range - 2 * s));
    }

    return minDiff;
}

int main() {
    vector<int> arr = {1, 2, 3, 9};

    int result = MinSubsetSumDiff(arr);
    cout << result << endl; // Output: 3

    return 0;
}





c#:

using System;
using System.Collections.Generic;

public class Solution
{
    // Function to find all possible subset sums
    public List<int> IsSubsetPoss(int[] arr, int n, int sum)
    {
        bool[,] t = new bool[n + 1, sum + 1]; // DP matrix

        // Initialization
        for (int i = 0; i <= n; i++)
        {
            for (int j = 0; j <= sum; j++)
            {
                if (i == 0) t[i, j] = false;
                if (j == 0) t[i, j] = true;
            }
        }

        // Fill the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= sum; j++)
            {
                if (arr[i - 1] <= j)
                    t[i, j] = t[i - 1, j - arr[i - 1]] || t[i - 1, j];
                else
                    t[i, j] = t[i - 1, j];
            }
        }

        List<int> result = new List<int>(); // List to store all possible subset sums
        for (int j = 0; j <= sum; j++)
        {
            if (t[n, j]) result.Add(j); // Add all the sums which are possible
        }

        return result;
    }

    // Function to find the minimum subset sum difference
    public int MinSubsetSumDiff(int[] arr, int n)
    {
        int range = 0;
        for (int i = 0; i < n; i++)
        {
            range += arr[i]; // Calculate the total sum of the array
        }

        List<int> subsetSums = IsSubsetPoss(arr, n, range);
        int minDiff = int.MaxValue;

        // Find the minimum subset sum difference
        foreach (int sum in subsetSums)
        {
            minDiff = Math.Min(minDiff, Math.Abs(range - 2 * sum));
        }

        return minDiff;
    }

    public static void Main(string[] args)
    {
        // Input array
        int[] arr = { 1, 2, 3, 9 };
        
        Solution solution = new Solution();
        int result = solution.MinSubsetSumDiff(arr, arr.Length);

        Console.WriteLine(result); // Output: 3
    }
}
