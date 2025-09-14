https://www.geeksforgeeks.org/problems/print-n-bit-binary-numbers-having-more-1s-than-0s0252/1

py:
from typing import List

class Solution:
    def get_sorted(self, op: str, ones: int, zeros: int, N: int, result: List[str]):
        if N == 0:
            result.append(op)
            return
        
        # Add '1'
        self.get_sorted(op + '1', ones + 1, zeros, N - 1, result)
        
        # Add '0' only if ones > zeros
        if ones > zeros:
            self.get_sorted(op + '0', ones, zeros + 1, N - 1, result)

    def n_bit_binary(self, N: int) -> List[str]:
        if N <= 0:
            return []
        
        result = []
        self.get_sorted('1', 1, 0, N - 1, result)  # Start with '1'
        return result

if __name__ == "__main__":
    N = int(input("Enter N: "))
    solution = Solution()
    res = solution.n_bit_binary(N)
    print(" ".join(res))



cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
private:
    void GetSorted(string op, int one, int zero, int N, vector<string>& result) {
        if (N == 0) {
            result.push_back(op);
            return;
        }

        // Add '1'
        GetSorted(op + '1', one + 1, zero, N - 1, result);

        // Add '0' only if ones > zeros
        if (one > zero) {
            GetSorted(op + '0', one, zero + 1, N - 1, result);
        }
    }

public:
    vector<string> NBitBinary(int N) {
        vector<string> result;
        if (N <= 0) return result;

        string op = "1";  // Start with '1'
        GetSorted(op, 1, 0, N - 1, result);
        return result;
    }
};

int main() {
    int N;
    cin >> N;

    Solution solution;
    vector<string> result = solution.NBitBinary(N);

    for (auto &s : result) {
        cout << s << " ";
    }
    cout << endl;
    return 0;
}


c#:
using System;
using System.Collections.Generic;

public class Solution
{
    public void GetSorted(string op, int one, int zero, int N, ref List<string> result)
    {
        if (N == 0)
        {
            result.Add(op);
            return;
        }

        string op1 = op;
        op1 += '1';
        GetSorted(op1, one + 1, zero, N - 1, ref result);

        if (one > zero)
        {
            string op2 = op;
            op2 += '0';
            GetSorted(op2, one, zero + 1, N - 1, ref result);
        }

        return;
    }

    public List<string> NBitBinary(int N)
    {
        string op = "1";
        N -= 1;
        List<string> result = new List<string>();
        int one = 1, zero = 0;
        GetSorted(op, one, zero, N, ref result);
        return result;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int N = int.Parse(Console.ReadLine());  // Input the value of N
        List<string> result = solution.NBitBinary(N);

        foreach (string binaryString in result)
        {
            Console.Write(binaryString + " ");
        }
    }
}
