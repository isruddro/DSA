https://leetcode.com/problems/search-insert-position/description/?utm_source=chatgpt.com

cpp:
Time Complexity: O(log n), Space Complexity: O(1)
    
#include <vector>
using namespace std;

class Solution {
public:
    int searchInsert(vector<int>& nums, int target) {
        int start = 0, end = (int)nums.size() - 1;
        int ans = (int)nums.size();  // Default insert position is at the end

        while (start <= end) {
            int mid = start + (end - start) / 2;

            if (nums[mid] == target) {
                return mid;
            }

            if (nums[mid] < target) {
                start = mid + 1;
            } else {
                // Update ans if current mid is a better insertion point
                if (ans == (int)nums.size() || nums[mid] < nums[ans]) {
                    ans = mid;
                }
                end = mid - 1;
            }
        }

        return ans;
    }
};

py3:

from typing import List

def search_insert(nums: List[int], target: int) -> int:
    start, end = 0, len(nums) - 1
    ans = len(nums)  # If target is greater than all elements, insert at the end

    while start <= end:
        mid = start + (end - start) // 2

        if nums[mid] == target:
            return mid

        if nums[mid] < target:
            start = mid + 1
        else:
            if ans == len(nums) or nums[mid] < nums[ans]:
                ans = mid
            end = mid - 1

    return ans


if __name__ == "__main__":
    nums = [1, 3, 5, 6]
    target = 5
    result = search_insert(nums, target)
    print(f"Insert position for {target} is {result}")



cpp:

#include <iostream>
#include <vector>
using namespace std;

int SearchInsert(const vector<int>& nums, int target) {
    int start = 0, end = nums.size() - 1;
    int ans = nums.size(); // If target is greater than all elements, insert at the end.

    while (start <= end) {
        int mid = start + (end - start) / 2;

        if (nums[mid] == target)
            return mid;

        if (nums[mid] < target) {
            start = mid + 1;
        } else {
            if (ans == nums.size() || nums[mid] < nums[ans])
                ans = mid;
            end = mid - 1;
        }
    }

    return ans;
}

int main() {
    vector<int> nums = {1, 3, 5, 6};
    int target = 5;

    int result = SearchInsert(nums, target);
    cout << "Insert position for " << target << " is " << result << endl;

    return 0;
}



c#:


using System;

class Program
{
    static int SearchInsert(int[] nums, int target)
    {
        int start = 0, end = nums.Length - 1;
        int ans = nums.Length; // If the target is greater than all elements, it should be inserted at the end.

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] < target)
                start = mid + 1;
            else
            {
                if (ans == nums.Length || nums[mid] < nums[ans])
                    ans = mid;

                end = mid - 1;
            }
        }

        return ans;
    }

    static void Main()
    {
        int[] nums = { 1, 3, 5, 6 };
        int target = 5;

        int result = SearchInsert(nums, target);
        Console.WriteLine($"Insert position for {target} is {result}");
    }
}
