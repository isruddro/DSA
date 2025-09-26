using System;
using System.Collections.Generic;

class Solution
{
    static void Main()
    {
        int V = 49;
        List<int> ans = new List<int>();
        int[] coins = { 1, 2, 5, 10, 20, 50, 100, 500, 1000 };
        int n = coins.Length;

        // Loop over the coins array in reverse order
        for (int i = n - 1; i >= 0; i--)
        {
            // While the coin is less than or equal to the remaining value
            while (V >= coins[i])
            {
                V -= coins[i];
                ans.Add(coins[i]);
            }
        }

        Console.WriteLine("The minimum number of coins is " + ans.Count);
        Console.WriteLine("The coins are:");

        // Print all the coins used
        foreach (var coin in ans)
        {
            Console.Write(coin + " ");
        }
    }
}
