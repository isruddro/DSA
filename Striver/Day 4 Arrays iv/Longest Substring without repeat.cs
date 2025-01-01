Solution 1: Brute force Approach


using System;
using System.Collections.Generic;

class Program
{
    public static int Solve(string str)
    {
        if (str.Length == 0)
            return 0;
        
        int maxAns = int.MinValue;

        // Outer loop for traversing the string
        for (int i = 0; i < str.Length; i++)
        {
            HashSet<char> set = new HashSet<char>();  // Using HashSet to store unique characters
            // Nested loop for getting different substrings starting with str[i]
            for (int j = i; j < str.Length; j++)
            {
                if (set.Contains(str[j]))  // If the character is already found, break
                {
                    maxAns = Math.Max(maxAns, j - i);  // Update maxAns with the length of current substring
                    break;
                }
                set.Add(str[j]);  // Add the character to the set
            }
        }
        return maxAns;
    }

    static void Main()
    {
        string str = "takeUforward";
        Console.WriteLine("The length of the longest substring without repeating characters is " + Solve(str));
    }
}



Solution 2: Optimised  Approach 1


using System;
using System.Collections.Generic;

class Program
{
    public static int Solve(string str)
    {
        if (str.Length == 0)
            return 0;

        int maxAns = int.MinValue;
        HashSet<char> set = new HashSet<char>();  // Using HashSet to store unique characters
        int l = 0;

        // Sliding window approach
        for (int r = 0; r < str.Length; r++)
        {
            // If duplicate element is found, move the left pointer
            while (set.Contains(str[r]))
            {
                set.Remove(str[l]);
                l++;
            }

            // Insert the current character into the set
            set.Add(str[r]);

            // Update the maximum length of the substring
            maxAns = Math.Max(maxAns, r - l + 1);
        }

        return maxAns;
    }

    static void Main()
    {
        string str = "takeUforward";
        Console.WriteLine("The length of the longest substring without repeating characters is " + Solve(str));
    }
}



Solution 3: Optimised  Approach 2


using System;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int[] mpp = new int[256];
        Array.Fill(mpp, -1); // Initialize all values to -1

        int left = 0, right = 0;
        int n = s.Length;
        int len = 0;

        while (right < n) {
            if (mpp[s[right]] != -1)
                left = Math.Max(mpp[s[right]] + 1, left);

            mpp[s[right]] = right;

            len = Math.Max(len, right - left + 1);
            right++;
        }

        return len;
    }
}

public class Program {
    public static void Main() {
        string str = "takeUforward";
        Solution obj = new Solution();
        Console.WriteLine("The length of the longest substring without repeating characters is " + obj.LengthOfLongestSubstring(str));
    }
}
