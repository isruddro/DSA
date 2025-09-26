Brute-force Approach: 


using System;
using System.Collections.Generic;

public class Solution
{
    // Function to perform linear search
    public static bool LinearSearch(List<int> a, int num)
    {
        foreach (int element in a)
        {
            if (element == num)
                return true;
        }
        return false;
    }

    // Function to find the longest consecutive subsequence
    public static int LongestSuccessiveElements(List<int> a)
    {
        int n = a.Count; // Size of the array
        int longest = 1;

        // Pick an element and search for its consecutive numbers
        for (int i = 0; i < n; i++)
        {
            int x = a[i];
            int cnt = 1;

            // Search for consecutive numbers using linear search
            while (LinearSearch(a, x + 1))
            {
                x += 1;
                cnt += 1;
            }

            // Update the longest sequence found so far
            longest = Math.Max(longest, cnt);
        }

        return longest;
    }

    public static void Main()
    {
        List<int> a = new List<int> { 100, 200, 1, 2, 3, 4 };
        int ans = LongestSuccessiveElements(a);
        Console.WriteLine("The longest consecutive sequence is " + ans);
    }
}



Better Approach(Using sorting): 


using System;
using System.Collections.Generic;

public class Solution
{
    // Function to find the longest consecutive subsequence
    public static int LongestSuccessiveElements(List<int> a)
    {
        int n = a.Count;
        if (n == 0) return 0;

        // Sort the array
        a.Sort();

        int lastSmaller = int.MinValue;
        int cnt = 0;
        int longest = 1;

        // Find the longest sequence
        for (int i = 0; i < n; i++)
        {
            if (a[i] - 1 == lastSmaller)
            {
                // a[i] is the next element of the current sequence
                cnt += 1;
                lastSmaller = a[i];
            }
            else if (a[i] != lastSmaller)
            {
                cnt = 1;
                lastSmaller = a[i];
            }

            longest = Math.Max(longest, cnt);
        }

        return longest;
    }

    public static void Main()
    {
        List<int> a = new List<int> { 100, 200, 1, 2, 3, 4 };
        int ans = LongestSuccessiveElements(a);
        Console.WriteLine("The longest consecutive sequence is " + ans);
    }
}



Optimal Approach(Using Set data structure): 


using System;
using System.Collections.Generic;

public class Solution
{
    // Function to find the longest consecutive subsequence
    public static int LongestSuccessiveElements(List<int> a)
    {
        int n = a.Count;
        if (n == 0) return 0;

        int longest = 1;
        HashSet<int> st = new HashSet<int>();

        // Insert all array elements into the set
        foreach (var num in a)
        {
            st.Add(num);
        }

        // Find the longest sequence
        foreach (var num in st)
        {
            // If 'num' is a starting number (it has no preceding consecutive number)
            if (!st.Contains(num - 1))
            {
                int cnt = 1;
                int x = num;
                // Find consecutive numbers
                while (st.Contains(x + 1))
                {
                    x++;
                    cnt++;
                }
                longest = Math.Max(longest, cnt);
            }
        }

        return longest;
    }

    public static void Main()
    {
        List<int> a = new List<int> { 100, 200, 1, 2, 3, 4 };
        int ans = LongestSuccessiveElements(a);
        Console.WriteLine("The longest consecutive sequence is " + ans);
    }
}
