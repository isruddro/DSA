https://leetcode.com/problems/find-smallest-letter-greater-than-target/description/

py:

from typing import List

def next_greatest_letter(letters: List[str], target: str) -> str:
    start, end = 0, len(letters) - 1
    ans = 0  # Default to 0, handles wrap-around if no greater letter is found

    while start <= end:
        mid = start + (end - start) // 2

        if letters[mid] <= target:
            start = mid + 1
        else:
            if ans == 0 or letters[mid] < letters[ans]:
                ans = mid
            end = mid - 1

    return letters[ans]


if __name__ == "__main__":
    letters = ['c', 'f', 'j']
    target = 'a'
    result = next_greatest_letter(letters, target)
    print(f"The next greatest letter after {target} is {result}")



cpp:

#include <iostream>
#include <vector>
using namespace std;

char NextGreatestLetter(const vector<char>& letters, char target) {
    int start = 0, end = letters.size() - 1;
    int ans = 0; // Default to 0, handles wrap-around case if no greater letter is found.

    while (start <= end) {
        int mid = start + (end - start) / 2;

        if (letters[mid] <= target) {
            start = mid + 1;
        } else {
            if (ans == 0 || letters[mid] < letters[ans])
                ans = mid;
            end = mid - 1;
        }
    }

    return letters[ans];
}

int main() {
    vector<char> letters = {'c', 'f', 'j'};
    char target = 'a';

    char result = NextGreatestLetter(letters, target);
    cout << "The next greatest letter after " << target << " is " << result << endl;

    return 0;
}



c#:

using System;

class Program
{
    static char NextGreatestLetter(char[] letters, char target)
    {
        int start = 0, end = letters.Length - 1;
        int ans = 0; // Initialize answer to 0, to hold the index of the next greatest letter.

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (letters[mid] <= target)
                start = mid + 1;
            else
            {
                if (ans == 0 || letters[mid] < letters[ans])
                    ans = mid;

                end = mid - 1;
            }
        }

        return letters[ans];
    }

    static void Main()
    {
        char[] letters = { 'c', 'f', 'j' };
        char target = 'a';

        char result = NextGreatestLetter(letters, target);
        Console.WriteLine($"The next greatest letter after {target} is {result}");
    }
}
