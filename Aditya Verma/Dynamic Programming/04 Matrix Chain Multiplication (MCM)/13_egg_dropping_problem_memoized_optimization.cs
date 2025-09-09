cpp:
#include <bits/stdc++.h>
using namespace std;

const int D = 101;
int dp[D][D];

// Function to solve Egg Dropping Puzzle with memoization
int Solve(int eggs, int floors) {
    if (dp[eggs][floors] != -1) 
        return dp[eggs][floors];

    // Base cases
    if (eggs == 1 || floors == 0 || floors == 1) {
        dp[eggs][floors] = floors;
        return floors;
    }

    int mn = INT_MAX;

    // Try every floor
    for (int k = 1; k <= floors; k++) {
        int top, bottom;

        if (dp[eggs - 1][k - 1] != -1)
            top = dp[eggs - 1][k - 1];
        else
            top = Solve(eggs - 1, k - 1);

        if (dp[eggs][floors - k] != -1)
            bottom = dp[eggs][floors - k];
        else
            bottom = Solve(eggs, floors - k);

        mn = min(mn, 1 + max(top, bottom));
    }

    dp[eggs][floors] = mn;
    return mn;
}

int main() {
    int eggs, floors;
    cin >> eggs >> floors;

    // Initialize dp array with -1
    for (int i = 0; i < D; i++)
        for (int j = 0; j < D; j++)
            dp[i][j] = -1;

    cout << Solve(eggs, floors) << endl;
    return 0;
}



c#:

using System;

class Program
{
    const int D = 101;
    static int[,] dp = new int[D, D];

    // Function to solve the Egg Dropping Puzzle with memoization
    static int Solve(int eggs, int floors)
    {
        // If the result is already computed, return it
        if (dp[eggs, floors] != -1)
            return dp[eggs, floors];

        // Base cases
        if (eggs == 1 || floors == 0 || floors == 1)
        {
            dp[eggs, floors] = floors;
            return floors;
        }

        int mn = int.MaxValue;

        // Try every floor from 1 to `floors`
        for (int k = 1; k <= floors; k++)
        {
            int top, bottom;

            // Check if the value is already computed for the top part
            if (dp[eggs - 1, k - 1] != -1)
                top = dp[eggs - 1, k - 1];
            else
            {
                top = Solve(eggs - 1, k - 1);
                dp[eggs - 1, k - 1] = top;
            }

            // Check if the value is already computed for the bottom part
            if (dp[eggs, floors - k] != -1)
                bottom = dp[eggs, floors - k];
            else
            {
                bottom = Solve(eggs, floors - k);
                dp[eggs, floors - k] = bottom;
            }

            // Take the maximum of the two possibilities and add 1 for the current move
            int temp_ans = 1 + Math.Max(top, bottom);

            // Minimize the result
            mn = Math.Min(mn, temp_ans);
        }

        // Store the result and return
        dp[eggs, floors] = mn;
        return mn;
    }

    static void Main()
    {
        int eggs = int.Parse(Console.ReadLine());
        int floors = int.Parse(Console.ReadLine());

        // Initialize the memoization table with -1
        for (int i = 0; i < D; i++)
            for (int j = 0; j < D; j++)
                dp[i, j] = -1;

        // Call Solve function and print the result
        Console.WriteLine(Solve(eggs, floors));
    }
}
