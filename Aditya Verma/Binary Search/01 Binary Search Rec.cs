https://leetcode.com/problems/binary-search/description/

py:
class Solution:
    def search(self, nums: List[int], target: int) -> int:
        def binarySearch(start: int, end: int) -> int:
            if start>end:
                return -1
            mid = (start + end) //2

            if nums[mid] == target:
                return mid
            elif nums[mid] > target:
                return binarySearch(start, mid-1)
            else:
                return binarySearch(mid+1, end)

        return binarySearch(0, len(nums)-1)


cpp:
#include <iostream>
#include <vector>
using namespace std;

int BinarySearch(int start, int end, const vector<int>& list, int toFind) {
    if (start > end) return -1;

    int mid = (start + end) / 2;
    if (list[mid] == toFind) return mid;
    if (list[mid] > toFind) return BinarySearch(start, mid - 1, list, toFind);
    return BinarySearch(mid + 1, end, list, toFind);
}

int main() {
    vector<int> list = {1,2,3,4,5,6,7,8,9,10};
    int toFind = 4;

    cout << BinarySearch(0, list.size() - 1, list, toFind) << endl;

    return 0;
}






c#:
using System;
using System.Collections.Generic;

class Program
{
    static int BinarySearch(int start, int end, List<int> list, int toFind)
    {
        if (start > end) return -1;

        int mid = (start + end) / 2;
        if (list[mid] == toFind) return mid;
        if (list[mid] > toFind) return BinarySearch(start, mid - 1, list, toFind);
        return BinarySearch(mid + 1, end, list, toFind);
    }

    static void Main()
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int toFind = 4;

        Console.WriteLine(BinarySearch(0, list.Count - 1, list, toFind));
    }
}
