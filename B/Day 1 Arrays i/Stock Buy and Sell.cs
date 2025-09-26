BF:

using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = { 7, 1, 5, 3, 6, 4 };
        int maxPro = MaxProfit(arr);
        Console.WriteLine("Max profit is: " + maxPro);
    }

    static int MaxProfit(int[] arr)
    {
        int maxPro = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] > arr[i])
                {
                    maxPro = Math.Max(arr[j] - arr[i], maxPro);
                }
            }
        }
        return maxPro;
    }
}



Optimal:


using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = { 7, 1, 5, 3, 6, 4 };
        int maxPro = MaxProfit(arr);
        Console.WriteLine("Max profit is: " + maxPro);
    }

    static int MaxProfit(int[] arr)
    {
        int maxPro = 0;
        int minPrice = int.MaxValue;
        for (int i = 0; i < arr.Length; i++)
        {
            minPrice = Math.Min(minPrice, arr[i]);
            maxPro = Math.Max(maxPro, arr[i] - minPrice);
        }
        return maxPro;
    }
}
