using System;
using System.Collections.Generic;

public class Solution
{
    public static int MaxHistogramArea(int[] bars)
    {
        List<int> nsl = new List<int>();  // Nearest Smaller to Left
        List<int> nsr = new List<int>();  // Nearest Smaller to Right
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        
        bars = AppendZero(bars);  // Add a 0 at the end of the bars array to simplify the logic

        // Calculate nearest smaller to left
        for (int i = 0; i < bars.Length; i++)
        {
            if (stack.Count == 0)
            {
                nsl.Add(-1);
            }
            else if (stack.Count > 0 && stack.Peek().Item1 < bars[i])
            {
                nsl.Add(stack.Peek().Item2);
            }
            else if (stack.Count > 0 && stack.Peek().Item1 >= bars[i])
            {
                while (stack.Count > 0 && stack.Peek().Item1 >= bars[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    nsl.Add(-1);
                }
                else
                {
                    nsl.Add(stack.Peek().Item2);
                }
            }
            stack.Push(new Tuple<int, int>(bars[i], i));
        }

        // Clear the stack and calculate nearest smaller to right
        stack.Clear();

        for (int i = bars.Length - 1; i >= 0; i--)
        {
            if (stack.Count == 0)
            {
                nsr.Add(-1);
            }
            else if (stack.Count != 0 && stack.Peek().Item1 < bars[i])
            {
                nsr.Add(stack.Peek().Item2);
            }
            else if (stack.Count != 0 && stack.Peek().Item1 >= bars[i])
            {
                while (stack.Count > 0 && stack.Peek().Item1 >= bars[i])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    nsr.Add(-1);
                }
                else
                {
                    nsr.Add(stack.Peek().Item2);
                }
            }
            stack.Push(new Tuple<int, int>(bars[i], i));
        }

        nsl.RemoveAt(nsl.Count - 1); // Remove the last value which is for the 0 at the end of bars
        nsr.Reverse();
        nsr.RemoveAt(nsr.Count - 1); // Remove the last value which is for the 0 at the end of bars

        // Calculate width
        List<int> width = new List<int>();
        for (int i = 0; i < nsr.Count; i++)
        {
            width.Add(nsr[i] - nsl[i] - 1);
        }

        // Calculate area
        List<int> area = new List<int>();
        for (int i = 0; i < width.Count; i++)
        {
            area.Add(bars[i] * width[i]);
        }

        return Max(area); // Return the maximum area
    }

    private static int Max(List<int> list)
    {
        int max = list[0];
        foreach (var item in list)
        {
            if (item > max)
            {
                max = item;
            }
        }
        return max;
    }

    private static int[] AppendZero(int[] arr)
    {
        int[] newArr = new int[arr.Length + 1];
        Array.Copy(arr, newArr, arr.Length);
        newArr[arr.Length] = 0;
        return newArr;
    }

    public static void Main(string[] args)
    {
        int[] bars = { 6, 2, 5, 4, 5, 1, 6 };
        int result = MaxHistogramArea(bars);
        Console.WriteLine("Maximum area: " + result);
    }
}
