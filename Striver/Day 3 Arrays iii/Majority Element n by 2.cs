Naive Approach: 


using System;

public class Program
{
    public static int MajorityElement(int[] v)
    {
        // Size of the given array:
        int n = v.Length;

        for (int i = 0; i < n; i++)
        {
            // Selected element is v[i]
            int cnt = 0;
            for (int j = 0; j < n; j++)
            {
                // Counting the frequency of v[i]
                if (v[j] == v[i])
                {
                    cnt++;
                }
            }

            // Check if frequency is greater than n/2:
            if (cnt > (n / 2))
                return v[i];
        }

        return -1;  // Return -1 if no majority element exists
    }

    public static void Main()
    {
        int[] arr = {2, 2, 1, 1, 1, 2, 2};
        int ans = MajorityElement(arr);
        Console.WriteLine("The majority element is: " + ans);
    }
}



Solution 2 (Better):


using System;
using System.Collections.Generic;

public class Program
{
    public static int MajorityElement(int[] v)
    {
        // Size of the given array:
        int n = v.Length;

        // Declaring a dictionary:
        Dictionary<int, int> mpp = new Dictionary<int, int>();

        // Storing the elements with their occurrences:
        for (int i = 0; i < n; i++)
        {
            if (mpp.ContainsKey(v[i]))
            {
                mpp[v[i]]++;
            }
            else
            {
                mpp[v[i]] = 1;
            }
        }

        // Searching for the majority element:
        foreach (var entry in mpp)
        {
            if (entry.Value > (n / 2))
            {
                return entry.Key;
            }
        }

        return -1;  // Return -1 if no majority element exists
    }

    public static void Main()
    {
        int[] arr = {2, 2, 1, 1, 1, 2, 2};
        int ans = MajorityElement(arr);
        Console.WriteLine("The majority element is: " + ans);
    }
}



Optimal Approach: Moore’s Voting Algorithm:


using System;

public class Program
{
    public static int MajorityElement(int[] v)
    {
        // Size of the given array:
        int n = v.Length;
        int cnt = 0; // Count
        int el = 0;  // Element

        // Applying the Boyer-Moore Voting Algorithm:
        for (int i = 0; i < n; i++)
        {
            if (cnt == 0)
            {
                cnt = 1;
                el = v[i];
            }
            else if (el == v[i])
            {
                cnt++;
            }
            else
            {
                cnt--;
            }
        }

        // Checking if the stored element
        // is the majority element:
        int cnt1 = 0;
        for (int i = 0; i < n; i++)
        {
            if (v[i] == el)
            {
                cnt1++;
            }
        }

        if (cnt1 > (n / 2))
        {
            return el;
        }

        return -1;  // Return -1 if no majority element exists
    }

    public static void Main()
    {
        int[] arr = {2, 2, 1, 1, 1, 2, 2};
        int ans = MajorityElement(arr);
        Console.WriteLine("The majority element is: " + ans);
    }
}
