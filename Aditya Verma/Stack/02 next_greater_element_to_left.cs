/*
    Here, i will go left to right and we dont need to make reverse as it will give the answer directly.
 */
py:
from typing import List

def next_greater_element_to_left(arr: List[int]) -> List[int]:
    ans = []
    stack = []

    for num in arr:
        # Pop elements smaller or equal to current number
        while stack and stack[-1] <= num:
            stack.pop()

        # If stack is empty, no greater element to left
        if not stack:
            ans.append(-1)
        else:
            ans.append(stack[-1])

        # Push current number onto stack
        stack.append(num)

    return ans

# Example usage:
if __name__ == "__main__":
    arr = [1, 3, 2, 4]
    result = next_greater_element_to_left(arr)
    print("Next Greater Element to Left:", result)




cpp:
#include <bits/stdc++.h>
using namespace std;

vector<int> NextGreaterElementToLeft(vector<int>& arr) {
    vector<int> ans;
    stack<int> st;

    for (int i = 0; i < arr.size(); i++) {
        // Pop elements smaller or equal to current element
        while (!st.empty() && st.top() <= arr[i]) {
            st.pop();
        }

        // If stack is empty, no greater element to left
        if (st.empty())
            ans.push_back(-1);
        else
            ans.push_back(st.top());

        // Push current element onto stack
        st.push(arr[i]);
    }

    return ans;
}

int main() {
    vector<int> arr = {1, 3, 2, 4};
    vector<int> result = NextGreaterElementToLeft(arr);

    cout << "Next Greater Element to Left: ";
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
    public static List<int> NextGreaterElementToLeft(int[] arr)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            // If stack is empty, no greater element to the left
            if (stack.Count == 0)
            {
                ans.Add(-1);
            }
            // If the top element of stack is greater than current element
            else if (stack.Peek() > arr[i])
            {
                ans.Add(stack.Peek());
            }
            // If the top element of stack is less than or equal to the current element
            else
            {
                // Pop elements from the stack while they are smaller or equal to the current element
                while (stack.Count > 0 && stack.Peek() <= arr[i])
                {
                    stack.Pop();
                }

                // If the stack is empty, no greater element to the left
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

        return ans;
    }

    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 2, 4 };
        List<int> result = NextGreaterElementToLeft(arr);

        Console.WriteLine("Next Greater Element to Left:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
