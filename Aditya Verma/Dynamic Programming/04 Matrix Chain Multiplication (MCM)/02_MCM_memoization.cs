https://www.geeksforgeeks.org/problems/matrix-chain-multiplication0303/1

py:
import sys
sys.setrecursionlimit(10**6)

# Memoization table
t = {}

def solve(arr, i, j):
    if i >= j:
        return 0

    if (i, j) in t:
        return t[(i, j)]

    ans = float('inf')
    for k in range(i, j):
        temp_ans = solve(arr, i, k) + solve(arr, k + 1, j) + arr[i - 1] * arr[k] * arr[j]
        ans = min(ans, temp_ans)

    t[(i, j)] = ans
    return ans

# Input
n = int(input())
arr = list(map(int, input().split()))

# Compute minimum multiplications
print(solve(arr, 1, n - 1))


cpp:
#include <bits/stdc++.h>
using namespace std;

const int D = 1000;
int t[D][D]; // Memoization table

// Recursive function to solve MCM
int Solve(vector<int> &arr, int i, int j) {
    if (i >= j) 
        return 0;

    if (t[i][j] != -1) 
        return t[i][j];

    int ans = INT_MAX;
    for (int k = i; k <= j - 1; k++) {
        int temp_ans = Solve(arr, i, k) + Solve(arr, k + 1, j) + arr[i - 1] * arr[k] * arr[j];
        ans = min(ans, temp_ans);
    }

    return t[i][j] = ans;
}

int main() {
    int n;
    cin >> n;

    vector<int> arr(n);
    for (int i = 0; i < n; i++)
        cin >> arr[i];

    // Initialize memoization table with -1
    memset(t, -1, sizeof(t));

    cout << Solve(arr, 1, n - 1) << endl;

    return 0;
}



c#:

using System;

class MatrixChainMultiplication
{
    const int D = 1000;
    static int[,] t = new int[D, D];

    static int Solve(int[] arr, int i, int j)
    {
        if (i >= j)
        {
            t[i, j] = 0;
            return 0;
        }

        if (t[i, j] != -1)
            return t[i, j];

        int ans = int.MaxValue;
        for (int k = i; k <= j - 1; k++)
        {
            int temp_ans = Solve(arr, i, k) + Solve(arr, k + 1, j) + arr[i - 1] * arr[k] * arr[j];
            ans = Math.Min(ans, temp_ans);
        }

        return t[i, j] = ans;
    }

    static void Main()
    {
        int n;
        n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Initialize memoization table with -1
        Array.Clear(t, 0, t.Length);
        
        Console.WriteLine(Solve(arr, 1, n - 1));
    }
}
