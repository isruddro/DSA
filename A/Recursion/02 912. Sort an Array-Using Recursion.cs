/*
    This code, we cant think of any decision so we want to solve it using smaller input.
    We will keep reducing one element on hypothesis.

    1. Sort fn:
        sort (2, 5 ,4) = 2, 4, 5
        sort (2, 5) = 2, 5
        sort (2) = 2
    here, hypothesis remove one 
            induction will call the insert fn
    
    2. Insert fn:
        insert([0,1,5], 2)
            hypothesis will remove one
            induction will add that after comparing in the base condition 
 */

cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
private:
    // Insert an element into its correct position in a sorted vector
    void insertInSortedOrder(vector<int>& nums, int t) {
        if (nums.empty() || t >= nums.back()) {
            nums.push_back(t);
            return;
        }

        int last = nums.back();
        nums.pop_back();

        insertInSortedOrder(nums, t);

        nums.push_back(last);
    }

    // Recursively sort the vector
    void getSorted(vector<int>& nums) {
        if (nums.empty())
            return;

        int last = nums.back();
        nums.pop_back();

        getSorted(nums);

        insertInSortedOrder(nums, last);
    }

public:
    vector<int> sortArray(vector<int>& nums) {
        getSorted(nums);
        return nums;
    }
};

int main() {
    vector<int> nums = {2, 5, 4, 1, 3};

    Solution solution;
    vector<int> sorted = solution.sortArray(nums);

    for (int num : sorted) {
        cout << num << " ";
    }
    cout << endl;

    return 0;
}



py3:
from typing import List

class Solution:
    def insert_in_sorted_order(self, nums: List[int], t: int):
        # Base case: insert at end if list empty or t >= last element
        if not nums or t >= nums[-1]:
            nums.append(t)
            return

        # Remove last element
        last = nums.pop()
        # Recursively insert t
        self.insert_in_sorted_order(nums, t)
        # Put back last element
        nums.append(last)

    def get_sorted(self, nums: List[int]):
        if not nums:
            return
        last = nums.pop()
        self.get_sorted(nums)
        self.insert_in_sorted_order(nums, last)

    def sort_array(self, nums: List[int]) -> List[int]:
        self.get_sorted(nums)
        return nums

if __name__ == "__main__":
    nums = [2, 5, 4, 1, 3]
    solution = Solution()
    sorted_nums = solution.sort_array(nums)
    print(sorted_nums)

        



c#:
Answer 1:

public class Solution 
{
    // Function to insert an element into its correct position in the sorted part of the array
    public void InsertInSortedOrder(List<int> nums, int t) 
    {
        // If the list is empty or the element to be inserted is greater than or equal to the last element, add it to the list
        if (nums.Count == 0 || t >= nums[nums.Count - 1]) 
        {
            nums.Add(t);
            return;
        }

        // Remove the last element temporarily
        int to = nums[nums.Count - 1];
        nums.RemoveAt(nums.Count - 1);

        // Recursive call to insert the element
        InsertInSortedOrder(nums, t);

        // Put the removed element back
        nums.Add(to);
    }

    // Function to sort the array recursively
    public void GetSorted(List<int> nums) 
    {
        // Base case: If the list is empty, no need to sort
        if (nums.Count == 0)
            return;

        // Remove the last element
        int t = nums[nums.Count - 1];
        nums.RemoveAt(nums.Count - 1);

        // Recursively sort the remaining elements
        GetSorted(nums);

        // Insert the removed element into the sorted portion
        InsertInSortedOrder(nums, t);
    }

    // Main function to sort the array
    public List<int> SortArray(List<int> nums) 
    {
        // Base case: If the list is empty or has one element, it is already sorted
        if (nums.Count == 0 || nums.Count == 1)
            return nums;

        // Call the GetSorted function to sort the list
        GetSorted(nums);
        return nums;
    }
}









Answer 2:


public class Solution {
    // Function to insert an element into its correct position in the sorted part of the array
    public void Solve(List<int> nums, int t)
    {
        // If the list is empty or the element to be inserted is greater than or equal to the last element, add it to the list
        if (nums.Count == 0 || t >= nums[nums.Count - 1])
        {
            nums.Add(t);
            return;
        }

        // Remove the last element temporarily
        int to = nums[nums.Count - 1];
        nums.RemoveAt(nums.Count - 1);

        // Recursive call to insert the element
        Solve(nums, t);

        // Put the removed element back
        nums.Add(to);
    }

    // Function to sort the array recursively
    public void GetSorted(List<int> nums)
    {
        // Base case: If the list is empty, no need to sort
        if (nums.Count == 0)
            return;

        // Remove the last element
        int t = nums[nums.Count - 1];
        nums.RemoveAt(nums.Count - 1);

        // Recursively sort the remaining elements
        GetSorted(nums);

        // Insert the removed element into the sorted portion
        Solve(nums, t);
    }

    // Main function to sort the array
    public int[] SortArray(int[] nums)
    {
        // Convert the array to a list for easy manipulation
        List<int> numsList = new List<int>(nums);

        // If the list is empty or has one element, it is already sorted
        if (numsList.Count == 0 || numsList.Count == 1)
            return nums;

        // Call the GetSorted function to sort the list
        GetSorted(numsList);

        // Convert the sorted list back to an array and return it
        return numsList.ToArray();
    }
}

