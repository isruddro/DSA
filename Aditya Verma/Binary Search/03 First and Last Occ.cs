https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/

# In this:
    * We need to find the exact number and also make sure if that number is there on left or right.
    * If number is not there or if there is no first and last occ then return -1.
    So, find exact number and check left for first occ and check right for last occ with function.
    * We take + and - inf to dissmiss inside the min and max function. And also considering lower and upper possible bounds.

py:from typing import List

class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        min_index = float('inf')
        max_index = float('-inf')

        def binarySearch(start: int, end: int, left_bias: bool) -> None:
            nonlocal min_index, max_index
            if start > end:
                return

            mid = (start + end) // 2

            if nums[mid] > target:
                binarySearch(start, mid - 1, left_bias)
            elif nums[mid] < target:
                binarySearch(mid + 1, end, left_bias)
            else:
                if left_bias:
                    min_index = min(min_index, mid)
                    binarySearch(start, mid - 1, left_bias)
                else:
                    max_index = max(max_index, mid)
                    binarySearch(mid + 1, end, left_bias)

        # run both searches
        binarySearch(0, len(nums) - 1, True)
        binarySearch(0, len(nums) - 1, False)

        # if not found, return [-1, -1]
        if min_index == float('inf') or max_index == float('-inf'):
            return [-1, -1]

        return [min_index, max_index]




cpp:
#include <iostream>
#include <vector>
#include <climits>
using namespace std;

int minIndex = INT_MAX;
int maxIndex = INT_MIN;

void BinarySearch(int start, int end, const vector<int>& nums, int target, bool leftBias) {
    if (start > end) return;

    int mid = (start + end) / 2;

    if (nums[mid] > target) {
        BinarySearch(start, mid - 1, nums, target, leftBias);
    } 
    else if (nums[mid] < target) {
        BinarySearch(mid + 1, end, nums, target, leftBias);
    } 
    else {
        if (leftBias) {
            minIndex = min(minIndex, mid);
            BinarySearch(start, mid - 1, nums, target, leftBias);
        } else {
            maxIndex = max(maxIndex, mid);
            BinarySearch(mid + 1, end, nums, target, leftBias);
        }
    }
}

vector<int> SearchRange(const vector<int>& nums, int target) {
    minIndex = INT_MAX;
    maxIndex = INT_MIN;

    BinarySearch(0, nums.size() - 1, nums, target, true);
    BinarySearch(0, nums.size() - 1, nums, target, false);

    if (minIndex == INT_MAX) minIndex = -1;
    if (maxIndex == INT_MIN) maxIndex = -1;

    return {minIndex, maxIndex};
}

int main() {
    vector<int> nums = {5, 7, 7, 8, 8, 10};
    int target = 8;

    vector<int> result = SearchRange(nums, target);
    cout << "[" << result[0] << ", " << result[1] << "]" << endl;

    return 0;
}




c#:

using System;
using System.Collections.Generic;

class Program
{
    static int minIndex = int.MaxValue;
    static int maxIndex = int.MinValue;

    static void BinarySearch(int start, int end, List<int> nums, int target, bool leftBias)
    {
        if (start > end) return;

        int mid = (start + end) / 2;

        if (nums[mid] > target)
        {
            BinarySearch(start, mid - 1, nums, target, leftBias);
        }
        else if (nums[mid] < target)
        {
            BinarySearch(mid + 1, end, nums, target, leftBias);
        }
        else
        {
            if (leftBias)
            {
                minIndex = Math.Min(minIndex, mid);
                BinarySearch(start, mid - 1, nums, target, leftBias);
            }
            else
            {
                maxIndex = Math.Max(maxIndex, mid);
                BinarySearch(mid + 1, end, nums, target, leftBias);
            }
        }
    }

    static List<int> SearchRange(List<int> nums, int target)
    {
        BinarySearch(0, nums.Count - 1, nums, target, true);
        BinarySearch(0, nums.Count - 1, nums, target, false);

        if (minIndex == int.MaxValue) minIndex = -1;
        if (maxIndex == int.MinValue) maxIndex = -1;

        return new List<int> { minIndex, maxIndex };
    }

    static void Main()
    {
        List<int> nums = new List<int> { 5, 7, 7, 8, 8, 10 };
        int target = 8;

        List<int> result = SearchRange(nums, target);
        Console.WriteLine($"[{result[0]}, {result[1]}]");
    }
}
