https://leetcode.com/problems/next-greater-element-i/submissions/1315287157/

# Things to rem:
     When its about array and j is dependent on i on bruite force, then we need to think of implementing with Stack.
    LIFO
    1324
    We need to traverse from right as stack is LIFO.


    Idea is:
    1. s.Peek() > array[i]
    2. s = empty then return -1
    3. s.Peek() <= array[i] (means we have stacks top element that is lesser than i, so we need to
                                keep looking for the greater element and keep poppin)
        POP
            (two condition:)
            1. s = empty then return -1
            2. or we found s.Peek() > array[i]
    
    At last we need to reverse for the answer


 
py:

def next_greater_element_to_right(arr):
    ans = []
    stack = []

    # Traverse from right to left
    for i in range(len(arr) - 1, -1, -1):
        # Pop elements smaller or equal to current element
        while stack and stack[-1] <= arr[i]:
            stack.pop()

        # If stack is empty, no greater element
        if not stack:
            ans.append(-1)
        else:
            ans.append(stack[-1])

        # Push current element onto stack
        stack.append(arr[i])

    # Reverse to restore original order
    ans.reverse()
    return ans


if __name__ == "__main__":
    arr = [1, 3, 2, 4]
    result = next_greater_element_to_right(arr)
    print("Next Greater Element to Right:", result)





cpp:
#include <bits/stdc++.h>
using namespace std;

vector<int> NextGreaterElementToRight(vector<int>& arr) {
    vector<int> ans;
    stack<int> s;

    // Traverse from right to left
    for (int i = arr.size() - 1; i >= 0; i--) {
        // Pop smaller or equal elements
        while (!s.empty() && s.top() <= arr[i]) {
            s.pop();
        }

        // If stack is empty, no greater element to the right
        if (s.empty()) {
            ans.push_back(-1);
        } else {
            ans.push_back(s.top());
        }

        // Push current element onto stack
        s.push(arr[i]);
    }

    // Reverse to get the correct order
    reverse(ans.begin(), ans.end());
    return ans;
}

int main() {
    vector<int> arr = {1, 3, 2, 4};
    vector<int> result = NextGreaterElementToRight(arr);

    cout << "Next Greater Element to Right: ";
    for (int x : result) {
        cout << x << " ";
    }
    cout << endl;

    return 0;
}



c#:

using System;
using System.Collections.Generic;

class Solution
{
    public static List<int> NextGreaterElementToRight(int[] arr)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        // Traverse the array from right to left
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            // If stack is empty, no greater element to the right
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

                // If the stack is empty, no greater element to the right
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

        // Reverse the result as we were traversing from right to left
        ans.Reverse();
        return ans;
    }

    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 2, 4 };
        List<int> result = NextGreaterElementToRight(arr);

        Console.WriteLine("Next Greater Element to Right:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
