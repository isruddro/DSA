https://www.geeksforgeeks.org/problems/allocate-minimum-number-of-pages0937/1

py:

Time: O(N * log(sum(A)))

Space: O(1)

    
from typing import List

class Solution:
    # Helper function to check if allocation is possible
    def check(self, A: List[int], N: int, days: int, Pages: int) -> bool:
        curr, d = 0, 1
        for i in range(N):
            curr += A[i]
            if curr > Pages:
                curr = A[i]
                d += 1
                if d > days:
                    return False
        return True

    # Function to find minimum pages
    def findPages(self, A: List[int], M: int) -> int:
        N = len(A)
        if M > N:
            return -1

        mn = max(A)      # Minimum possible pages
        mx = sum(A)      # Maximum possible pages

        # Binary search for the answer
        while mn < mx:
            mid = mn + (mx - mn) // 2
            if self.check(A, N, M, mid):
                mx = mid
            else:
                mn = mid + 1

        return mn


        

cpp:

#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

// Function to check if allocation is possible
bool Check(const vector<int>& A, int N, int days, int Pages) {
    int curr = 0, d = 1;

    for (int i = 0; i < N; i++) {
        curr += A[i];
        if (curr > Pages) {
            curr = A[i];
            d++;
            if (d > days) return false;
        }
    }

    return true;
}

// Function to find the minimum number of pages
int FindPages(const vector<int>& A, int N, int M) {
    if (M > N) return -1;

    int mn = *max_element(A.begin(), A.end());
    int mx = 0;
    for (int i = 0; i < N; i++) mx += A[i];

    // Binary search for the answer
    while (mn < mx) {
        int mid = mn + (mx - mn) / 2;
        if (Check(A, N, M, mid))
            mx = mid;
        else
            mn = mid + 1;
    }

    return mn;
}

int main() {
    vector<int> A = {12, 34, 67, 90};  // Number of pages in books
    int N = A.size();                  // Number of books
    int M = 2;                          // Number of students

    int result = FindPages(A, N, M);
    cout << "The minimum number of pages that can be assigned: " << result << endl;

    return 0;
}



c#:

using System;

class Solution
{
    // Function to check if it's possible to allocate pages such that no student
    // reads more than 'Pages' pages within 'days' days
    static bool Check(int[] A, int N, int days, int Pages)
    {
        int curr = 0, d = 1;

        for (int i = 0; i < N; i++)
        {
            curr += A[i];
            if (curr > Pages)
            {
                curr = A[i];
                d++;
                if (d > days) return false;
            }
        }

        return true;
    }

    // Function to find the minimum number of pages that can be assigned
    // to each student
    static int FindPages(int[] A, int N, int M)
    {
        if (M > N) return -1;

        int mx = 0, mn = int.MinValue;

        for (int i = 0; i < N; i++)
        {
            mn = Math.Max(mn, A[i]);
            mx += A[i];
        }

        // Binary search to find the answer
        while (mn < mx)
        {
            int mid = mn + (mx - mn) / 2;
            if (Check(A, N, M, mid)) mx = mid;
            else mn = mid + 1;
        }

        return mn;
    }

    static void Main()
    {
        int[] A = { 12, 34, 67, 90 };  // Number of pages in books
        int N = A.Length;              // Number of books
        int M = 2;                     // Number of students

        int result = FindPages(A, N, M);

        Console.WriteLine($"The minimum number of pages that can be assigned: {result}");
    }
}
