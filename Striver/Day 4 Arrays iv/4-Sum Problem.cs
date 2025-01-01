Naive Approach (Brute-force): 


using System;
using System.Collections.Generic;

public class Solution
{
    public static List<List<int>> FourSum(List<int> nums, int target)
    {
        int n = nums.Count; // Size of the array
        HashSet<List<int>> st = new HashSet<List<int>>(new ListComparer());

        // Checking all possible quadruplets
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    for (int l = k + 1; l < n; l++)
                    {
                        // Sum of four elements
                        long sum = (long)nums[i] + nums[j] + nums[k] + nums[l];

                        if (sum == target)
                        {
                            List<int> temp = new List<int> { nums[i], nums[j], nums[k], nums[l] };
                            temp.Sort(); // Sort to ensure uniqueness
                            st.Add(temp);
                        }
                    }
                }
            }
        }

        // Convert HashSet to List
        List<List<int>> result = new List<List<int>>(st);
        return result;
    }

    public static void Main()
    {
        List<int> nums = new List<int> { 4, 3, 3, 4, 4, 2, 1, 2, 1, 1 };
        int target = 9;
        List<List<int>> ans = FourSum(nums, target);

        Console.WriteLine("The quadruplets are:");
        foreach (var quad in ans)
        {
            Console.Write("[");
            foreach (var ele in quad)
            {
                Console.Write(ele + " ");
            }
            Console.Write("] ");
        }
        Console.WriteLine();
    }
}

// Custom comparer for List<int> to ensure uniqueness in HashSet
public class ListComparer : IEqualityComparer<List<int>>
{
    public bool Equals(List<int> x, List<int> y)
    {
        if (x == null || y == null)
            return false;

        if (x.Count != y.Count)
            return false;

        for (int i = 0; i < x.Count; i++)
        {
            if (x[i] != y[i])
                return false;
        }

        return true;
    }

    public int GetHashCode(List<int> obj)
    {
        int hash = 17;
        foreach (var item in obj)
        {
            hash = hash * 23 + item.GetHashCode();
        }
        return hash;
    }
}



Better Approach (Using 3 loops and set data structure): 


using System;
using System.Collections.Generic;

public class Solution
{
    public static List<List<int>> FourSum(List<int> nums, int target)
    {
        int n = nums.Count; // Size of the array
        HashSet<List<int>> st = new HashSet<List<int>>(new ListComparer());

        // Checking all possible quadruplets
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                HashSet<long> hashset = new HashSet<long>(); // Set to store the third element
                for (int k = j + 1; k < n; k++)
                {
                    // To avoid integer overflow, use a bigger data type
                    long sum = (long)nums[i] + nums[j] + nums[k];
                    long fourth = target - sum;

                    if (hashset.Contains(fourth))
                    {
                        List<int> temp = new List<int> { nums[i], nums[j], nums[k], (int)fourth };
                        temp.Sort(); // Sort to ensure uniqueness
                        st.Add(temp);
                    }

                    // Insert the current element into the hashset
                    hashset.Add(nums[k]);
                }
            }
        }

        // Convert HashSet to List
        List<List<int>> result = new List<List<int>>(st);
        return result;
    }

    public static void Main()
    {
        List<int> nums = new List<int> { 4, 3, 3, 4, 4, 2, 1, 2, 1, 1 };
        int target = 9;
        List<List<int>> ans = FourSum(nums, target);

        Console.WriteLine("The quadruplets are:");
        foreach (var quad in ans)
        {
            Console.Write("[");
            foreach (var ele in quad)
            {
                Console.Write(ele + " ");
            }
            Console.Write("] ");
        }
        Console.WriteLine();
    }
}

// Custom comparer for List<int> to ensure uniqueness in HashSet
public class ListComparer : IEqualityComparer<List<int>>
{
    public bool Equals(List<int> x, List<int> y)
    {
        if (x == null || y == null)
            return false;

        if (x.Count != y.Count)
            return false;

        for (int i = 0; i < x.Count; i++)
        {
            if (x[i] != y[i])
                return false;
        }

        return true;
    }

    public int GetHashCode(List<int> obj)
    {
        int hash = 17;
        foreach (var item in obj)
        {
            hash = hash * 23 + item.GetHashCode();
        }
        return hash;
    }
}



Optimal Approach: 


using System;
using System.Collections.Generic;

public class Solution
{
    public static List<List<int>> FourSum(List<int> nums, int target)
    {
        int n = nums.Count; // Size of the array
        List<List<int>> ans = new List<List<int>>();

        // Sort the given array
        nums.Sort();

        // Calculating the quadruplets
        for (int i = 0; i < n; i++)
        {
            // Avoid the duplicates while moving i
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < n; j++)
            {
                // Avoid the duplicates while moving j
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                // Two-pointer technique
                int k = j + 1;
                int l = n - 1;
                while (k < l)
                {
                    long sum = (long)nums[i] + nums[j] + nums[k] + nums[l];
                    if (sum == target)
                    {
                        List<int> temp = new List<int> { nums[i], nums[j], nums[k], nums[l] };
                        ans.Add(temp);
                        k++;
                        l--;

                        // Skip the duplicates
                        while (k < l && nums[k] == nums[k - 1]) k++;
                        while (k < l && nums[l] == nums[l + 1]) l--;
                    }
                    else if (sum < target) k++;
                    else l--;
                }
            }
        }

        return ans;
    }

    public static void Main()
    {
        List<int> nums = new List<int> { 4, 3, 3, 4, 4, 2, 1, 2, 1, 1 };
        int target = 9;
        List<List<int>> ans = FourSum(nums, target);

        Console.WriteLine("The quadruplets are:");
        foreach (var quad in ans)
        {
            Console.Write("[");
            foreach (var ele in quad)
            {
                Console.Write(ele + " ");
            }
            Console.Write("] ");
        }
        Console.WriteLine();
    }
}



