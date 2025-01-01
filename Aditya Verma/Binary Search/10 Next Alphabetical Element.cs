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
