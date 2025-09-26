Solution 1: Brute Force


using System;
using System.Collections.Generic;

class Program
{
    public static int RemoveDuplicates(int[] arr)
    {
        HashSet<int> set = new HashSet<int>();

        // Add elements to the HashSet to remove duplicates
        foreach (var num in arr)
        {
            set.Add(num);
        }

        int k = set.Count;
        int index = 0;

        // Copy the elements from HashSet back to the array
        foreach (var num in set)
        {
            arr[index++] = num;
        }

        return k;
    }

    static void Main()
    {
        int[] arr = { 1, 1, 2, 2, 2, 3, 3 };
        int k = RemoveDuplicates(arr);

        Console.WriteLine("The array after removing duplicate elements is:");
        for (int i = 0; i < k; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}



Solution 2: Two pointers


using System;

class Program
{
    public static int RemoveDuplicates(int[] arr)
    {
        int i = 0;
        for (int j = 1; j < arr.Length; j++)
        {
            if (arr[i] != arr[j])
            {
                i++;
                arr[i] = arr[j];
            }
        }
        return i + 1; // Return the count of unique elements
    }

    static void Main()
    {
        int[] arr = { 1, 1, 2, 2, 2, 3, 3 };
        int k = RemoveDuplicates(arr);

        Console.WriteLine("The array after removing duplicate elements is:");
        for (int i = 0; i < k; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
