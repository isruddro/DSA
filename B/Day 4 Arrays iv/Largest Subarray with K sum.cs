Solution 1 (Naive approach) :


using System;
using System.Collections.Generic;

public class Solution
{
    // Function to find the length of the longest subarray with sum zero
    public static int Solve(List<int> a)
    {
        int maxLen = 0;
        Dictionary<int, int> sumIndexMap = new Dictionary<int, int>();
        int sum = 0;

        for (int i = 0; i < a.Count; i++)
        {
            sum += a[i];

            // If the sum is zero, we found a subarray from the start
            if (sum == 0)
            {
                maxLen = i + 1;
            }
            else if (sumIndexMap.ContainsKey(sum))
            {
                // If the sum is already in the map, calculate the length of the subarray
                maxLen = Math.Max(maxLen, i - sumIndexMap[sum]);
            }
            else
            {
                // Store the first occurrence of the sum
                sumIndexMap[sum] = i;
            }
        }

        return maxLen;
    }

    public static void Main()
    {
        List<int> a = new List<int> { 9, -3, 3, -1, 6, -5 };
        Console.WriteLine(Solve(a));
    }
}



Solution 2 (Optimised Approach):


using System;
using System.Collections.Generic;

public class Solution
{
    public int MaxLen(int[] A, int n)
    {
        // Create a dictionary to store sum indices
        Dictionary<int, int> mpp = new Dictionary<int, int>();
        int maxi = 0;
        int sum = 0;

        // Iterate over the array
        for (int i = 0; i < n; i++)
        {
            sum += A[i];

            // If sum is 0, we found a subarray starting from index 0
            if (sum == 0)
            {
                maxi = i + 1;
            }
            else
            {
                // If the sum has been seen before, update maxi
                if (mpp.ContainsKey(sum))
                {
                    maxi = Math.Max(maxi, i - mpp[sum]);
                }
                else
                {
                    // Store the sum with its index
                    mpp[sum] = i;
                }
            }
        }

        return maxi;
    }
}
