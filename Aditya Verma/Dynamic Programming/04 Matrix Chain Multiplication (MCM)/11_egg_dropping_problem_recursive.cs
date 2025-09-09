cpp:
#include <bits/stdc++.h>
using namespace std;

// Recursive function to solve the Egg Dropping Puzzle
int Solve(int eggs, int floors) {
    // Base cases
    if (eggs == 1) return floors;
    if (floors == 0 || floors == 1) return floors;

    int mn = INT_MAX;

    // Try dropping from every floor from 1 to `floors`
    for (int k = 1; k <= floors; k++) {
        // Take the maximum of two scenarios and add 1 for current attempt
        int temp_ans = 1 + max(Solve(eggs - 1, k - 1), Solve(eggs, floors - k));
        mn = min(mn, temp_ans);
    }

    return mn;
}

int main() {
    int eggs, floors;
    cin >> eggs >> floors;

    cout << Solve(eggs, floors) << endl;

    return 0;
}





c#:
using System;

class Program
{
    // Function to solve the Egg Dropping Puzzle
    static int Solve(int eggs, int floors)
    {
        // Base cases
        if (eggs == 1)
            return floors;
        if (floors == 0 || floors == 1)
            return floors;

        int mn = int.MaxValue;

        // Try every floor from 1 to `floors`
        for (int k = 1; k <= floors; k++)
        {
            // Take the maximum of the two options and add 1 for the current move
            int temp_ans = 1 + Math.Max(Solve(eggs - 1, k - 1), Solve(eggs, floors - k));
            
            // Minimize the result
            mn = Math.Min(mn, temp_ans);
        }

        return mn;
    }

    static void Main()
    {
        int eggs = int.Parse(Console.ReadLine());
        int floors = int.Parse(Console.ReadLine());

        // Call Solve function and print the result
        Console.WriteLine(Solve(eggs, floors));
    }
}
