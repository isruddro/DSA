Better:

using System;
using System.Collections.Generic;

public class Program
{
    public static void SortArray(List<int> arr, int n)
    {
        int cnt0 = 0, cnt1 = 0, cnt2 = 0;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] == 0) cnt0++;
            else if (arr[i] == 1) cnt1++;
            else cnt2++;
        }

        // Replace the places in the original array:
        for (int i = 0; i < cnt0; i++) arr[i] = 0; // replacing 0's

        for (int i = cnt0; i < cnt0 + cnt1; i++) arr[i] = 1; // replacing 1's

        for (int i = cnt0 + cnt1; i < n; i++) arr[i] = 2; // replacing 2's
    }

    public static void Main(string[] args)
    {
        int n = 6;
        List<int> arr = new List<int> { 0, 2, 1, 2, 0, 1 };
        SortArray(arr, n);

        Console.WriteLine("After sorting:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}



Optimal:


using System;
using System.Collections.Generic;

public class Program
{
    public static void SortArray(List<int> arr, int n)
    {
        int low = 0, mid = 0, high = n - 1; // 3 pointers

        while (mid <= high)
        {
            if (arr[mid] == 0)
            {
                // swapping arr[low] and arr[mid]
                int temp = arr[low];
                arr[low] = arr[mid];
                arr[mid] = temp;

                low++;
                mid++;
            }
            else if (arr[mid] == 1)
            {
                mid++;
            }
            else
            {
                // swapping arr[mid] and arr[high]
                int temp = arr[mid];
                arr[mid] = arr[high];
                arr[high] = temp;

                high--;
            }
        }
    }

    public static void Main(string[] args)
    {
        int n = 6;
        List<int> arr = new List<int> { 0, 2, 1, 2, 0, 1 };
        SortArray(arr, n);

        Console.WriteLine("After sorting:");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
