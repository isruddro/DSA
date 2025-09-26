Naive Approach (Brute force): 


using System;

public class Program
{
    public static int NumberOfInversions(int[] a, int n)
    {
        // Count the number of inversions (pairs where a[i] > a[j] for i < j)
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (a[i] > a[j])
                    cnt++;
            }
        }
        return cnt;
    }

    public static void Main()
    {
        int[] a = { 5, 4, 3, 2, 1 };
        int n = 5;
        int cnt = NumberOfInversions(a, n);
        Console.WriteLine("The number of inversions is: " + cnt);
    }
}



Optimal:


using System;
using System.Collections.Generic;

public class Program
{
    private static int Merge(int[] arr, int low, int mid, int high)
    {
        List<int> temp = new List<int>(); // temporary list
        int left = low;      // starting index of left half of arr
        int right = mid + 1; // starting index of right half of arr

        // Count the number of inversions
        int cnt = 0;

        // Merging elements in a sorted manner
        while (left <= mid && right <= high)
        {
            if (arr[left] <= arr[right])
            {
                temp.Add(arr[left]);
                left++;
            }
            else
            {
                temp.Add(arr[right]);
                cnt += (mid - left + 1); // Count inversions
                right++;
            }
        }

        // If elements on the left half are still left
        while (left <= mid)
        {
            temp.Add(arr[left]);
            left++;
        }

        // If elements on the right half are still left
        while (right <= high)
        {
            temp.Add(arr[right]);
            right++;
        }

        // Copy elements from temporary list to original array
        for (int i = low; i <= high; i++)
        {
            arr[i] = temp[i - low];
        }

        return cnt; // Return inversion count
    }

    private static int MergeSort(int[] arr, int low, int high)
    {
        int cnt = 0;
        if (low >= high) return cnt;
        int mid = (low + high) / 2;
        cnt += MergeSort(arr, low, mid);   // Left half
        cnt += MergeSort(arr, mid + 1, high); // Right half
        cnt += Merge(arr, low, mid, high);  // Merge the halves
        return cnt;
    }

    public static int NumberOfInversions(int[] arr, int n)
    {
        return MergeSort(arr, 0, n - 1);
    }

    public static void Main()
    {
        int[] a = { 5, 4, 3, 2, 1 };
        int n = 5;
        int cnt = NumberOfInversions(a, n);
        Console.WriteLine("The number of inversions are: " + cnt);
    }
}
