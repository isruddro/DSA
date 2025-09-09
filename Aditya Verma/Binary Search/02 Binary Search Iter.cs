cpp:
#include <iostream>
#include <vector>
using namespace std;

int main() {
    vector<int> list = {1,2,3,4,5,6,7,8,9,10};
    int toFind = 10;
    int ans = -1;

    int start = 0, end = list.size() - 1;

    while (start <= end) {
        int mid = (start + end) / 2;
        if (list[mid] == toFind) {
            ans = mid;
            break;
        } else if (list[mid] > toFind) {
            end = mid - 1;
        } else {
            start = mid + 1;
        }
    }

    cout << ans << endl;

    return 0;
}









c#:

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int toFind = 10;
        int ans = -1;

        int start = 0, end = list.Count - 1;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            if (list[mid] == toFind)
            {
                ans = mid;
                break;
            }
            else if (list[mid] > toFind)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        Console.WriteLine(ans);
    }
}
