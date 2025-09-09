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
