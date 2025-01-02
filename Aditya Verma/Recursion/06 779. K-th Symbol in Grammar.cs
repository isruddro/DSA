public class Solution {
    public int KthGrammar(int n, int k) {
        // Base case: when n is 1 and k is 1, the value is 0
        if (n == 1 && k == 1) {
            return 0;
        }

        // Calculate the mid value, which is the number of elements in the first half
        int mid = (int)Math.Pow(2, n - 2);

        // If k is in the first half, recursively call the function for the previous row
        if (k <= mid) {
            return KthGrammar(n - 1, k);
        }
        // If k is in the second half, recursively call the function for the previous row with adjusted k
        else {
            return 1 - KthGrammar(n - 1, k - mid);
        }
    }
}
