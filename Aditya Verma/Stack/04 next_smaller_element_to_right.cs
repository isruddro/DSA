py:

from typing import List

def next_smaller_element_to_right(arr: List[int]) -> List[int]:
    ans = []
    stack = []

    # Traverse from right to left
    for num in reversed(arr):
        # Pop elements greater than or equal to current number
        while stack and stack[-1] >= num:
            stack.pop()

        # If stack is empty, no smaller element to right
        if not stack:
            ans.append(-1)
        else:
            ans.append(stack[-1])

        # Push current number onto stack
        stack.append(num)

    # Reverse result to match original order
    ans.reverse()
    return ans

# Example usage:
if __name__ == "__main__":
    arr = [4, 5, 2, 10, 8]
    result = next_smaller_element_to_right(arr)
    print("Next Smaller Element to Right:", result)





cpp:
#include <bits/stdc++.h>
using namespace std;

vector<int> NextSmallerElementToRight(vector<int>& arr) {
    vector<int> ans;
    stack<int> st;

    // Traverse from right to left
    for (int i = arr.size() - 1; i >= 0; i--) {
        // Pop elements greater than or equal to current
        while (!st.empty() && st.top() >= arr[i]) {
            st.pop();
        }

        // If stack empty, no smaller element
        if (st.empty())
            ans.push_back(-1);
        else
            ans.push_back(st.top());

        st.push(arr[i]);
    }

    // Reverse the result since we traversed right-to-left
    reverse(ans.begin(), ans.end());
    return ans;
}

int main() {
    vector<int> arr = {4, 5, 2, 10, 8};
    vector<int> result = NextSmallerElementToRight(arr);

    cout << "Next Smaller Element to Right: ";
    for (int x : result)
        cout << x << " ";
    cout << endl;

    return 0;
}


c#:
using System;
using System.Collections.Generic;

class Solution
{
    public static List<int> NextSmallerElementToRight(int[] arr)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        // Traverse the array from right to left
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            // If stack is empty, no smaller element to the right
            if (stack.Count == 0)
            {
                ans.Add(-1);
            }
            // If the top element of stack is smaller than current element
            else if (stack.Peek() < arr[i])
            {
                ans.Add(stack.Peek());
            }
            // If the top element of stack is greater than or equal to the current element
            else
            {
                // Pop elements from the stack while they are greater than or equal to the current element
                while (stack.Count > 0 && stack.Peek() >= arr[i])
                {
                    stack.Pop();
                }

                // If the stack is empty, no smaller element to the right
                if (stack.Count == 0)
                {
                    ans.Add(-1);
                }
                else
                {
                    ans.Add(stack.Peek());
                }
            }

            // Push the current element onto the stack
            stack.Push(arr[i]);
        }

        // Reverse the result list as we have traversed the array from right to left
        ans.Reverse();
        return ans;
    }

    static void Main(string[] args)
    {
        int[] arr = { 4, 5, 2, 10, 8 };
        List<int> result = NextSmallerElementToRight(arr);

        Console.WriteLine("Next Smaller Element to Right:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
