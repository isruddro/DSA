https://leetcode.com/problems/k-th-symbol-in-grammar/


cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    int kthGrammar(int n, int k) {
        // Base case: first row, first element is 0
        if (n == 1 && k == 1)
            return 0;

        // Number of elements in the first half of the row
        int mid = 1 << (n - 2);  // 2^(n-2)

        // If k is in the first half, same as previous row
        if (k <= mid)
            return kthGrammar(n - 1, k);
        else
            // If k is in the second half, invert the value from previous row
            return 1 - kthGrammar(n - 1, k - mid);
    }
};

int main() {
    int n, k;
    cin >> n >> k;

    Solution solution;
    cout << solution.kthGrammar(n, k) << endl;

    return 0;
}


py3:
class Solution:
    def kthGrammar(self, n: int, k: int) -> int:
        # Base case: first row, first element is 0
        if n == 1 and k == 1:
            return 0
        
        # Number of elements in the first half of the row
        mid = 1 << (n - 2)  # 2^(n-2)
        
        # If k is in the first half, same as previous row
        if k <= mid:
            return self.kthGrammar(n - 1, k)
        else:
            # If k is in the second half, invert the value from previous row
            return 1 - self.kthGrammar(n - 1, k - mid)

if __name__ == "__main__":
    n, k = map(int, input().split())
    solution = Solution()
    print(solution.kthGrammar(n, k))






c#:
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
