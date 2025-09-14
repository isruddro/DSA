https://www.geeksforgeeks.org/problems/tower-of-hanoi-1587115621/1

py:

class Solution:
    def get_solved(self, N: int, from_rod: int, to_rod: int, aux_rod: int, count: list):
        if N == 0:
            return 0

        count[0] += 1  # Increment move count

        # Move N-1 disks from 'from_rod' to 'aux_rod'
        self.get_solved(N - 1, from_rod, aux_rod, to_rod, count)

        # Print the move for current disk
        print(f"Move disk {N} from rod {from_rod} to rod {to_rod}")

        # Move N-1 disks from 'aux_rod' to 'to_rod'
        self.get_solved(N - 1, aux_rod, to_rod, from_rod, count)

        return count[0]

    def toh(self, N: int, from_rod: int, to_rod: int, aux_rod: int) -> int:
        count = [0]  # Using list to allow pass-by-reference
        self.get_solved(N, from_rod, to_rod, aux_rod, count)
        return count[0]


if __name__ == "__main__":
    N = int(input("Enter number of disks: "))
    solution = Solution()
    moves = solution.toh(N, 1, 3, 2)
    print(f"Total moves: {moves}")


cpp:
#include <bits/stdc++.h>
using namespace std;

class Solution {
public:
    long GetSolved(int N, int fromRod, int toRod, int auxRod, long &count) {
        if (N == 0) return 0;

        count++;  // Increment move count

        // Move N-1 disks from 'fromRod' to 'auxRod'
        GetSolved(N - 1, fromRod, auxRod, toRod, count);

        // Print the move for current disk
        cout << "Move disk " << N << " from rod " << fromRod << " to rod " << toRod << endl;

        // Move N-1 disks from 'auxRod' to 'toRod'
        GetSolved(N - 1, auxRod, toRod, fromRod, count);

        return count;
    }

    long Toh(int N, int fromRod, int toRod, int auxRod) {
        long count = 0;
        GetSolved(N, fromRod, toRod, auxRod, count);
        return count;
    }
};

int main() {
    Solution solution;
    int N;
    cin >> N;  // Number of disks

    long moves = solution.Toh(N, 1, 3, 2);  // 1: from rod, 3: to rod, 2: auxiliary rod
    cout << "Total moves: " << moves << endl;

    return 0;
}



c#:
using System;

public class Solution
{
    public long GetSolved(int N, int fromRod, int toRod, int auxRod, ref long count)
    {
        if (N == 0)
        {
            return 0;
        }

        // Increment the move count before making the move
        count++;

        // Recursive call to move N-1 disks from 'fromRod' to 'auxRod'
        GetSolved(N - 1, fromRod, auxRod, toRod, ref count);

        // Print the move for the current disk
        Console.WriteLine($"Move disk {N} from rod {fromRod} to rod {toRod}");

        // Recursive call to move N-1 disks from 'auxRod' to 'toRod'
        GetSolved(N - 1, auxRod, toRod, fromRod, ref count);

        return count;
    }

    public long Toh(int N, int fromRod, int toRod, int auxRod)
    {
        long count = 0;
        GetSolved(N, fromRod, toRod, auxRod, ref count);
        return count;
    }

    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int N = int.Parse(Console.ReadLine());  // Input the number of disks
        long moves = solution.Toh(N, 1, 3, 2);  // 1: from rod, 3: to rod, 2: auxiliary rod
        Console.WriteLine($"Total moves: {moves}");
    }
}
