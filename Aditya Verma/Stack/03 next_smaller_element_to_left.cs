cpp:
#include <bits/stdc++.h>
using namespace std;

vector<int> NextSmallerElementToLeft(vector<int>& arr) {
    vector<int> ans;
    stack<int> st;

    for (int i = 0; i < arr.size(); i++) {
        // Pop elements greater than or equal to current element
        while (!st.empty() && st.top() >= arr[i]) {
            st.pop();
        }

        // If stack is empty, no smaller element to left
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
    vector<int> arr = {4, 5, 2, 10, 8};
    vector<int> result = NextSmallerElementToLeft(arr);

    cout << "Next Smaller Element to Left: ";
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
    public static List<int> NextSmallerElementToLeft(int[] arr)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        // Traverse the array from left to right
        for (int i = 0; i < arr.Length; i++)
        {
            // If stack is empty, no smaller element to the left
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

                // If the stack is empty, no smaller element to the left
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
        int[] arr = { 4, 5, 2, 10, 8 };
        List<int> result = NextSmallerElementToLeft(arr);

        Console.WriteLine("Next Smaller Element to Left:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
