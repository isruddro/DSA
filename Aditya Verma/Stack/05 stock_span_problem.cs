https://leetcode.com/problems/online-stock-span/submissions/1496528225/

/* Previously Consicutive smaller or equal to the number, return how many number
    we are actually getting nearest greater to left
    then we need to find the index and add it to the answer */

cpp:
#include <iostream>
#include <vector>
#include <stack>
using namespace std;

vector<int> StockSpanProblem(vector<int>& stock) {
    vector<int> ans;
    stack<int> st; // stores indices

    for (int i = 0; i < stock.size(); i++) {
        // Pop indices whose stock price is <= current price
        while (!st.empty() && stock[st.top()] <= stock[i]) {
            st.pop();
        }

        if (st.empty()) {
            ans.push_back(i + 1); // All previous prices smaller
        } else {
            ans.push_back(i - st.top()); // Distance to last greater
        }

        st.push(i);
    }

    return ans;
}

int main() {
    vector<int> stock = {100, 80, 60, 70, 60, 75, 85};
    vector<int> result = StockSpanProblem(stock);

    cout << "Stock Span: ";
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
    public static List<int> StockSpanProblem(int[] stock)
    {
        List<int> ans = new List<int>();
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < stock.Length; i++)
        {
            // Pop elements from the stack while they are smaller than or equal to the current element
            while (stack.Count > 0 && stock[stack.Peek()] <= stock[i])
            {
                stack.Pop();
            }

            // If stack is empty, it means no greater element to the left
            if (stack.Count == 0)
            {
                ans.Add(i + 1);  // Span is i + 1 as there are no elements greater than stock[i]
            }
            else
            {
                ans.Add(i - stack.Peek());  // Span is difference between current index and index of last greater element
            }

            // Push the current index onto the stack
            stack.Push(i);
        }

        return ans;
    }

    static void Main(string[] args)
    {
        int[] stock = { 100, 80, 60, 70, 60, 75, 85 };
        List<int> result = StockSpanProblem(stock);

        Console.WriteLine("Stock Span:");
        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}
