Naive Approach (Brute-force): 


using System;
using System.Collections.Generic;

public class Solution
{
    public int SubarraysWithXorK(int[] a, int k)
    {
        int n = a.Length;  // Size of the given array
        int cnt = 0;

        // Step 1: Generating subarrays
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                // Step 2: Calculate XOR of all elements
                int xorr = 0;
                for (int K = i; K <= j; K++)
                {
                    xorr ^= a[K];
                }

                // Step 3: Check XOR and count
                if (xorr == k)
                {
                    cnt++;
                }
            }
        }

        return cnt;
    }

    public static void Main(string[] args)
    {
        int[] a = { 4, 2, 2, 6, 4 };
        int k = 6;
        Solution solution = new Solution();
        int ans = solution.SubarraysWithXorK(a, k);
        Console.WriteLine("The number of subarrays with XOR k is: " + ans);
    }
}



Better Approach: 


using System;

public class Solution
{
    public int SubarraysWithXorK(int[] a, int k)
    {
        int n = a.Length;  // Size of the given array
        int cnt = 0;

        // Step 1: Generating subarrays
        for (int i = 0; i < n; i++)
        {
            int xorr = 0;
            for (int j = i; j < n; j++)
            {
                // Step 2: Calculate XOR of all elements
                xorr ^= a[j];

                // Step 3: Check XOR and count
                if (xorr == k)
                {
                    cnt++;
                }
            }
        }

        return cnt;
    }

    public static void Main(string[] args)
    {
        int[] a = { 4, 2, 2, 6, 4 };
        int k = 6;
        Solution solution = new Solution();
        int ans = solution.SubarraysWithXorK(a, k);
        Console.WriteLine("The number of subarrays with XOR k is: " + ans);
    }
}



Optimal Approach(Using Hashing): 


using System;
using System.Collections.Generic;

public class Solution
{
    public int SubarraysWithXorK(int[] a, int k)
    {
        int n = a.Length;  // Size of the given array
        int xr = 0;
        var mpp = new Dictionary<int, int>();  // Declare the dictionary
        mpp[xr] = 1;  // Initialize the count of prefix XOR 0 to 1
        int cnt = 0;

        for (int i = 0; i < n; i++)
        {
            // Prefix XOR till index i
            xr ^= a[i];

            // Calculate x = xr ^ k
            int x = xr ^ k;

            // Add the occurrence of xr ^ k to the count
            if (mpp.ContainsKey(x))
            {
                cnt += mpp[x];
            }

            // Insert the prefix XOR till index i into the dictionary
            if (mpp.ContainsKey(xr))
            {
                mpp[xr]++;
            }
            else
            {
                mpp[xr] = 1;
            }
        }

        return cnt;
    }

    public static void Main(string[] args)
    {
        int[] a = { 4, 2, 2, 6, 4 };
        int k = 6;
        Solution solution = new Solution();
        int ans = solution.SubarraysWithXorK(a, k);
        Console.WriteLine("The number of subarrays with XOR k is: " + ans);
    }
}
