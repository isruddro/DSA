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
