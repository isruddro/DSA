https://www.geeksforgeeks.org/problems/floor-in-a-sorted-array-1587115620/1

# Floor of 5 = greatest element smaller than 5. Its 4.
cpp:

Time Complexity: O(log n)
Space Complexity: O(1)

#include <vector>
using namespace std;

class Solution {
public:
    int findFloor(const vector<int>& arr, int x) {
        int n = (int)arr.size();
        int low = 0, high = n - 1;
        int result = -1;

        while (low <= high) {
            int mid = low + (high - low) / 2;

            if (arr[mid] <= x) {
                result = mid;
                low = mid + 1;
            } else { // arr[mid] > x
                high = mid - 1;
            }
        }

        return result;
    }
};

    
py3:

class Solution:
    def findFloor(self, arr, x):
        n = len(arr)
        low = 0
        high = n - 1
        result = -1
        
        while low <= high:
            mid = low + (high - low) // 2
            
            if arr[mid] <= x:
                result = mid
                low = mid + 1
            elif arr[mid] > x:
                high = mid - 1
            else:
                low = mid + 1
                
        return result


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
