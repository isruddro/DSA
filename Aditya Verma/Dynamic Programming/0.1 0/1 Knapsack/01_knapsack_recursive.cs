cpp:
#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

// Recursive 0/1 Knapsack function
int Knapsack(const vector<int>& wt, const vector<int>& val, int W, int n) {
    // Base case
    if (n == 0 || W == 0)
        return 0;

    // If weight of nth item is less than or equal to capacity
    if (wt[n - 1] <= W) {
        return max(val[n - 1] + Knapsack(wt, val, W - wt[n - 1], n - 1),
                   Knapsack(wt, val, W, n - 1));
    }
    else { // If weight of nth item is more than capacity
        return Knapsack(wt, val, W, n - 1);
    }
}

int main() {
    vector<int> wt = {1, 3, 4, 5};  // Weights
    vector<int> val = {1, 4, 5, 7}; // Values
    int W = 7;                       // Knapsack capacity

    int n = wt.size(); // Number of items

    cout << Knapsack(wt, val, W, n) << endl;

    return 0;
}




c#:

using System;
class Program
{
    static int Knapsack(int[] wt, int[] val, int W, int n)
    {
        //base case
        if(n==0 || W==0)
            return 0;
        
        //recursive case
        if(wt[n-1]<=W)
        {
            return Math.Max(val(n-1) + Knapsack(wt, val, W-wt[n-1], n-1),
                                       Knapsack(wt, val, W, n-1));
        }
        else
        {
            return Knapsack(wt, val, W, n-1);
        }
    }
     static void Main(string[] args)
    {
        // Hardcoded weights, values, and capacity
        int[] wt = { 1, 3, 4, 5 }; // Weights
        int[] val = { 1, 4, 5, 7 }; // Values
        int W = 7; // Knapsack capacity

        int n = wt.Length; // Number of items

        // Output result
        Console.WriteLine(Knapsack(wt, val, W, n));
    }
}
