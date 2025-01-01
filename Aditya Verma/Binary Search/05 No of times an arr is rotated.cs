using System;

class Program
{
    static int FindKRotation(int[] arr, int n)
    {
        int start = 0, end = n - 1;

        // If the array is already sorted
        if (arr[start] <= arr[end]) 
            return 0;

        while (start < end)
        {
            int mid = start + (end - start) / 2;

            // If the mid element is greater than the start, the rotation point is to the right
            if (arr[mid] > arr[start])
            {
                start = mid;
            }
            else
            {
                // Otherwise, the rotation point is to the left
                end = mid;
            }
        }

        // Return the index of the rotation point
        return start + 1;
    }

    static void Main()
    {
        int[] arr = { 15, 18, 2, 3, 6, 12 };
        int n = arr.Length;

        int rotations = FindKRotation(arr, n);
        Console.WriteLine($"The array is rotated {rotations} times.");
    }
}
