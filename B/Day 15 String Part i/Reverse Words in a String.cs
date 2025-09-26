Solution 1(Brute Force)


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string s = "TUF is great for interview preparation";
        Console.WriteLine("Before reversing words:");
        Console.WriteLine(s);

        s += " "; // Adding a space to handle the last word
        Stack<string> st = new Stack<string>();
        string str = "";

        // Iterate through the string and split words using a stack
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ')
            {
                st.Push(str);
                str = "";
            }
            else
            {
                str += s[i];
            }
        }

        // Reverse the words using the stack
        string ans = "";
        while (st.Count > 1) // Keep adding words until only the last one remains
        {
            ans += st.Pop() + " ";
        }

        // Add the last word (without a space after it)
        ans += st.Pop();

        Console.WriteLine("After reversing words:");
        Console.WriteLine(ans);
    }
}



Solution 2(Optimized Solution)


using System;

class Program
{
    static string Result(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        string temp = "";
        string ans = "";

        // Iterate the string and keep adding characters to form a word
        // If an empty space is encountered, then add the current word to the result
        while (left <= right)
        {
            char ch = s[left];
            if (ch != ' ')
            {
                temp += ch;
            }
            else if (ch == ' ')
            {
                if (ans != "")
                    ans = temp + " " + ans;
                else
                    ans = temp;

                temp = "";
            }
            left++;
        }

        // If not an empty string, add the last word to the result
        if (temp != "")
        {
            if (ans != "")
                ans = temp + " " + ans;
            else
                ans = temp;
        }

        return ans;
    }

    static void Main()
    {
        string st = "TUF is great for interview preparation";
        Console.WriteLine("Before reversing words:");
        Console.WriteLine(st);
        Console.WriteLine("After reversing words:");
        Console.WriteLine(Result(st));
    }
}
