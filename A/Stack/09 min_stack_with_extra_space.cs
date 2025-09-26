https://leetcode.com/problems/min-stack/description/?utm_source=chatgpt.com

cpp:
Time Complexity: O(1) per operation
Space Complexity: O(n) for two stacks


py3:
Time Complexity: O(1) per operation
Space Complexity: O(n) for two stacks


class MinStack:

    def __init__(self):
        self.stack = []    # main stack
        self.support = []  # stack to track current minimums

    def push(self, val: int) -> None:
        self.stack.append(val)
        if not self.support or val <= self.support[-1]:
            self.support.append(val)

    def pop(self) -> None:
        if not self.stack:
            return
        ans = self.stack.pop()
        if self.support and ans == self.support[-1]:
            self.support.pop()

    def top(self) -> int:
        if not self.stack:
            return -1
        return self.stack[-1]

    def getMin(self) -> int:
        if not self.support:
            return -1
        return self.support[-1]



cpp:
#include <iostream>
#include <stack>
using namespace std;

class MinStack {
private:
    stack<int> st;      // main stack
    stack<int> support; // stack to keep track of minimums

public:
    void push(int ele) {
        st.push(ele);
        if (support.empty() || ele <= support.top()) {
            support.push(ele);
        }
    }

    int pop() {
        if (st.empty()) return -1;
        int ans = st.top();
        st.pop();
        if (!support.empty() && ans == support.top()) {
            support.pop();
        }
        return ans;
    }

    int getMin() {
        if (support.empty()) return -1;
        return support.top();
    }
};

int main() {
    int arr[] = {18, 19, 29, 15, 16};
    int n = sizeof(arr)/sizeof(arr[0]);

    MinStack minStack;

    for (int i = 0; i < n; i++) {
        minStack.push(arr[i]);
        cout << "Pushed: " << arr[i] << ", Minimum: " << minStack.getMin() << endl;
    }

    cout << "Popping elements..." << endl;
    while (true) {
        int popped = minStack.pop();
        if (popped == -1) break;
        cout << "Popped: " << popped << ", Minimum: " << minStack.getMin() << endl;
    }

    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class Solution
{
    private static List<int> stack = new List<int>();
    private static List<int> support = new List<int>();

    // Method to get the minimum element from the support stack
    public static int GetMin()
    {
        if (support.Count == 0)
        {
            return -1;
        }
        return support[support.Count - 1];
    }

    // Method to push an element onto the stack and support stack
    public static void Push(int ele)
    {
        stack.Add(ele);

        // If support is empty or the current element is less than or equal to the current minimum
        if (support.Count == 0 || support[support.Count - 1] >= ele)
        {
            support.Add(ele);
        }
    }

    // Method to pop an element from the stack and support stack
    public static int Pop()
    {
        if (stack.Count == 0)
        {
            return -1;
        }

        int ans = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);

        // If the popped element is the minimum element, pop it from the support stack
        if (support[support.Count - 1] == ans)
        {
            support.RemoveAt(support.Count - 1);
        }

        return ans;
    }

    // Main method to test the stack functionality
    public static void Main(string[] args)
    {
        int[] arr = { 18, 19, 29, 15, 16 };

        foreach (int num in arr)
        {
            Push(num);
            Console.WriteLine("Pushed: " + num + ", Minimum: " + GetMin());
        }

        Console.WriteLine("Popping elements...");
        while (stack.Count > 0)
        {
            int popped = Pop();
            Console.WriteLine("Popped: " + popped + ", Minimum: " + GetMin());
        }
    }
}
