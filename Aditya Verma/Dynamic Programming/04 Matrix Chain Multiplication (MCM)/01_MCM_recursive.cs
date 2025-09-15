# Things to rem:
    * Multiplication of two matrix( A x B and C x D) is possible only if: B = C. And product is A x D
    * Cost = number of multiplication:
            If two matrix: 2 x 3 and 3 x 6 multiply:
                        Cost is: 2 x 3 x 6 (only took one  from middle as they are same)
                                = 36
   * arr[] = [40 20 30 10 30] from here we use formula: A[i] = arr[i-1] * arr[i]
      We got: A1: 40 20, A2: 20 30, A3: 30 10, A4: 10 30
         So: this MCM problems cost depends on brackets.

 # In this problem: 
    *  i = 1, j = n - 1 (i is in 1 index and j is last index)
    * If array element 1 multiplication is not possible. 

    * Two ways to make loops and function calls: (most important)
         1. When loop: k=i, k= j-1 then function calls: fn(i to k) , fn(k+1 to j)
         2. When loop: k=i+1, k= j then function calls: fn(i to k-1), fn(k to j)
            So basically, k will be placed in between i and j, and keep in mind: at least one needed.
               If there is one and nothing on the right, we take exact left.

py:
def matrix_chain_multiplication(arr):
    n = len(arr)
    # Create DP table
    dp = [[0] * n for _ in range(n)]

    # Fill dp table
    for length in range(2, n):  # chain length
        for i in range(1, n - length + 1):
            j = i + length - 1
            dp[i][j] = float('inf')
            for k in range(i, j):
                cost = dp[i][k] + dp[k + 1][j] + arr[i - 1] * arr[k] * arr[j]
                dp[i][j] = min(dp[i][j], cost)

    return dp[1][n - 1]

# Input
n = int(input())
arr = list(map(int, input().split()))

# Output
print(matrix_chain_multiplication(arr))



cpp:

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
