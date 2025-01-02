using System;

class Program
{
    static void Solve(string ip, string op)
    {
        // Base case: if the input is empty, print the output and return
        if (ip.Length == 0)
        {
            Console.WriteLine(op);
            return;
        }

        // Generate two options for recursion:
        // Option 1: Add an underscore (space) before the next character
        string op1 = op + "_" + ip[0];

        // Option 2: Add the character directly (without space)
        string op2 = op + ip[0];

        // Remove the processed character from the input
        ip = ip.Substring(1);

        // Recursive calls for the two options
        Solve(ip, op1);
        Solve(ip, op2);
    }

    static void Main(string[] args)
    {
        string input = "ABC"; // Example input
        string output = "";

        // Initialize output with the first character of the input
        output += input[0];
        input = input.Substring(1);

        // Start recursion
        Solve(input, output);
    }
}
