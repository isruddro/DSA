https://leetcode.com/problems/maximal-rectangle/description/

/* 
    Answer will be the maximum of the each MAH.
    ans: Max(MAH(H1), MAH(H2), MAH(H3), MAH(H4))


    we traverse top to bottom, if we find any 0 in bottom index, we will reset to 0

    Process is:

    MAH fn.
    traverse every row.
        check if there is any 0 make that a[i][j] = 0
 */
py:
Time Complexity: O(n*m)
Space Complexity: O(m) for histogram + O(m) for stack in MAH


from typing import List

class Solution:
    def MAH(self, heights: List[int]) -> int:
        n = len(heights)
        stack = []
        left = [-1] * n
        right = [n] * n
        
        # Nearest Smaller to Left
        for i in range(n):
            while stack and heights[stack[-1]] >= heights[i]:
                stack.pop()
            left[i] = stack[-1] if stack else -1
            stack.append(i)
        
        # Clear stack for NSR
        stack.clear()
        
        # Nearest Smaller to Right
        for i in range(n-1, -1, -1):
            while stack and heights[stack[-1]] >= heights[i]:
                stack.pop()
            right[i] = stack[-1] if stack else n
            stack.append(i)
        
        # Compute max area
        max_area = 0
        for i in range(n):
            width = right[i] - left[i] - 1
            max_area = max(max_area, heights[i] * width)
        
        return max_area

    def maximalRectangle(self, matrix: List[List[str]]) -> int:
        if not matrix or not matrix[0]:
            return 0
        
        n, m = len(matrix), len(matrix[0])
        histogram = [0] * m
        max_area = 0
        
        for i in range(n):
            for j in range(m):
                # Convert '0'/'1' to int and build histogram
                histogram[j] = 0 if matrix[i][j] == '0' else histogram[j] + 1
            max_area = max(max_area, self.MAH(histogram))
        
        return max_area


cpp:
#include <iostream>
#include <vector>
#include <stack>
#include <algorithm>
using namespace std;

// Function to calculate Maximum Area Histogram (MAH)
int MAH(const vector<int>& heights) {
    int n = heights.size();
    vector<int> left(n), right(n);
    stack<int> st;

    // Nearest Smaller to Left
    for (int i = 0; i < n; i++) {
        while (!st.empty() && heights[st.top()] >= heights[i])
            st.pop();
        left[i] = st.empty() ? -1 : st.top();
        st.push(i);
    }

    // Clear stack for NSR
    while (!st.empty()) st.pop();

    // Nearest Smaller to Right
    for (int i = n - 1; i >= 0; i--) {
        while (!st.empty() && heights[st.top()] >= heights[i])
            st.pop();
        right[i] = st.empty() ? n : st.top();
        st.push(i);
    }

    // Compute max area
    int maxArea = 0;
    for (int i = 0; i < n; i++) {
        int width = right[i] - left[i] - 1;
        maxArea = max(maxArea, heights[i] * width);
    }
    return maxArea;
}

// Function to find maximum rectangle in a binary matrix
int MaxRectangle(vector<vector<int>>& matrix) {
    int n = matrix.size();
    if (n == 0) return 0;
    int m = matrix[0].size();
    vector<int> histogram(m, 0);
    int maxArea = 0;

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            histogram[j] = matrix[i][j] == 0 ? 0 : histogram[j] + matrix[i][j];
        }
        maxArea = max(maxArea, MAH(histogram));
    }
    return maxArea;
}

int main() {
    vector<vector<int>> matrix = {
        {1, 0, 1, 0, 0},
        {1, 0, 1, 1, 1},
        {1, 1, 1, 1, 1},
        {1, 0, 0, 1, 0}
    };

    cout << "Maximum Area of Rectangle: " << MaxRectangle(matrix) << endl;
    return 0;
}




c#:
using System;
using System.Collections.Generic;

class Program
{
    // Function to calculate Maximum Area Histogram (MAH)
    static int MAH(int[] heights)
    {
        int n = heights.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        Stack<int> stack = new Stack<int>();

        // Calculate nearest smaller to left
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
            {
                stack.Pop();
            }
            left[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        // Clear the stack to reuse for right calculation
        stack.Clear();

        // Calculate nearest smaller to right
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
            {
                stack.Pop();
            }
            right[i] = stack.Count == 0 ? n : stack.Peek();
            stack.Push(i);
        }

        // Calculate area for each bar and find max area
        int maxArea = 0;
        for (int i = 0; i < n; i++)
        {
            int width = right[i] - left[i] - 1;
            maxArea = Math.Max(maxArea, heights[i] * width);
        }
        return maxArea;
    }

    // Function to find maximum rectangle area in a binary matrix
    static int MaxRectangle(int[][] matrix)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;

        int[] histogram = new int[m];
        int maxArea = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                // Update the histogram
                if (matrix[i][j] == 0)
                {
                    histogram[j] = 0;
                }
                else
                {
                    histogram[j] += matrix[i][j];
                }
            }
            // Calculate the maximum area for the current histogram
            maxArea = Math.Max(maxArea, MAH(histogram));
        }
        return maxArea;
    }

    static void Main(string[] args)
    {
        int[][] matrix = new int[][]
        {
            new int[] {1, 0, 1, 0, 0},
            new int[] {1, 0, 1, 1, 1},
            new int[] {1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 1, 0}
        };

        Console.WriteLine("Maximum Area of Rectangle: " + MaxRectangle(matrix));
    }
}
