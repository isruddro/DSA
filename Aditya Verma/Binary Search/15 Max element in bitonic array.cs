using System;

class Program
{
    // Function to find the peak index in a mountain array
    static int PeakIndexInMountainArray(int[] arr)
    {
        int s = 0, e = arr.Length - 1;

        while (s < e)
        {
            int m = s + (e - s) / 2;

            // If the element at m is less than the element at m-1, move left
            if (m > 0 && arr[m] < arr[m - 1]) e = m - 1;
            // If the element at m is less than the element at m+1, move right
            else if (m < arr.Length - 1 && arr[m] < arr[m + 1]) s = m + 1;
            // If neither condition is true, m is the peak index
            else return m;
        }

        // When s == e, we've found the peak index
        return s;
    }

    static void Main()
    {
        // Example array
        int[] arr = { 0, 2, 3, 4, 3, 1, 0 };

        // Find the peak index in the mountain array
        int peakIndex = PeakIndexInMountainArray(arr);

        // Output the peak index
        Console.WriteLine($"Peak index is: {peakIndex}");
    }
}
