Solution 1: Brute force approach 


using System;

public class Program
{
    public static double MyPow(double x, int n)
    {
        double ans = 1.0;
        for (int i = 0; i < n; i++)
        {
            ans *= x;
        }
        return ans;
    }

    public static void Main()
    {
        Console.WriteLine(MyPow(2, 10));
    }
}


Solution 2: Using Binary Exponentiation


using System;

public class Program
{
    public static double MyPow(double x, int n)
    {
        double ans = 1.0;
        long nn = n;
        if (nn < 0) nn = -nn;  // Handle negative exponent

        while (nn > 0)
        {
            if (nn % 2 == 1)  // If exponent is odd
            {
                ans *= x;
                nn--;  // Decrease exponent by 1
            }
            else
            {
                x *= x;  // Square the base
                nn /= 2;  // Halve the exponent
            }
        }

        if (n < 0) ans = 1.0 / ans;  // If original exponent was negative, return reciprocal
        return ans;
    }

    public static void Main()
    {
        Console.WriteLine(MyPow(2, 10));
    }
}



