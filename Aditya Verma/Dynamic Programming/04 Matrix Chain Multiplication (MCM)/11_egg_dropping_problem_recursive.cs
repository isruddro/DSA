using System;

class Program
{
    // Function to solve the Egg Dropping Puzzle
    static int Solve(int eggs, int floors)
    {
        // Base cases
        if (eggs == 1)
            return floors;
        if (floors == 0 || floors == 1)
            return floors;

        int mn = int.MaxValue;

        // Try every floor from 1 to `floors`
        for (int k = 1; k <= floors; k++)
        {
            // Take the maximum of the two options and add 1 for the current move
            int temp_ans = 1 + Math.Max(Solve(eggs - 1, k - 1), Solve(eggs, floors - k));
            
            // Minimize the result
            mn = Math.Min(mn, temp_ans);
        }

        return mn;
    }

    static void Main()
    {
        int eggs = int.Parse(Console.ReadLine());
        int floors = int.Parse(Console.ReadLine());

        // Call Solve function and print the result
        Console.WriteLine(Solve(eggs, floors));
    }
}
