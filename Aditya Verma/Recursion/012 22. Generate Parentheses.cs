py:
from typing import List

class Solution:
    def get_solved(self, opt: str, op: int, cl: int, result: List[str]):
        # Base case: no open or close parentheses left
        if op == 0 and cl == 0:
            result.append(opt)
            return

        # If open parentheses remain, add '('
        if op > 0:
            self.get_solved(opt + "(", op - 1, cl, result)

        # If there are more closing than open parentheses remaining, add ')'
        if cl > op:
            self.get_solved(opt + ")", op, cl - 1, result)

    def generate_parenthesis(self, n: int) -> List[str]:
        result = []
        self.get_solved("", n, n, result)
        return result

if __name__ == "__main__":
    n = int(input("Enter n: "))
    solution = Solution()
    res = solution.generate_parenthesis(n)
    print(" ".join(res))




cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
private:
    void GetSolved(string opt, int op, int cl, vector<string>& result) {
        // If no more open and close parentheses to add, add the current combination to the result
        if (op == 0 && cl == 0) {
            result.push_back(opt);
            return;
        }

        // If there are open parentheses remaining, add an open parenthesis
        if (op > 0) {
            GetSolved(opt + "(", op - 1, cl, result);
        }

        // If there are more closing parentheses than open ones, add a closing parenthesis
        if (cl > op) {
            GetSolved(opt + ")", op, cl - 1, result);
        }
    }

public:
    vector<string> GenerateParenthesis(int n) {
        vector<string> result;
        GetSolved("", n, n, result);
        return result;
    }
};

int main() {
    int n;
    cin >> n;

    Solution solution;
    vector<string> result = solution.GenerateParenthesis(n);

    for (auto &s : result) {
        cout << s << " ";
    }
    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class Solution
{
    // Recursive helper function to generate the combinations
    private void GetSolved(string opt, int op, int cl, List<string> result)
    {
        // If no more open and close parentheses to add, add the current combination to the result
        if (op == 0 && cl == 0)
        {
            result.Add(opt);
            return;
        }

        // If there are open parentheses remaining, add an open parenthesis
        if (op != 0)
        {
            string op1 = opt + "(";
            GetSolved(op1, op - 1, cl, result);
        }

        // If there are more closing parentheses than open ones, add a closing parenthesis
        if (cl > op)
        {
            string op1 = opt + ")";
            GetSolved(op1, op, cl - 1, result);
        }
    }

    // Function to generate all combinations of parentheses
    public IList<string> GenerateParenthesis(int n)
    {
        int op = n, cl = n;
        List<string> result = new List<string>();
        string opt = string.Empty;
        GetSolved(opt, op, cl, result);
        return result;
    }
}
