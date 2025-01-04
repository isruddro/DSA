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
