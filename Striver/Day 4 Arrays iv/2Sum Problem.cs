Naive Approach(Brute-force approach): 


Code Variant 1:


using System;

public class Solution
{
    // Function to check if any two numbers in the array sum up to the target value
    public static string TwoSum(int n, int[] arr, int target)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (arr[i] + arr[j] == target)
                    return "YES";  // If the sum matches, return "YES"
            }
        }
        return "NO";  // If no such pair exists, return "NO"
    }

    // Main method to test the solution
    public static void Main(string[] args)
    {
        int n = 5;
        int[] arr = { 2, 6, 5, 8, 11 };
        int target = 14;
        
        // Call the TwoSum function and print the result
        string ans = TwoSum(n, arr, target);
        Console.WriteLine("This is the answer for variant 1: " + ans);
    }
}



Code Variant 2:


using System;

public class Solution
{
    // Function to find indices of two numbers whose sum equals the target value
    public static int[] TwoSum(int n, int[] arr, int target)
    {
        int[] ans = new int[2];
        ans[0] = ans[1] = -1;  // Initialize the answer with -1 for no solution

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (arr[i] + arr[j] == target)
                {
                    ans[0] = i;
                    ans[1] = j;
                    return ans;  // Return the indices when the sum matches the target
                }
            }
        }
        return ans;  // If no such pair exists, return [-1, -1]
    }

    // Main method to test the solution
    public static void Main(string[] args)
    {
        int n = 5;
        int[] arr = { 2, 6, 5, 8, 11 };
        int target = 14;

        // Call the TwoSum function and print the result
        int[] ans = TwoSum(n, arr, target);
        Console.WriteLine("This is the answer for variant 2: [" + ans[0] + ", " + ans[1] + "]");
    }
}



Better Approach(using Hashing): 


Code for Variant 1:


using System;
using System.Collections.Generic;

public class Solution
{
    // Function to check if two numbers in the array sum up to the target
    public static string TwoSum(int n, int[] arr, int target)
    {
        // Create a dictionary to store the visited numbers
        Dictionary<int, int> mpp = new Dictionary<int, int>();

        // Loop through the array to check the sum condition
        for (int i = 0; i < n; i++)
        {
            int num = arr[i];
            int moreNeeded = target - num;

            // If the complement is already in the dictionary, return "YES"
            if (mpp.ContainsKey(moreNeeded))
            {
                return "YES";
            }

            // Store the current number in the dictionary
            mpp[num] = i;
        }

        // If no pair found, return "NO"
        return "NO";
    }

    // Main method to test the solution
    public static void Main(string[] args)
    {
        int n = 5;
        int[] arr = { 2, 6, 5, 8, 11 };
        int target = 14;

        // Call the TwoSum function and print the result
        string ans = TwoSum(n, arr, target);
        Console.WriteLine("This is the answer for variant 1: " + ans);
    }
}



Code for Variant 2:


using System;
using System.Collections.Generic;

public class Solution
{
    // Function to find the two indices whose elements sum up to the target
    public static int[] TwoSum(int n, int[] arr, int target)
    {
        // Create a dictionary to store the numbers and their indices
        Dictionary<int, int> mpp = new Dictionary<int, int>();

        // Loop through the array to check the sum condition
        for (int i = 0; i < n; i++)
        {
            int num = arr[i];
            int moreNeeded = target - num;

            // If the complement is already in the dictionary, return the indices
            if (mpp.ContainsKey(moreNeeded))
            {
                return new int[] { mpp[moreNeeded], i };
            }

            // Store the current number with its index in the dictionary
            mpp[num] = i;
        }

        // If no pair found, return {-1, -1}
        return new int[] { -1, -1 };
    }

    // Main method to test the solution
    public static void Main(string[] args)
    {
        int n = 5;
        int[] arr = { 2, 6, 5, 8, 11 };
        int target = 14;

        // Call the TwoSum function and print the result
        int[] ans = TwoSum(n, arr, target);
        Console.WriteLine("This is the answer for variant 2: [" + ans[0] + ", " + ans[1] + "]");
    }
}



Optimized Approach(using two-pointer): 



using System;

public class Solution
{
    // Function to check if there are two numbers whose sum is equal to the target
    public static string TwoSum(int n, int[] arr, int target)
    {
        // Sort the array
        Array.Sort(arr);

        int left = 0, right = n - 1;
        
        // Use two-pointer technique
        while (left < right)
        {
            int sum = arr[left] + arr[right];
            if (sum == target)
            {
                return "YES";
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        
        return "NO";
    }

    // Main method to test the solution
    public static void Main(string[] args)
    {
        int n = 5;
        int[] arr = { 2, 6, 5, 8, 11 };
        int target = 14;

        // Call the TwoSum function and print the result
        string ans = TwoSum(n, arr, target);
        Console.WriteLine("This is the answer for variant 1: " + ans);
    }
}
