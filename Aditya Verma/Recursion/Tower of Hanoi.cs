using System;

public class Solution
{
    public long GetSolved(int N, int fromRod, int toRod, int auxRod, ref long count)
    {
        if (N == 0)
        {
            return 0;
        }

        // Increment the move count before making the move
        count++;

        // Recursive call to move N-1 disks from 'fromRod' to 'auxRod'
        GetSolved(N - 1, fromRod, auxRod, toRod, ref count);

        // Print the move for the current disk
        Console.WriteLine($"Move disk {N} from rod {fromRod} to rod {toRod}");

        // Recursive call to move N-1 disks from 'auxRod' to 'toRod'
        GetSolved(N - 1, auxRod, toRod, fromRod, ref count);

        return count;
    }

    public long Toh(int N, int fromRod, int toRod, int auxRod)
    {
        long count = 0;
        GetSolved(N, fromRod, toRod, auxRod, ref count);
        return count;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int N = int.Parse(Console.ReadLine());  // Input the number of disks
        long moves = solution.Toh(N, 1, 3, 2);  // 1: from rod, 3: to rod, 2: auxiliary rod
        Console.WriteLine($"Total moves: {moves}");
    }
}
