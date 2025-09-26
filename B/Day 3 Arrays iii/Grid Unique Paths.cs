Solution 2: Dynamic Programming Solution


public class Solution {
    public int UniquePaths(int m, int n) {
        int N = m + n - 2;  // Total number of moves
        int r = m - 1;  // Number of down moves (or alternatively, r = n-1 for right moves)
        int res = 1;

        // Calculate the binomial coefficient N choose r
        for (int i = 1; i <= r; i++) {
            res = res * (N - r + i) / i;
        }

        return res;
    }
}
