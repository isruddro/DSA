py:

class Solution:
    # Helper function to insert an element at the bottom of the stack
    def insert_at_bottom(self, stack, val):
        if not stack:
            stack.append(val)
            return
        top = stack.pop()
        self.insert_at_bottom(stack, val)
        stack.append(top)

    # Recursive function to reverse the stack
    def reverse_stack(self, stack):
        if not stack:
            return
        top = stack.pop()
        self.reverse_stack(stack)
        self.insert_at_bottom(stack, top)

if __name__ == "__main__":
    n = int(input())
    vals = list(map(int, input().split()))
    
    stack = vals[::-1]  # Reverse input to simulate stack push order
    sol = Solution()
    sol.reverse_stack(stack)

    # Print stack from top to bottom
    print(' '.join(map(str, stack[::-1])))



cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    // Helper function to insert element at the bottom of the stack
    void getSolve(stack<int>& st, int t) {
        if (st.empty()) {
            st.push(t);
            return;
        }

        int to = st.top();
        st.pop();
        getSolve(st, t);
        st.push(to);
    }

    // Function to reverse the stack recursively
    void solve(stack<int>& st) {
        if (st.empty())
            return;

        int t = st.top();
        st.pop();
        solve(st);
        getSolve(st, t);
    }
};

int main() {
    int n;
    cin >> n;

    stack<int> st;
    for (int i = 0; i < n; i++) {
        int val;
        cin >> val;
        st.push(val);
    }

    Solution solution;
    solution.solve(st);

    // Print stack elements from top to bottom
    while (!st.empty()) {
        cout << st.top() << " ";
        st.pop();
    }
    cout << endl;

    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class Solution
{
    public void GetSolve(Stack<int> st, int t)
    {
        if (st.Count == 0)
        {
            st.Push(t);
            return;
        }

        int to = st.Peek();
        st.Pop();
        GetSolve(st, t);
        st.Push(to);
    }

    public void Solve(Stack<int> st)
    {
        if (st.Count == 0)
            return;

        int t = st.Peek();
        st.Pop();
        Solve(st);
        GetSolve(st, t);
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Stack<int> st = new Stack<int>();
        string[] input = Console.ReadLine().Split();

        foreach (string value in input)
        {
            st.Push(int.Parse(value));
        }

        Solution solution = new Solution();
        solution.Solve(st);

        while (st.Count > 0)
        {
            Console.Write(st.Pop() + " ");
        }
    }
}
