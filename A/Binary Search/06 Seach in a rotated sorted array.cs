https://leetcode.com/problems/search-in-rotated-sorted-array/description/?utm_source=chatgpt.com

# How to:
    1. Find min elements index.
    2. Seach on right and left of that element.
        If not found then return -1.
        Final ans will be value :  if result != -1:
cpp:
Time	O(log n)
Space	O(1)

    #include <vector>
using namespace std;

class Solution {
public:
    int search(vector<int>& nums, int target) {
        int start = 0, end = (int)nums.size() - 1;

        while (start <= end) {
            int mid = start + (end - start) / 2;

            if (nums[mid] == target) {
                return mid;
            }

            // Check if left half is sorted
            if (nums[start] <= nums[mid]) {
                if (nums[start] <= target && target <= nums[mid]) {
                    end = mid - 1;
                } else {
                    start = mid + 1;
                }
            } else {
                // Right half must be sorted
                if (nums[mid] <= target && target <= nums[end]) {
                    start = mid + 1;
                } else {
                    end = mid - 1;
                }
            }
        }

        return -1;
    }
};


py3:
Time	O(log n)
Space	O(1)

from typing import List

class Solution:
    def search(self, nums: List[int], target: int) -> int:
        start, end = 0, len(nums) - 1

        while start <= end:
            mid = start + (end - start) // 2

            if nums[mid] == target:
                return mid

            # Check if left half is sorted
            if nums[start] <= nums[mid]:
                if nums[start] <= target <= nums[mid]:
                    end = mid - 1
                else:
                    start = mid + 1
            else:
                # Right half must be sorted
                if nums[mid] <= target <= nums[end]:
                    start = mid + 1
                else:
                    end = mid - 1

        return -1




cpp:
#include <iostream>
#include <vector>
using namespace std;

int Search(const vector<int>& nums, int target) {
    int start = 0, end = nums.size() - 1;

    while (start <= end) {
        int mid = start + (end - start) / 2;

        // If the target is found
        if (nums[mid] == target)
            return mid;

        // Check if the left half is sorted
        if (nums[start] <= nums[mid]) {
            // If target lies within the sorted left half
            if (nums[start] <= target && target <= nums[mid])
                end = mid - 1;
            else
                start = mid + 1;
        }
        else {
            // Otherwise, right half must be sorted
            if (nums[mid] <= target && target <= nums[end])
                start = mid + 1;
            else
                end = mid - 1;
        }
    }

    return -1; // Target not found
}

int main() {
    vector<int> nums = {4, 5, 6, 7, 0, 1, 2};
    int target = 0;

    int result = Search(nums, target);
    if (result != -1)
        cout << "Target found at index: " << result << endl;
    else
        cout << "Target not found." << endl;

    return 0;
}




c#:

using System;

class Program
{
    static int Search(int[] nums, int target)
    {
        int start = 0, end = nums.Length - 1;

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            // If the target is found
            if (nums[mid] == target) 
                return mid;

            // Check if the left half is sorted
            if (nums[start] <= nums[mid])
            {
                // If the target lies within the sorted left half
                if (nums[start] <= target && target <= nums[mid])
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            else
            {
                // If the target lies within the sorted right half
                if (nums[mid] <= target && target <= nums[end])
                    start = mid + 1;
                else
                    end = mid - 1;
            }
        }

        return -1; // Target not found
    }

    static void Main()
    {
        int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
        int target = 0;

        int result = Search(nums, target);
        Console.WriteLine(result != -1
            ? $"Target found at index: {result}"
            : "Target not found.");
    }
}
