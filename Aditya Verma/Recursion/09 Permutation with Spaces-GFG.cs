py:

def solve(ip: str, op: str):
    # Base case: if input is empty, print current output
    if not ip:
        print(op)
        return

    # Option 1: add an underscore before the next character
    op1 = op + "_" + ip[0]

    # Option 2: add the character directly
    op2 = op + ip[0]

    # Remove the first character from input
    ip_rest = ip[1:]

    # Recursive calls
    solve(ip_rest, op1)
    solve(ip_rest, op2)


if __name__ == "__main__":
    input_str = "ABC"  # Example input

    # Initialize output with the first character
    output = input_str[0]
    input_str = input_str[1:]

    # Start recursion
    solve(input_str, output)





cpp:
#include <bits/stdc++.h>
using namespace std;

void Solve(string ip, string op) {
    // Base case: if input is empty, print the current output
    if (ip.empty()) {
        cout << op << endl;
        return;
    }

    // Option 1: add an underscore before the next character
    string op1 = op + "_" + ip[0];

    // Option 2: add the character directly
    string op2 = op + ip[0];

    // Remove the first character from input
    ip = ip.substr(1);

    // Recursive calls
    Solve(ip, op1);
    Solve(ip, op2);
}

int main() {
    string input = "ABC"; // Example input
    string output = "";

    // Initialize output with the first character
    output += input[0];
    input = input.substr(1);

    // Start recursion
    Solve(input, output);

    return 0;
}


c#:
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
