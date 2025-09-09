py:

from typing import List

def first_index(a: List[int]) -> int:
    i, j = 0, len(a) - 1

    # Perform binary search to find first 1
    while i < j:
        m = i + (j - i) // 2
        if a[m] == 1:
            j = m  # Search left half
        else:
            i = m + 1  # Search right half

    # If no 1's in the array
    if a[i] == 0:
        return -1

    return i  # Index of first 1


if __name__ == "__main__":
    a = [0, 0, 0, 1, 1, 1, 1]
    result = first_index(a)
    if result != -1:
        print(f"First index of 1 is: {result}")
    else:
        print("No 1's found in the array")


cpp:

#include <iostream>
#include <vector>
using namespace std;

// Function to find the first index of 1 in a binary array
int FirstIndex(const vector<int>& a) {
    int i = 0, j = a.size() - 1;

    // Perform binary search to find first 1
    while (i < j) {
        int m = i + (j - i) / 2;
        if (a[m] == 1)
            j = m;      // Search left half
        else
            i = m + 1;  // Search right half
    }

    // If no 1's in the array
    if (a[i] == 0) return -1;

    return i;  // Index of first 1
}

int main() {
    vector<int> a = {0, 0, 0, 1, 1, 1, 1};

    int result = FirstIndex(a);
    if (result != -1)
        cout << "First index of 1 is: " << result << endl;
    else
        cout << "No 1's found in the array" << endl;

    return 0;
}





c#:

using System;

class Program
{
    // Function to find the first index of 1 in a binary array
    static int FirstIndex(int[] a, int n)
    {
        int i = 0, j = n - 1;

        // Perform binary search to find the first index of 1
        while (i < j)
        {
            int m = i + (j - i) / 2;
            if (a[m] == 1) j = m;  // If the middle element is 1, search in the left half
            else i = m + 1;  // Otherwise, search in the right half
        }

        // If a[i] is 0, return -1 indicating no 1's in the array
        if (a[i] == 0) return -1;

        return i;  // Return the index of the first 1
    }

    static void Main()
    {
        // Example array (binary)
        int[] a = { 0, 0, 0, 1, 1, 1, 1 };

        // Find the first index of 1
        int result = FirstIndex(a, a.Length);

        if (result != -1)
            Console.WriteLine($"First index of 1 is: {result}");
        else
            Console.WriteLine("No 1's found in the array");
    }
}
