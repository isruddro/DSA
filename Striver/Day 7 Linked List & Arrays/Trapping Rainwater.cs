Solution 1: Brute force


using System;
using System.Collections.Generic;

class Program
{
    public static int Trap(List<int> arr)
    {
        int n = arr.Count;
        int waterTrapped = 0;

        for (int i = 0; i < n; i++)
        {
            int j = i;
            int leftMax = 0, rightMax = 0;

            // Find the maximum height on the left side of arr[i]
            while (j >= 0)
            {
                leftMax = Math.Max(leftMax, arr[j]);
                j--;
            }

            j = i;

            // Find the maximum height on the right side of arr[i]
            while (j < n)
            {
                rightMax = Math.Max(rightMax, arr[j]);
                j++;
            }

            // Calculate water trapped at index i
            waterTrapped += Math.Min(leftMax, rightMax) - arr[i];
        }

        return waterTrapped;
    }

    static void Main(string[] args)
    {
        List<int> arr = new List<int> { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        Console.WriteLine("The water that can be trapped is " + Trap(arr));
    }
}



Solution 2:Better solution



using System;
using System.Collections.Generic;

class Program
{
    public static int Trap(List<int> arr)
    {
        int n = arr.Count;
        int[] prefix = new int[n];
        int[] suffix = new int[n];

        // Fill the prefix array (left max heights)
        prefix[0] = arr[0];
        for (int i = 1; i < n; i++)
        {
            prefix[i] = Math.Max(prefix[i - 1], arr[i]);
        }

        // Fill the suffix array (right max heights)
        suffix[n - 1] = arr[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suffix[i] = Math.Max(suffix[i + 1], arr[i]);
        }

        // Calculate the water trapped
        int waterTrapped = 0;
        for (int i = 0; i < n; i++)
        {
            waterTrapped += Math.Min(prefix[i], suffix[i]) - arr[i];
        }

        return waterTrapped;
    }

    static void Main(string[] args)
    {
        List<int> arr = new List<int> { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        Console.WriteLine("The water that can be trapped is " + Trap(arr));
    }
}



Solution 3:Optimal Solution(Two pointer approach)



using System;
using System.Collections.Generic;

class Program
{
    public static int Trap(List<int> height)
    {
        int n = height.Count;
        int left = 0, right = n - 1;
        int res = 0;
        int maxLeft = 0, maxRight = 0;

        while (left <= right)
        {
            if (height[left] <= height[right])
            {
                if (height[left] >= maxLeft)
                {
                    maxLeft = height[left];
                }
                else
                {
                    res += maxLeft - height[left];
                }
                left++;
            }
            else
            {
                if (height[right] >= maxRight)
                {
                    maxRight = height[right];
                }
                else
                {
                    res += maxRight - height[right];
                }
                right--;
            }
        }

        return res;
    }

    static void Main(string[] args)
    {
        List<int> arr = new List<int> { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        Console.WriteLine("The water that can be trapped is " + Trap(arr));
    }
}
