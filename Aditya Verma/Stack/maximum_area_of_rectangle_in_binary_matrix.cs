using System;
using System.Collections.Generic;

public class Solution
{
    public static List<int> NSR(int[] bars)
    {
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        List<int> nsr = new List<int>();
        bars = AppendZero(bars); // Add a 0 at the end of the bars array to simplify the logic

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

        nsr.Reverse();
        nsr.RemoveAt(nsr.Count - 1); // Remove the last value which is for the 0 at the end of bars
        return nsr;
    }

    public static List<int> NSL(int[] bars)
    {
        Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
        List<int> nsl = new List<int>();
        bars = AppendZero(bars); // Add a 0 at the end of the bars array to simplify the logic

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

        nsl.RemoveAt(nsl.Count - 1); // Remove the last value which is for the 0 at the end of bars
        return nsl;
    }

    public static int MaxAreaHistogram(int[] bars)
    {
        List<int> right = NSR(bars);
        List<int> left = NSL(bars);
        List<int> width = new List<int>();

        for (int i = 0; i < right.Count; i++)
        {
            width.Add(right[i] - left[i] - 1);
        }

        List<int> area = new List<int>();
        for (int i = 0; i < width.Count; i++)
        {
            area.Add(bars[i] * width[i]);
        }

        return Max(area);
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
        int[,] arr = {
            {0, 1, 1, 0},
            {1, 1, 1, 1},
            {1, 1, 1, 1},
            {1, 1, 0, 0}
        };

        int[] bars = new int[arr.GetLength(1)];
        int area = 0;

        // Initialize bars with the first row
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            bars[j] = arr[0, j];
        }
        
        area = MaxAreaHistogram(bars);

        // Process remaining rows
        for (int i = 1; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    bars[j] = 0;
                }
                else
                {
                    bars[j] = bars[j] + arr[i, j];
                }
            }
            area = Math.Max(area, MaxAreaHistogram(bars));
        }

        Console.WriteLine("Maximum area: " + area);
    }
}
