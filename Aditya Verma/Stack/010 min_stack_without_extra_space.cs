https://leetcode.com/problems/min-stack/description/?utm_source=chatgpt.com

py:

class MinStack:
    def __init__(self):
        self.stack = []
        self.min_element = float('inf')

    def push(self, val: int):
        if not self.stack:
            self.stack.append(val)
            self.min_element = val
        else:
            if val >= self.min_element:
                self.stack.append(val)
            else:
                # Store a modified value
                self.stack.append(2 * val - self.min_element)
                self.min_element = val

    def pop(self):
        if not self.stack:
            print("Stack is empty.")
            return
        top = self.stack.pop()
        if top < self.min_element:
            self.min_element = 2 * self.min_element - top

    def get_min(self) -> int:
        if not self.stack:
            return -1
        return self.min_element

    def print_stack_min(self):
        print("Current Min:", self.get_min())


# Example usage:
if __name__ == "__main__":
    ms = MinStack()
    arr = [18, 19, 29, 15, 16]

    for num in arr:
        ms.push(num)
        print(f"Pushed: {num}, ", end="")
        ms.print_stack_min()

    print("Popping elements...")
    while ms.get_min() != -1:
        ms.pop()
        ms.print_stack_min()



cpp:
#include <bits/stdc++.h>
using namespace std;

class MinStack {
private:
    vector<long long> stack;
    long long minElement;

public:
    MinStack() {
        minElement = LLONG_MAX;
    }

    int GetMin() {
        if (stack.empty()) return -1; // Stack empty
        return (int)minElement;
    }

    void Push(int ele) {
        if (stack.empty()) {
            stack.push_back(ele);
            minElement = ele;
        } else {
            if (ele >= minElement) {
                stack.push_back(ele);
            } else {
                // Store a "modified" value
                stack.push_back(2LL * ele - minElement);
                minElement = ele;
            }
        }
    }

    void Pop() {
        if (stack.empty()) {
            cout << "Stack is empty." << endl;
            return;
        }

        long long top = stack.back();
        stack.pop_back();

        if (top < minElement) {
            minElement = 2LL * minElement - top;
        }
    }

    void PrintStackMin() {
        cout << "Current Min: " << GetMin() << endl;
    }
};

int main() {
    MinStack ms;
    int arr[] = {18, 19, 29, 15, 16};

    for (int num : arr) {
        ms.Push(num);
        cout << "Pushed: " << num << ", ";
        ms.PrintStackMin();
    }

    cout << "Popping elements..." << endl;
    while (true) {
        if (ms.GetMin() == -1) break;
        ms.Pop();
        ms.PrintStackMin();
    }

    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class Solution
{
    private static List<int> stack = new List<int>();
    private static int minElement = int.MaxValue;

    // Method to get the minimum element from the stack
    public static int GetMin()
    {
        if (stack.Count == 0)
        {
            return -1; // Stack is empty
        }
        return minElement;
    }

    // Method to push an element onto the stack
    public static void Push(int ele)
    {
        if (stack.Count == 0)
        {
            stack.Add(ele);
            minElement = ele;
        }
        else
        {
            // If the current element is greater than or equal to the minimum element
            if (ele >= minElement)
            {
                stack.Add(ele);
            }
            // If the current element is smaller than the minimum element
            else
            {
                stack.Add(2 * ele - minElement);
                minElement = ele;
            }
        }
    }

    // Method to pop an element from the stack
    public static void Pop()
    {
        if (stack.Count == 0)
        {
            Console.WriteLine("Stack is empty.");
            return;
        }

        int top = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);

        // If the popped element is smaller than the current minimum element
        if (top < minElement)
        {
            minElement = 2 * minElement - top;
        }
    }

    // Main method to test the functionality
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
            Pop();
            Console.WriteLine("Minimum after pop: " + GetMin());
        }
    }
}
