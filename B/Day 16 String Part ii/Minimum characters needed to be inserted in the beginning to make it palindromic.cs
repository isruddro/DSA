public class Solution
{
    public int Solve(string A)
    {
        string reversed = new string(A.Reverse().ToArray());
        
        // Concatenate the original string and reversed string with a special separator
        string combined = A + "#" + reversed;

        // Compute the LPS array for the combined string
        int[] lps = new int[combined.Length];
        int j = 0;  // Length of the previous longest prefix suffix

        // Build the LPS array
        for (int i = 1; i < combined.Length; i++)
        {
            while (j > 0 && combined[i] != combined[j])
                j = lps[j - 1];

            if (combined[i] == combined[j])
                j++;

            lps[i] = j;
        }

        // The length of the longest palindromic suffix is found in the last value of the LPS array
        int longestPalindromicSuffixLength = lps[combined.Length - 1];
        
        // The number of characters to insert is the difference between the total length and the longest palindromic suffix length
        return A.Length - longestPalindromicSuffixLength;
    }
}
