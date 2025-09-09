cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    void GetSolved(string s, string op, vector<string>& result) {
        // Base case: when the string is empty, add the result string to the list
        if (s.empty()) {
            result.push_back(op);
            return;
        }

        char c = s[0];
        string rest = s.substr(1); // Remaining string

        if (isdigit(c)) {
            // If digit, just add it and recurse
            GetSolved(rest, op + c, result);
        } else {
            // If letter, branch to lowercase and uppercase
            GetSolved(rest, op + (char)tolower(c), result);
            GetSolved(rest, op + (char)toupper(c), result);
        }
    }

    vector<string> LetterCasePermutation(string s) {
        vector<string> result;
        GetSolved(s, "", result);
        return result;
    }
};

int main() {
    string s;
    cin >> s;

    Solution solution;
    vector<string> result = solution.LetterCasePermutation(s);

    for (auto &str : result) {
        cout << str << " ";
    }

    return 0;
}



c#:
public class Solution {
    public void GetSolved(string s, string op, List<string> result)
    {
        // Base case: when the string is empty, add the result string to the list
        if (s.Length == 0)
        {
            result.Add(op);
            return;
        }
        
        // If the first character is a digit, just add it to the current result and continue
        if (Char.IsDigit(s[0]))
        {
            string op1 = op + s[0];
            s = s.Substring(1);
            GetSolved(s, op1, result);
        }
        else
        {
            // If the first character is a letter, create two new options: one lowercase and one uppercase
            string op1 = op + Char.ToLower(s[0]);
            string op2 = op + Char.ToUpper(s[0]);
            s = s.Substring(1);
            GetSolved(s, op1, result);
            GetSolved(s, op2, result);
        }
    }

    public IList<string> LetterCasePermutation(string s) {
        List<string> result = new List<string>();
        string op = "";
        GetSolved(s, op, result);
        return result;
    }
}
