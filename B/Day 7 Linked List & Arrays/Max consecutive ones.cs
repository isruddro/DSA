using System;
using System.Collections.Generic;

class Solution {
    public int FindMaxConsecutiveOnes(List<int> nums) {
        int cnt = 0;
        int maxi = 0;
        foreach (int num in nums) {
            if (num == 1) {
                cnt++;
            } else {
                cnt = 0;
            }

            maxi = Math.Max(maxi, cnt);
        }
        return maxi;
    }
}

class Program {
    static void Main() {
        List<int> nums = new List<int> { 1, 1, 0, 1, 1, 1 };
        Solution obj = new Solution();
        int ans = obj.FindMaxConsecutiveOnes(nums);
        Console.WriteLine("The maximum consecutive 1's are " + ans);
    }
}
