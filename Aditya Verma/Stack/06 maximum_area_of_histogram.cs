https://leetcode.com/problems/largest-rectangle-in-histogram/

/* Height of the building makes the histogram
    If we have same or bigger height then we can make area
    If we have less height we cant make area
    width = NSR - NSL - 1
    here Nearest Smaller.
    We will find the index and then we will calculate width.
    edge case is that: on the NSR we hypothetically get a index, length +1, as it will have 0
                        on the NSL we hypothetically get a index, -1, as it will have 0 
     */

Answer 1 : 


using System;
using System.Collections.Generic;

class Program
{
    static int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;

        // Arrays to store NSR and NSL indices
        int[] NSR = new int[n];
        int[] NSL = new int[n];

        Stack<int> stack = new Stack<int>();

        // Finding NSR for each bar
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
            {
                stack.Pop();
            }
            NSR[i] = stack.Count == 0 ? n : stack.Peek();
            stack.Push(i);
        }

        // Clear the stack for NSL calculation
        stack.Clear();

        // Finding NSL for each bar
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
            {
                stack.Pop();
            }
            NSL[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        // Calculate the maximum area
        int maxArea = 0;
        for (int i = 0; i < n; i++)
        {
            int width = NSR[i] - NSL[i] - 1;
            int area = heights[i] * width;
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }

    static void Main(string[] args)
    {
        int[] heights = { 2, 1, 5, 6, 2, 3 }; // Example input
        int maxArea = LargestRectangleArea(heights);
        Console.WriteLine("The largest rectangle area is: " + maxArea);
    }
}



Answer 2:


using System;
using System.Collections.Generic;

public class Solution
{
    public static int MaxHistogramArea(int[] bars)
    {
        List<int> nsl = new List<int>();  // Nearest Smaller to Left
        List<int> nsr = new List<int>();  // Nearest Smaller to Right

        //to store saparately NSR and NSL and index
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
