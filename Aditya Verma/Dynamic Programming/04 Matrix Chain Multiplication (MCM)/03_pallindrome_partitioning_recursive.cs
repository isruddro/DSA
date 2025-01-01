using System;

class PalindromePartition
{
    // Function to check if a string is palindrome
    static bool IsPalindrome(string X, int i, int j)
    {
        while (i <= j)
        {
            if (X[i] != X[j])
                return false;
            i++;
            j--;
        }
        return true;
    }

    // Recursive function to solve the problem
    static int Solve(string X, int i, int j)
    {
        // Base case: If the string is already a palindrome or if the length is 1 or less
        if (i >= j || IsPalindrome(X, i, j))
            return 0;

        int ans = int.MaxValue;
        
        // Try partitioning the string at every possible position
        for (int k = i; k <= j - 1; k++)
        {
            int tempAns = Solve(X, i, k) + Solve(X, k + 1, j) + 1;
            ans = Math.Min(ans, tempAns);
        }
        
        return ans;
    }

    static void Main()
    {
        string X = Console.ReadLine();

        // Call the Solve function and print the result
        Console.WriteLine(Solve(X, 0, X.Length - 1));
    }
}
