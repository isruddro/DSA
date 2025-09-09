py:

import math

class Solution:
    # Helper function to delete the kth element from top
    def get_deleted(self, stack, k):
        if k == 0:
            stack.pop()
            return
        
        top = stack.pop()
        self.get_deleted(stack, k - 1)
        stack.append(top)

    # Delete the middle element of the stack
    def delete_mid(self, stack):
        size = len(stack)
        k = math.ceil(size / 2) - 1  # middle index from top
        self.get_deleted(stack, k)

if __name__ == "__main__":
    n = int(input())
    vals = list(map(int, input().split()))

    stack = vals[::-1]  # Reverse to simulate pushing onto stack
    sol = Solution()
    sol.delete_mid(stack)

    # Print stack from top to bottom
    print(' '.join(map(str, stack[::-1])))




cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    // Helper function to delete the kth element from top
    void getDeleted(stack<int>& s, int k) {
        if (k == 0) {
            s.pop();
            return;
        }

        int t = s.top();
        s.pop();
        getDeleted(s, k - 1);
        s.push(t);
    }

    // Function to delete the middle element of the stack
    void deleteMid(stack<int>& s, int sizeOfStack) {
        int k = ceil(sizeOfStack / 2.0) - 1; // middle index from top
        getDeleted(s, k);
    }
};

int main() {
    stack<int> s;
    int n;
    cin >> n;

    for (int i = 0; i < n; i++) {
        int val;
        cin >> val;
        s.push(val);
    }

    Solution sol;
    sol.deleteMid(s, n);

    // Print stack from top to bottom
    stack<int> temp = s;
    while (!temp.empty()) {
        cout << temp.top() << " ";
        temp.pop();
    }
    cout << endl;

    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class Solution
{
    // Function to delete the middle element of a stack
    public void GetDeleted(Stack<int> s, int k)
    {
        // Base case: If k reaches 0, pop the top element of the stack
        if (k == 0)
        {
            s.Pop();
            return;
        }
        
        // Pop the top element and recursively call the function with k-1
        int t = s.Peek();
        s.Pop();
        GetDeleted(s, k - 1);
        
        // Push the element back after deleting the middle one
        s.Push(t);
    }

    public void DeleteMid(Stack<int> s, int sizeOfStack)
    {
        // Calculate the index of the middle element
        int k = (int)Math.Ceiling(sizeOfStack / 2.0) - 1;
        
        // Call GetDeleted to delete the middle element
        GetDeleted(s, k);
    }
}
