Naive Approach (Brute force): 


using System;

public class Program
{
    public static int[] FindMissingRepeatingNumbers(int[] a)
    {
        int n = a.Length;  // Size of the array
        int repeating = -1, missing = -1;

        // Find the repeating and missing numbers
        for (int i = 1; i <= n; i++)
        {
            // Count the occurrences of i in the array
            int cnt = 0;
            for (int j = 0; j < n; j++)
            {
                if (a[j] == i) cnt++;
            }

            if (cnt == 2) repeating = i;
            else if (cnt == 0) missing = i;

            if (repeating != -1 && missing != -1)
                break;
        }

        // Return the repeating and missing numbers
        return new int[] { repeating, missing };
    }

    public static void Main(string[] args)
    {
        int[] a = { 3, 1, 2, 5, 4, 6, 7, 5 };
        int[] ans = FindMissingRepeatingNumbers(a);
        Console.WriteLine("The repeating and missing numbers are: {" + ans[0] + ", " + ans[1] + "}");
    }
}



Better Approach (Using Hashing): 


using System;

public class Program
{
    public static int[] FindMissingRepeatingNumbers(int[] a)
    {
        int n = a.Length;  // Size of the array
        int[] hash = new int[n + 1];  // Hash array to store occurrences

        // Update the hash array:
        for (int i = 0; i < n; i++)
        {
            hash[a[i]]++;
        }

        // Find the repeating and missing numbers:
        int repeating = -1, missing = -1;
        for (int i = 1; i <= n; i++)
        {
            if (hash[i] == 2) repeating = i;
            else if (hash[i] == 0) missing = i;

            // Break the loop if both repeating and missing are found
            if (repeating != -1 && missing != -1)
                break;
        }

        // Return the result as an array
        return new int[] { repeating, missing };
    }

    public static void Main(string[] args)
    {
        int[] a = { 3, 1, 2, 5, 4, 6, 7, 5 };
        int[] ans = FindMissingRepeatingNumbers(a);
        Console.WriteLine("The repeating and missing numbers are: {" + ans[0] + ", " + ans[1] + "}");
    }
}



Optimal Approach 1 (Using Maths): 


using System;

public class Program
{
    public static int[] FindMissingRepeatingNumbers(int[] a)
    {
        long n = a.Length;  // Size of the array
        
        // Calculate Sn and S2n
        long SN = (n * (n + 1)) / 2;
        long S2N = (n * (n + 1) * (2 * n + 1)) / 6;

        // Calculate S and S2
        long S = 0, S2 = 0;
        foreach (int num in a)
        {
            S += num;
            S2 += (long)num * num;
        }

        // S - Sn = X - Y
        long val1 = S - SN;

        // S2 - S2n = X^2 - Y^2
        long val2 = S2 - S2N;

        // Find X + Y = (X^2 - Y^2) / (X - Y)
        val2 = val2 / val1;

        // Find X and Y: X = ((X + Y) + (X - Y)) / 2 and Y = X - (X - Y)
        long x = (val1 + val2) / 2;
        long y = x - val1;

        return new int[] { (int)x, (int)y };
    }

    public static void Main(string[] args)
    {
        int[] a = { 3, 1, 2, 5, 4, 6, 7, 5 };
        int[] ans = FindMissingRepeatingNumbers(a);
        Console.WriteLine("The repeating and missing numbers are: {" + ans[0] + ", " + ans[1] + "}");
    }
}



Optimal Approach 2 (Using XOR): 


using System;

public class Program
{
    public static int[] FindMissingRepeatingNumbers(int[] a)
    {
        int n = a.Length;  // Size of the array
        int xr = 0;

        // Step 1: Find XOR of all elements
        for (int i = 0; i < n; i++)
        {
            xr = xr ^ a[i];
            xr = xr ^ (i + 1);
        }

        // Step 2: Find the differentiating bit number
        int number = (xr & ~(xr - 1));

        // Step 3: Group the numbers
        int zero = 0;
        int one = 0;
        for (int i = 0; i < n; i++)
        {
            // Part of 1 group
            if ((a[i] & number) != 0)
            {
                one = one ^ a[i];
            }
            // Part of 0 group
            else
            {
                zero = zero ^ a[i];
            }
        }

        for (int i = 1; i <= n; i++)
        {
            // Part of 1 group
            if ((i & number) != 0)
            {
                one = one ^ i;
            }
            // Part of 0 group
            else
            {
                zero = zero ^ i;
            }
        }

        // Last step: Identify the numbers
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] == zero) cnt++;
        }

        // Return the repeating and missing numbers
        if (cnt == 2)
            return new int[] { zero, one };
        return new int[] { one, zero };
    }

    public static void Main()
    {
        int[] a = { 3, 1, 2, 5, 4, 6, 7, 5 };
        int[] ans = FindMissingRepeatingNumbers(a);
        Console.WriteLine("The repeating and missing numbers are: {" + ans[0] + ", " + ans[1] + "}");
    }
}
