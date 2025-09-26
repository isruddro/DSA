https://www.geeksforgeeks.org/problems/egg-dropping-puzzle-1587115620/1

cpp:
Time Complexity: O(n × k × log k) — binary search reduces the inner loop.
    
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    int eggDrop(int n, int k) {
        int MAX_EGGS = n + 1;
        int MAX_FLOORS = k + 1;

        // dp[eggs][floors]
        vector<vector<int>> dp(MAX_EGGS, vector<int>(MAX_FLOORS, -1));

        function<int(int,int)> solve = [&](int eggs, int floors) -> int {
            if (dp[eggs][floors] != -1)
                return dp[eggs][floors];

            if (eggs == 1 || floors == 0 || floors == 1) {
                dp[eggs][floors] = floors;
                return floors;
            }

            int ans = floors;
            int low = 1, high = floors;

            while (low <= high) {
                int mid = low + (high - low) / 2;

                int bottom = solve(eggs - 1, mid - 1);  // Egg breaks
                int top = solve(eggs, floors - mid);    // Egg survives

                int temp = 1 + max(bottom, top);

                if (bottom < top) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }

                ans = min(ans, temp);
            }

            dp[eggs][floors] = ans;
            return ans;
        };

        return solve(n, k);
    }
};


py3:

Time Complexity: O(n × k × log k) — binary search reduces the inner loop.

Space Complexity: O(n × k) for memoization table.

class Solution:
    def eggDrop(self, n, k):
        MAX_EGGS = n + 1
        MAX_FLOORS = k + 1
        dp = [[-1 for _ in range(MAX_FLOORS)] for _ in range(MAX_EGGS)]

        def solve(eggs, floors):
            if dp[eggs][floors] != -1:
                return dp[eggs][floors]

            if eggs == 1 or floors == 0 or floors == 1:
                dp[eggs][floors] = floors
                return floors

            ans = floors
            low, high = 1, floors

            while low <= high:
                mid = low + (high - low) // 2

                bottom = solve(eggs - 1, mid - 1)  # Egg breaks
                top = solve(eggs, floors - mid)    # Egg survives

                temp = 1 + max(bottom, top)

                if bottom < top:
                    low = mid + 1
                else:
                    high = mid - 1

                ans = min(ans, temp)

            dp[eggs][floors] = ans
            return ans

        return solve(n, k)



cpp:
#include <bits/stdc++.h>
using namespace std;

const int MAX_EGGS = 107;
const int MAX_FLOORS = 10007;
int dp[MAX_EGGS][MAX_FLOORS];

// Solve function with binary search optimization
int Solve(int eggs, int floors) {
    if (dp[eggs][floors] != -1)
        return dp[eggs][floors];

    // Base cases
    if (eggs == 1 || floors == 0 || floors == 1)
        return dp[eggs][floors] = floors;

    int ans = floors;
    int low = 1, high = floors;

    while (low <= high) {
        int mid = low + (high - low) / 2;

        int bottom = Solve(eggs - 1, mid - 1); // Egg breaks
        int top = Solve(eggs, floors - mid);   // Egg survives

        int temp = 1 + max(bottom, top);

        if (bottom < top)
            low = mid + 1;
        else
            high = mid - 1;

        ans = min(ans, temp);
    }

    return dp[eggs][floors] = ans;
}

// Main function to initialize DP and solve
int SuperEggDrop(int K, int N) {
    memset(dp, -1, sizeof(dp));
    return Solve(K, N);
}

int main() {
    int K = 3;  // Number of eggs
    int N = 14; // Number of floors

    cout << "Minimum number of trials: " << SuperEggDrop(K, N) << endl;
    return 0;
}


c#:

using System;

class Solution
{
    // Memoization table to store results of subproblems
    const int MAX_EGGS = 107;
    const int MAX_FLOORS = 10007;
    int[,] dp = new int[MAX_EGGS, MAX_FLOORS];

    // Function to solve the problem with a binary search optimization
    public int Solve(int eggs, int floors)
    {
        // If the result is already computed, return it
        if (dp[eggs, floors] != -1)
            return dp[eggs, floors];

        // Base cases: If there is only 1 egg or no or one floor
        if (eggs == 1 || floors == 0 || floors == 1)
        {
            dp[eggs, floors] = floors;
            return floors;
        }

        int ans = floors;
        int low = 1, high = floors;

        // Perform binary search for the optimal floor to drop the egg from
        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            // Bottom represents the case where the egg breaks
            int bottom = Solve(eggs - 1, mid - 1);

            // Top represents the case where the egg does not break
            int top = Solve(eggs, floors - mid);

            // The worst-case scenario for the current floor (taking maximum)
            int temp = 1 + Math.Max(top, bottom);

            // Minimize the answer by trying to reduce the worst-case scenario
            if (bottom < top)
                low = mid + 1;
            else
                high = mid - 1;

            // Update the answer with the minimum value found
            ans = Math.Min(ans, temp);
        }

        // Store the result for the current subproblem
        dp[eggs, floors] = ans;
        return ans;
    }

    // Main function to solve the problem using the Solve method
    public int SuperEggDrop(int K, int N)
    {
        // Initialize dp array with -1 to indicate uncomputed states
        Array.Clear(dp, 0, dp.Length);

        // Call the Solve function to get the answer
        return Solve(K, N);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage:
        Solution solution = new Solution();
        int K = 3; // Number of eggs
        int N = 14; // Number of floors

        int result = solution.SuperEggDrop(K, N);
        Console.WriteLine($"Minimum number of trials: {result}");
    }
}
