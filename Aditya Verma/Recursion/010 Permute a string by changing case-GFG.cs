https://leetcode.com/problems/letter-case-permutation/description/

py:

from typing import List

class Solution:
    def get_solve(self, op: str, s: str, result: List[str]):
        if not s:  # Base case: if string is empty
            result.append(op)
            return

        # Take the first character and branch into lowercase and uppercase
        op1 = op + s[0].lower()
        op2 = op + s[0].upper()
        self.get_solve(op1, s[1:], result)
        self.get_solve(op2, s[1:], result)

if __name__ == "__main__":
    s = input("Enter string: ")  # Input string
    result = []
    solution = Solution()
    solution.get_solve("", s, result)

    print(" ".join(result))



cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    void GetSolve(string op, string s, vector<string>& result) {
        if (s.empty()) {
            result.push_back(op);
            return;
        }

        string op1 = op;
        string op2 = op;

        op1 += tolower(s[0]);
        op2 += toupper(s[0]);

        s = s.substr(1); // Remove the first character
        GetSolve(op1, s, result);
        GetSolve(op2, s, result);
    }
};

int main() {
    string s;
    cin >> s; // Input string

    vector<string> result;
    string op = "";

    Solution solution;
    solution.GetSolve(op, s, result);

    for (auto& res : result) {
        cout << res << " ";
    }

    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class Solution
{
    public void GetSolve(string op, ref string s, List<string> result)
    {
        if (s.Length == 0)
        {
            result.Add(op);
            return;
        }

        string op1 = op;
        string op2 = op;
        op1 += char.ToLower(s[0]);
        op2 += char.ToUpper(s[0]);
        s = s.Substring(1); // Remove the first character
        GetSolve(op1, ref s, result);
        GetSolve(op2, ref s, result);
        return;
    }

    public static void Main(string[] args)
    {
        string s = Console.ReadLine();  // Input the string
        List<string> result = new List<string>();
        string op = string.Empty;
        
        Solution solution = new Solution();
        solution.GetSolve(op, ref s, result);

        foreach (string res in result)
        {
            Console.Write(res + " ");
        }
    }
}
