BF:


using System;
using System.Collections.Generic;

public class Program
{
    public static List<List<int>> MergeOverlappingIntervals(int[,] arr)
    {
        int n = arr.GetLength(0); // size of the array
        // Sort the given intervals based on the start time
        List<int[]> intervals = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            intervals.Add(new int[] { arr[i, 0], arr[i, 1] });
        }

        intervals.Sort((a, b) => a[0].CompareTo(b[0]));

        List<List<int>> ans = new List<List<int>>();

        for (int i = 0; i < n; i++) // select an interval
        {
            int start = intervals[i][0];
            int end = intervals[i][1];

            // Skip all the merged intervals
            if (ans.Count > 0 && end <= ans[ans.Count - 1][1])
            {
                continue;
            }

            // Check the rest of the intervals
            for (int j = i + 1; j < n; j++)
            {
                if (intervals[j][0] <= end)
                {
                    end = Math.Max(end, intervals[j][1]);
                }
                else
                {
                    break;
                }
            }
            ans.Add(new List<int> { start, end });
        }
        return ans;
    }

    public static void Main(string[] args)
    {
        int[,] arr = { { 1, 3 }, { 8, 10 }, { 2, 6 }, { 15, 18 } };
        List<List<int>> ans = MergeOverlappingIntervals(arr);
        Console.WriteLine("The merged intervals are: ");
        foreach (var interval in ans)
        {
            Console.Write($"[{interval[0]}, {interval[1]}] ");
        }
        Console.WriteLine();
    }
}



Optimal:


using System;
using System.Collections.Generic;

public class Program
{
    public static List<List<int>> MergeOverlappingIntervals(int[,] arr)
    {
        int n = arr.GetLength(0); // size of the array
        // Sort the given intervals based on the start time
        List<int[]> intervals = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            intervals.Add(new int[] { arr[i, 0], arr[i, 1] });
        }

        intervals.Sort((a, b) => a[0].CompareTo(b[0]));

        List<List<int>> ans = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            // if the current interval does not lie in the last interval:
            if (ans.Count == 0 || intervals[i][0] > ans[ans.Count - 1][1])
            {
                ans.Add(new List<int> { intervals[i][0], intervals[i][1] });
            }
            // if the current interval lies in the last interval:
            else
            {
                ans[ans.Count - 1][1] = Math.Max(ans[ans.Count - 1][1], intervals[i][1]);
            }
        }

        return ans;
    }

    public static void Main(string[] args)
    {
        int[,] arr = { { 1, 3 }, { 8, 10 }, { 2, 6 }, { 15, 18 } };
        List<List<int>> ans = MergeOverlappingIntervals(arr);
        Console.WriteLine("The merged intervals are: ");
        foreach (var interval in ans)
        {
            Console.Write($"[{interval[0]}, {interval[1]}] ");
        }
        Console.WriteLine();
    }
}
