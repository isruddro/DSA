BF:

using System;

public class Program
{
    public static int MaxSubarraySum(int[] arr, int n)
    {
        int maxi = int.MinValue; // maximum sum

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                // subarray = arr[i.....j]
                int sum = 0;

                // add all the elements of subarray:
                for (int k = i; k <= j; k++)
                {
                    sum += arr[k];
                }

                maxi = Math.Max(maxi, sum);
            }
        }

        return maxi;
    }

    public static void Main(string[] args)
    {
        int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int n = arr.Length;
        int maxSum = MaxSubarraySum(arr, n);
        Console.WriteLine("The maximum subarray sum is: " + maxSum);
    }
}


Better:


using System;

public class Program
{
    public static int MaxSubarraySum(int[] arr, int n)
    {
        int maxi = int.MinValue; // maximum sum

        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = i; j < n; j++)
            {
                // current subarray = arr[i.....j]

                // add the current element arr[j]
                // to the sum i.e. sum of arr[i...j-1]
                sum += arr[j];

                maxi = Math.Max(maxi, sum); // getting the maximum
            }
        }

        return maxi;
    }

    public static void Main(string[] args)
    {
        int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int n = arr.Length;
        int maxSum = MaxSubarraySum(arr, n);
        Console.WriteLine("The maximum subarray sum is: " + maxSum);
    }
}



Optimal:

using System;

public class Program
{
    public static long MaxSubarraySum(int[] arr, int n)
    {
        long maxi = long.MinValue; // maximum sum
        long sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += arr[i];

            if (sum > maxi)
            {
                maxi = sum;
            }

            // If sum < 0: discard the sum calculated
            if (sum < 0)
            {
                sum = 0;
            }
        }

        // To consider the sum of the empty subarray
        // uncomment the following check:

        // if (maxi < 0) maxi = 0;

        return maxi;
    }

    public static void Main(string[] args)
    {
        int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int n = arr.Length;
        long maxSum = MaxSubarraySum(arr, n);
        Console.WriteLine("The maximum subarray sum is: " + maxSum);
    }
}
