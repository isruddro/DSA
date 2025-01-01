#include <bits/stdc++.h>
using namespace std;

int MatrixChainMultiplication(int arr[], int n) {
    int dp[n][n]; // DP table

    // Initialize the diagonal of the DP table as 0 (base case, no multiplication needed for a single matrix)
    for (int i = 1; i < n; i++) {
        dp[i][i] = 0;
    }

    // Loop through chain lengths
    for (int len = 2; len < n; len++) {
        for (int i = 1; i < n - len + 1; i++) {
            //started from 1 not from 0
            int j = i + len - 1;
            dp[i][j] = INT_MAX; // Set to a large number initially

            // Try all positions to split the chain
            for (int k = i; k <= j - 1; k++) {
                int q = dp[i][k] + dp[k + 1][j] + arr[i - 1] * arr[k] * arr[j];
                dp[i][j] = min(dp[i][j], q);
            }
        }
    }

    return dp[1][n - 1]; // The result is stored in dp[1][n-1]
}

signed main() {
    int n;
    cin >> n;
    int arr[n];
    for (int i = 0; i < n; i++)
        cin >> arr[i];

    cout << MatrixChainMultiplication(arr, n) << endl;
    return 0;
}
