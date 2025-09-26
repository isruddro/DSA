cpp:
O(log n) time and O(1) space.

#include <vector>
using namespace std;

class Solution {
public:
    int search(vector<int>& nums, int target) {
        int start = 0, end = nums.size() - 1;
        int ans = -1;

        while (start <= end) {
            int mid = (start + end) / 2;

            if (nums[mid] == target) {
                return mid;
            }
            else if (nums[mid] > target) {
                end = mid - 1;
            }
            else {
                start = mid + 1;
            }
        }

        return ans;
    }
};

py3:

class Solution:
    def search(self, nums: List[int], target: int) -> int:
        start, end = 0, len(nums) -1
        ans = -1

        while start<=end:
            mid = (start + end) // 2
            if nums[mid] == target:
                return mid
                break
            elif nums[mid] > target:
                end = mid-1
            else:
                start = mid+1
        return ans


cpp:
#include <iostream>
#include <vector>
using namespace std;

int main() {
    vector<int> list = {1,2,3,4,5,6,7,8,9,10};
    int toFind = 10;
    int ans = -1;

    int start = 0, end = list.size() - 1;

    while (start <= end) {
        int mid = (start + end) / 2;
        if (list[mid] == toFind) {
            ans = mid;
            break;
        } else if (list[mid] > toFind) {
            end = mid - 1;
        } else {
            start = mid + 1;
        }
    }

    cout << ans << endl;

    return 0;
}









c#:

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int toFind = 10;
        int ans = -1;

        int start = 0, end = list.Count - 1;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            if (list[mid] == toFind)
            {
                ans = mid;
                break;
            }
            else if (list[mid] > toFind)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        Console.WriteLine(ans);
    }
}
