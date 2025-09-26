Solution 1: Naive Approach 


using System;

class Solution {
    public int CountPlatforms(int n, int[] arr, int[] dep) {
        // Sort both arrival and departure arrays
        Array.Sort(arr);
        Array.Sort(dep);

        int platforms = 1, result = 1;
        int i = 1, j = 0;

        // Traverse both arrival and departure arrays
        while (i < n && j < n) {
            // If next event is arrival, increment platform count
            if (arr[i] <= dep[j]) {
                platforms++;
                i++;
            }
            // If next event is departure, decrement platform count
            else {
                platforms--;
                j++;
            }

            // Update the result with the maximum platforms needed
            result = Math.Max(result, platforms);
        }

        return result;
    }

    static void Main(string[] args) {
        Solution obj = new Solution();
        int[] arr = {900, 945, 955, 1100, 1500, 1800};
        int[] dep = {920, 1200, 1130, 1150, 1900, 2000};
        int n = dep.Length;
        Console.WriteLine("Minimum number of platforms required: " + obj.CountPlatforms(n, arr, dep));
    }
}



Solution 2: Efficient Approach [Sorting]


using System;

class Solution {
    public int CountPlatforms(int n, int[] arr, int[] dep) {
        // Sort both the arrival and departure arrays
        Array.Sort(arr);
        Array.Sort(dep);

        int ans = 1;
        int count = 1;
        int i = 1, j = 0;

        // Traverse both arrival and departure arrays
        while (i < n && j < n) {
            // If next event is arrival, increment the platform count
            if (arr[i] <= dep[j]) {
                count++;
                i++;
            }
            // If next event is departure, decrement the platform count
            else {
                count--;
                j++;
            }

            // Update the result with the maximum platforms needed
            ans = Math.Max(ans, count);
        }

        return ans;
    }

    static void Main(string[] args) {
        Solution obj = new Solution();
        int[] arr = {900, 945, 955, 1100, 1500, 1800}; // Arrival times
        int[] dep = {920, 1200, 1130, 1150, 1900, 2000}; // Departure times
        int n = dep.Length;
        Console.WriteLine("Minimum number of platforms required: " + obj.CountPlatforms(n, arr, dep));
    }
}
