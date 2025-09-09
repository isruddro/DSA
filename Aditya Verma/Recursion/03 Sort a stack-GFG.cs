py:
class SortedStack:
    def __init__(self):
        self.s = []

    # Helper to insert an element into sorted stack
    def get_stack(self, st, val):
        if not st or val >= st[-1]:
            st.append(val)
            return
        top = st.pop()
        self.get_stack(st, val)
        st.append(top)

    # Recursive sort
    def sort_stack(self):
        if not self.s:
            return
        top = self.s.pop()
        self.sort_stack()
        self.get_stack(self.s, top)

    # Push element
    def push(self, val):
        self.s.append(val)

    # Sort the stack
    def sort(self):
        self.sort_stack()

    # Print stack from bottom to top
    def print_stack(self):
        print(' '.join(map(str, self.s)))

if __name__ == "__main__":
    sorted_stack = SortedStack()
    n = int(input())
    vals = list(map(int, input().split()))
    for v in vals:
        sorted_stack.push(v)

    sorted_stack.sort()
    sorted_stack.print_stack()




cpp:
#include <bits/stdc++.h>
using namespace std;

class SortedStack {
private:
    stack<int> s;

    // Helper function to insert element into sorted stack
    void getStack(stack<int>& st, int to) {
        if (st.empty() || to >= st.top()) {
            st.push(to);
            return;
        }

        int t = st.top();
        st.pop();
        getStack(st, to);
        st.push(t);
    }

    // Recursive sort function
    void sortStack() {
        if (s.empty())
            return;

        int to = s.top();
        s.pop();
        sortStack();
        getStack(s, to);
    }

public:
    // Push element into stack
    void push(int value) {
        s.push(value);
    }

    // Sort the stack
    void sort() {
        sortStack();
    }

    // Print the stack elements (top to bottom)
    void printStack() {
        stack<int> temp = s; // Copy to preserve original stack
        vector<int> v;
        while (!temp.empty()) {
            v.push_back(temp.top());
            temp.pop();
        }
        reverse(v.begin(), v.end()); // To print from bottom to top
        for (int num : v)
            cout << num << " ";
        cout << endl;
    }
};

int main() {
    SortedStack sortedStack;

    int n;
    cin >> n;
    for (int i = 0; i < n; i++) {
        int val;
        cin >> val;
        sortedStack.push(val);
    }

    sortedStack.sort();
    sortedStack.printStack();

    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class SortedStack
{
    private Stack<int> s = new Stack<int>();

    public void GetStack(Stack<int> stack, int to)
    {
        if (stack.Count == 0 || to >= stack.Peek())
        {
            stack.Push(to);
            return;
        }

        int t = stack.Peek();
        stack.Pop();
        GetStack(stack, to);
        stack.Push(t);
    }

    public void Sort()
    {
        if (s.Count == 0)
            return;

        int to = s.Peek();
        s.Pop();
        Sort();
        GetStack(s, to);
    }

    // Helper method to push values into the stack
    public void Push(int value)
    {
        s.Push(value);
    }

    // Helper method to print the stack
    public void PrintStack()
    {
        foreach (int item in s)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        SortedStack sortedStack = new SortedStack();

        // Input the stack elements
        int n = int.Parse(Console.ReadLine());
        string[] elements = Console.ReadLine().Split();
        foreach (string element in elements)
        {
            sortedStack.Push(int.Parse(element));
        }

        // Sorting the stack
        sortedStack.Sort();

        // Printing the sorted stack
        sortedStack.PrintStack();
    }
}
