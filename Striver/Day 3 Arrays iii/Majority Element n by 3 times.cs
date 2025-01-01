Naive Approach (Brute-force): 


using System;
using System.Collections.Generic;

public class Program
{
    public static List<int> MajorityElement(int[] v)
    {
        int n = v.Length; // Size of the array
        List<int> ls = new List<int>(); // List to store answers

        for (int i = 0; i < n; i++)
        {
            // Selected element is v[i]
            // Checking if v[i] is not already
            // a part of the answer:
            if (ls.Count == 0 || ls[0] != v[i])
            {
                int cnt = 0;
                for (int j = 0; j < n; j++)
                {
                    // Counting the frequency of v[i]
                    if (v[j] == v[i])
                    {
                        cnt++;
                    }
                }

                // Check if frequency is greater than n/3
                if (cnt > (n / 3))
                {
                    ls.Add(v[i]);
                }
            }

            // Since we can have at most 2 majority elements
            if (ls.Count == 2) break;
        }

        return ls;
    }

    public static void Main()
    {
        int[] arr = {11, 33, 33, 11, 33, 11};
        List<int> ans = MajorityElement(arr);
        Console.Write("The majority elements are: ");
        foreach (var item in ans)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}



Better Approach (Using Hashing): 


using System;
using System.Collections.Generic;

public class Program
{
    public static List<int> MajorityElement(int[] v)
    {
        int n = v.Length; // Size of the array
        List<int> ls = new List<int>(); // List to store answers

        // Declaring a dictionary to store frequencies
        Dictionary<int, int> mpp = new Dictionary<int, int>();

        // Least occurrence of the majority element:
        int mini = n / 3 + 1;

        // Storing the elements with their occurrence:
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

            // Checking if v[i] is the majority element:
            if (mpp[v[i]] == mini)
            {
                ls.Add(v[i]);
            }

            // We can have at most two majority elements
            if (ls.Count == 2) break;
        }

        return ls;
    }

    public static void Main()
    {
        int[] arr = {11, 33, 33, 11, 33, 11};
        List<int> ans = MajorityElement(arr);
        Console.Write("The majority elements are: ");
        foreach (var item in ans)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}



Optimal Approach (Extended Boyer Moore’s Voting Algorithm): 


using System;
using System.Collections.Generic;

public class Program
{
    public static List<int> MajorityElement(int[] v)
    {
        int n = v.Length; // Size of the array

        int cnt1 = 0, cnt2 = 0; // counts
        int el1 = int.MinValue; // Element 1
        int el2 = int.MinValue; // Element 2

        // Applying the Extended Boyer Moore's Voting Algorithm:
        for (int i = 0; i < n; i++)
        {
            if (cnt1 == 0 && el2 != v[i])
            {
                cnt1 = 1;
                el1 = v[i];
            }
            else if (cnt2 == 0 && el1 != v[i])
            {
                cnt2 = 1;
                el2 = v[i];
            }
            else if (v[i] == el1) cnt1++;
            else if (v[i] == el2) cnt2++;
            else
            {
                cnt1--;
                cnt2--;
            }
        }

        List<int> ls = new List<int>(); // List of answers

        // Manually check if the stored elements in el1 and el2 are the majority elements:
        cnt1 = 0;
        cnt2 = 0;
        for (int i = 0; i < n; i++)
        {
            if (v[i] == el1) cnt1++;
            if (v[i] == el2) cnt2++;
        }

        int mini = n / 3 + 1;
        if (cnt1 >= mini) ls.Add(el1);
        if (cnt2 >= mini) ls.Add(el2);

        return ls;
    }

    public static void Main()
    {
        int[] arr = {11, 33, 33, 11, 33, 11};
        List<int> ans = MajorityElement(arr);
        Console.Write("The majority elements are: ");
        foreach (var item in ans)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
