Solution 1:Using sorting

using System;
using System.Linq;

public class Program
{
    public static int FindDuplicate(int[] arr)
    {
        int n = arr.Length;
        Array.Sort(arr);  // Sort the array
        for (int i = 0; i < n - 1; i++)
        {
            if (arr[i] == arr[i + 1])
            {
                return arr[i];  // Return the duplicate element
            }
        }
        return -1;  // Return -1 if no duplicate is found
    }

    public static void Main(string[] args)
    {
        int[] arr = { 1, 3, 4, 2, 2 };
        Console.WriteLine("The duplicate element is " + FindDuplicate(arr));
    }
}




Solution 2:Using frequency array


using System;

public class Program
{
    public static int FindDuplicate(int[] arr)
    {
        int n = arr.Length;
        int[] freq = new int[n + 1];  // Frequency array of size N+1

        for (int i = 0; i < n; i++)
        {
            if (freq[arr[i]] == 0)
            {
                freq[arr[i]] += 1;  // Increase frequency if it's 0
            }
            else
            {
                return arr[i];  // Return the element if it appears again
            }
        }
        return 0;  // Return 0 if no duplicate is found (though it's assumed there is one)
    }

    public static void Main(string[] args)
    {
        int[] arr = { 1, 3, 4, 2, 3 };  // Example array
        Console.WriteLine("The duplicate element is " + FindDuplicate(arr));
    }
}



Solution 3: Linked List cycle method


using System;

public class Program
{
    public static int FindDuplicate(int[] nums)
    {
        // Initialize the slow and fast pointers
        int slow = nums[0];
        int fast = nums[0];

        // Phase 1: Find the intersection point in the cycle
        do
        {
            slow = nums[slow];          // Move slow pointer by 1 step
            fast = nums[nums[fast]];    // Move fast pointer by 2 steps
        } while (slow != fast);         // Keep moving until both pointers meet

        // Phase 2: Find the entrance to the cycle (duplicate number)
        fast = nums[0];  // Reset fast pointer to the start
        while (slow != fast)
        {
            slow = nums[slow];  // Move slow pointer by 1 step
            fast = nums[fast];  // Move fast pointer by 1 step
        }

        return slow;  // Return the duplicate number
    }

    public static void Main(string[] args)
    {
        int[] arr = { 1, 3, 4, 2, 3 };  // Example array with a duplicate number
        Console.WriteLine("The duplicate element is " + FindDuplicate(arr));
    }
}
