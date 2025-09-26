public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) {
            return false;
        }

        Dictionary<char, int> countS = new Dictionary<char, int>();
        Dictionary<char, int> countT = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++) {
            countS[s[i]] = 1 + countS.GetValueOrDefault(s[i], 0);
            countT[t[i]] = 1 + countT.GetValueOrDefault(t[i], 0);
        }

        foreach (var c in countS.Keys) {
            if (countS[c] != countT.GetValueOrDefault(c, 0)) {
                return false;
            }
        }

        return true;
    }
}
