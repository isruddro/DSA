BF:


using System;

public class Program
{
    public static void Merge(long[] arr1, long[] arr2, int n, int m)
    {
        // Declare a 3rd array and 2 pointers:
        long[] arr3 = new long[n + m];
        int left = 0;
        int right = 0;
        int index = 0;

        // Insert the elements from the 2 arrays into the 3rd array using left and right pointers
        while (left < n && right < m)
        {
            if (arr1[left] <= arr2[right])
            {
                arr3[index] = arr1[left];
                left++;
                index++;
            }
            else
            {
                arr3[index] = arr2[right];
                right++;
                index++;
            }
        }

        // If right pointer reaches the end
        while (left < n)
        {
            arr3[index++] = arr1[left++];
        }

        // If left pointer reaches the end
        while (right < m)
        {
            arr3[index++] = arr2[right++];
        }

        // Fill back the elements from arr3[] to arr1[] and arr2[]
        for (int i = 0; i < n + m; i++)
        {
            if (i < n)
            {
                arr1[i] = arr3[i];
            }
            else
            {
                arr2[i - n] = arr3[i];
            }
        }
    }

    public static void Main(string[] args)
    {
        long[] arr1 = { 1, 4, 8, 10 };
        long[] arr2 = { 2, 3, 9 };
        int n = 4, m = 3;
        Merge(arr1, arr2, n, m);

        Console.WriteLine("The merged arrays are:");
        Console.Write("arr1[] = ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("\narr2[] = ");
        for (int i = 0; i < m; i++)
        {
            Console.Write(arr2[i] + " ");
        }
        Console.WriteLine();
    }
}



Optimal 1:


using System;

public class Program
{
    public static void Merge(long[] arr1, long[] arr2, int n, int m)
    {
        // Declare 2 pointers:
        int left = n - 1;
        int right = 0;

        // Swap the elements until arr1[left] is smaller than arr2[right]
        while (left >= 0 && right < m)
        {
            if (arr1[left] > arr2[right])
            {
                long temp = arr1[left];
                arr1[left] = arr2[right];
                arr2[right] = temp;
                left--;
                right++;
            }
            else
            {
                break;
            }
        }

        // Sort arr1[] and arr2[] individually:
        Array.Sort(arr1);
        Array.Sort(arr2);
    }

    public static void Main(string[] args)
    {
        long[] arr1 = { 1, 4, 8, 10 };
        long[] arr2 = { 2, 3, 9 };
        int n = 4, m = 3;
        Merge(arr1, arr2, n, m);

        Console.WriteLine("The merged arrays are:");
        Console.Write("arr1[] = ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("\narr2[] = ");
        for (int i = 0; i < m; i++)
        {
            Console.Write(arr2[i] + " ");
        }
        Console.WriteLine();
    }
}



Optimal 2:


using System;

public class Program
{
    // Method to swap elements if the element in arr1 is greater than the element in arr2
    public static void SwapIfGreater(long[] arr1, long[] arr2, int ind1, int ind2)
    {
        if (arr1[ind1] > arr2[ind2])
        {
            long temp = arr1[ind1];
            arr1[ind1] = arr2[ind2];
            arr2[ind2] = temp;
        }
    }

    // Method to merge the two arrays
    public static void Merge(long[] arr1, long[] arr2, int n, int m)
    {
        // Length of the imaginary single array
        int len = n + m;

        // Initial gap
        int gap = (len / 2) + (len % 2);

        while (gap > 0)
        {
            // Place two pointers
            int left = 0;
            int right = left + gap;
            while (right < len)
            {
                // Case 1: left in arr1[] and right in arr2[]
                if (left < n && right >= n)
                {
                    SwapIfGreater(arr1, arr2, left, right - n);
                }
                // Case 2: both pointers in arr2[]
                else if (left >= n)
                {
                    SwapIfGreater(arr2, arr2, left - n, right - n);
                }
                // Case 3: both pointers in arr1[]
                else
                {
                    SwapIfGreater(arr1, arr1, left, right);
                }
                left++;
                right++;
            }

            // Break if iteration gap=1 is completed
            if (gap == 1) break;

            // Otherwise, calculate the new gap
            gap = (gap / 2) + (gap % 2);
        }
    }

    public static void Main(string[] args)
    {
        long[] arr1 = { 1, 4, 8, 10 };
        long[] arr2 = { 2, 3, 9 };
        int n = 4, m = 3;
        Merge(arr1, arr2, n, m);

        Console.WriteLine("The merged arrays are:");
        Console.Write("arr1[] = ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }
        Console.Write("\narr2[] = ");
        for (int i = 0; i < m; i++)
        {
            Console.Write(arr2[i] + " ");
        }
        Console.WriteLine();
    }
}
