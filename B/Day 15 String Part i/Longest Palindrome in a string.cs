public class Solution
{
    public string LongestPalindrome(string s)
    {
        int n = s.Length, start = 0, end = 0;
        bool[,] dp = new bool[n, n];

        for (int len = 0; len < n; len++)  // len is the length of the current substring
        {
            for (int i = 0; i + len < n; i++)  // i is the starting index of the substring
            {
                dp[i, i + len] = s[i] == s[i + len] && (len < 2 || dp[i + 1, i + len - 1]);
                
                if (dp[i, i + len] && len > end - start)  // If it's a palindrome and its length is greater
                {
                    start = i;
                    end = i + len;
                }
            }
        }

        return s.Substring(start, end - start + 1);  // Return the longest palindromic substring
    }
}
