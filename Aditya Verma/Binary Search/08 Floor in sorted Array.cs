https://www.geeksforgeeks.org/problems/floor-in-a-sorted-array-1587115620/1

# Floor of 5 = greatest element smaller than 5. Its 4.

py:

from typing import List

def find_floor(v: List[int], n: int, x: int) -> int:
    start, end = 0, n - 1
    ans = -1

    while start <= end:
        mid = start + (end - start) // 2

        if v[mid] == x:
            return mid

        if v[mid] > x:
            end = mid - 1
        else:
            if ans == -1 or v[mid] > v[ans]:
                ans = mid
            start = mid + 1

    return ans


if __name__ == "__main__":
    v = [1, 2, 8, 10, 10, 12, 19]
    n = len(v)
    x = 5

    result = find_floor(v, n, x)
    if result != -1:
        print(f"Floor of {x} is {v[result]} at index {result}")
    else:
        print("No floor found.")



cpp:
#include <iostream>
#include <vector>
using namespace std;

int FindFloor(const vector<long long>& v, long long n, long long x) {
    long long start = 0, end = n - 1;
    int ans = -1;

    while (start <= end) {
        long long mid = start + (end - start) / 2;

        if (v[mid] == x)
            return mid;

        if (v[mid] > x) {
            end = mid - 1;
        } else {
            if (ans == -1 || v[mid] > v[ans])
                ans = mid;

            start = mid + 1;
        }
    }

    return ans;
}

int main() {
    vector<long long> v = {1, 2, 8, 10, 10, 12, 19};
    long long n = v.size();
    long long x = 5;

    int result = FindFloor(v, n, x);
    if (result != -1)
        cout << "Floor of " << x << " is " << v[result] << " at index " << result << endl;
    else
        cout << "No floor found." << endl;

    return 0;
}




c#:

using System;

class Program
{
    static int FindFloor(long[] v, long n, long x)
    {
        long start = 0, end = n - 1;
        int ans = -1;

        while (start <= end)
        {
            int mid = (int)(start + (end - start) / 2);

            if (v[mid] == x)
                return mid;

            if (v[mid] > x)
                end = mid - 1;
            else
            {
                if (ans == -1 || v[mid] > v[ans])
                    ans = mid;

                start = mid + 1;
            }
        }

        return ans;
    }

    static void Main()
    {
        long[] v = { 1, 2, 8, 10, 10, 12, 19 };
        long n = v.Length;
        long x = 5;

        int result = FindFloor(v, n, x);
        Console.WriteLine(result != -1 
            ? $"Floor of {x} is {v[result]} at index {result}" 
            : "No floor found.");
    }
}
