https://www.geeksforgeeks.org/problems/matrix-chain-multiplication0303/1

cpp:
O(n³) time, O(n²) space

#include <vector>
#include <climits>
#include <unordered_map>
using namespace std;

class Solution {
public:
    // Hash function for pair<int,int> to be used as unordered_map key
    struct pair_hash {
        size_t operator()(const pair<int,int>& p) const {
            return hash<int>()(p.first) ^ hash<int>()(p.second);
        }
    };

    unordered_map<pair<int,int>, int, pair_hash> t;

    int solve(const vector<int>& arr, int i, int j) {
        if (i >= j) return 0;

        auto key = make_pair(i, j);
        if (t.find(key) != t.end()) return t[key];

        int ans = INT_MAX;
        for (int k = i; k < j; ++k) {
            int temp_ans = solve(arr, i, k) + solve(arr, k + 1, j) + arr[i - 1] * arr[k] * arr[j];
            ans = min(ans, temp_ans);
        }

        t[key] = ans;
        return ans;
    }

    int matrixMultiplication(vector<int>& arr) {
        t.clear();
        int n = (int)arr.size();
        return solve(arr, 1, n - 1);
    }
};


py3:
O(n³) time, O(n²) space

import sys
sys.setrecursionlimit(10**6)

class Solution:
    def matrixMultiplication(self, arr):
        t = {}  # Memoization table

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

        n = len(arr)
        return solve(arr, 1, n - 1)


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
