Naive Approach (Brute-force): 


using System;

public class Solution {

    // Method to count pairs where a[i] > 2 * a[j]
    public static int CountPairs(int[] a, int n) {
        // Count the number of pairs:
        int cnt = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (a[i] > 2 * a[j]) {
                    cnt++;
                }
            }
        }
        return cnt;
    }

    // Wrapper method for team logic
    public static int Team(int[] skill, int n) {
        return CountPairs(skill, n);
    }

    public static void Main(string[] args) {
        int[] a = {4, 1, 2, 3, 1};
        int n = 5;
        int cnt = Team(a, n);
        Console.WriteLine("The number of reverse pairs is: " + cnt);
    }
}



Optimal Approach: 


using System;
using System.Collections.Generic;

public class Solution {

    // Merge function to merge the left and right halves of the array
    private static void Merge(int[] arr, int low, int mid, int high) {
        List<int> temp = new List<int>(); // Temporary array to store merged elements
        int left = low; // Starting index of left half
        int right = mid + 1; // Starting index of right half

        // Merging elements in a sorted manner
        while (left <= mid && right <= high) {
            if (arr[left] <= arr[right]) {
                temp.Add(arr[left]);
                left++;
            } else {
                temp.Add(arr[right]);
                right++;
            }
        }

        // If there are remaining elements in the left half
        while (left <= mid) {
            temp.Add(arr[left]);
            left++;
        }

        // If there are remaining elements in the right half
        while (right <= high) {
            temp.Add(arr[right]);
            right++;
        }

        // Copying elements from temporary array back to the original array
        for (int i = low; i <= high; i++) {
            arr[i] = temp[i - low];
        }
    }

    // Count pairs where arr[i] > 2 * arr[j]
    public static int CountPairs(int[] arr, int low, int mid, int high) {
        int right = mid + 1;
        int cnt = 0;

        // Iterate over the left half and find the reverse pairs
        for (int i = low; i <= mid; i++) {
            while (right <= high && arr[i] > 2 * arr[right]) {
                right++;
            }
            cnt += (right - (mid + 1));
        }
        return cnt;
    }

    // Merge sort function that counts reverse pairs during the merge process
    public static int MergeSort(int[] arr, int low, int high) {
        int cnt = 0;
        if (low >= high) return cnt;

        int mid = (low + high) / 2;

        // Recursively sort the left and right halves and count reverse pairs
        cnt += MergeSort(arr, low, mid); // Left half
        cnt += MergeSort(arr, mid + 1, high); // Right half
        cnt += CountPairs(arr, low, mid, high); // Count reverse pairs during merge
        Merge(arr, low, mid, high); // Merge the sorted halves
        return cnt;
    }

    // Wrapper method for the team logic
    public static int Team(int[] skill, int n) {
        return MergeSort(skill, 0, n - 1);
    }

    // Main method to test the solution
    public static void Main(string[] args) {
        int[] a = {4, 1, 2, 3, 1};
        int n = 5;
        int cnt = Team(a, n);
        Console.WriteLine("The number of reverse pairs is: " + cnt);
    }
}
