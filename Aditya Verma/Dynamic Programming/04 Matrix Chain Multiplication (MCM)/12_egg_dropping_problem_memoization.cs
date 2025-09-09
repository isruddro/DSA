cpp:
#include <bits/stdc++.h>
using namespace std;

const int D = 101;
int t[D][D];

// Recursive function with memoization
int Solve(int eggs, int floors) {
    // If already computed, return result
    if (t[eggs][floors] != -1) return t[eggs][floors];

    // Base cases
    if (eggs == 1 || floors == 0 || floors == 1) {
        t[eggs][floors] = floors;
        return floors;
    }

    int mn = INT_MAX;

    // Try dropping from each floor
    for (int k = 1; k <= floors; k++) {
        int temp_ans = 1 + max(Solve(eggs - 1, k - 1), Solve(eggs, floors - k));
        mn = min(mn, temp_ans);
    }

    // Store and return
    t[eggs][floors] = mn;
    return mn;
}

int main() {
    int eggs, floors;
    cin >> eggs >> floors;

    // Initialize memoization table with -1
    for (int i = 0; i < D; i++)
        for (int j = 0; j < D; j++)
            t[i][j] = -1;

    cout << Solve(eggs, floors) << endl;

    return 0;
}



c#:

using System;

class Program
{
    const int D = 101;
    static int[,] t = new int[D, D];

    // Function to solve the Egg Dropping Puzzle with memoization
    static int Solve(int eggs, int floors)
    {
        // If the result is already computed, return it
        if (t[eggs, floors] != -1)
            return t[eggs, floors];

        // Base cases
        if (eggs == 1 || floors == 0 || floors == 1)
        {
            t[eggs, floors] = floors;
            return floors;
        }

        int mn = int.MaxValue;

        // Try every floor from 1 to `floors`
        for (int k = 1; k <= floors; k++)
        {
            // Take the maximum of the two options and add 1 for the current move
            int temp_ans = 1 + Math.Max(Solve(eggs - 1, k - 1), Solve(eggs, floors - k));

            // Minimize the result
            mn = Math.Min(mn, temp_ans);
        }

        // Store the result and return
        t[eggs, floors] = mn;
        return mn;
    }

    static void Main()
    {
        int eggs = int.Parse(Console.ReadLine());
        int floors = int.Parse(Console.ReadLine());

        // Initialize the memoization table with -1
        for (int i = 0; i < D; i++)
            for (int j = 0; j < D; j++)
                t[i, j] = -1;

        // Call Solve function and print the result
        Console.WriteLine(Solve(eggs, floors));
    }
}
