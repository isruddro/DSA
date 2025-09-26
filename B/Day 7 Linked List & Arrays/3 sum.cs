BF:

using System;
using System.Collections.Generic;

class Program
{
    public static List<List<int>> Triplet(int n, List<int> arr)
    {
        HashSet<List<int>> st = new HashSet<List<int>>(new ListComparer());

        // Check all possible triplets:
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (arr[i] + arr[j] + arr[k] == 0)
                    {
                        List<int> temp = new List<int> { arr[i], arr[j], arr[k] };
                        temp.Sort(); // Sort the triplet
                        st.Add(temp); // Insert the sorted triplet into the set
                    }
                }
            }
        }

        // Convert HashSet to List
        List<List<int>> ans = new List<List<int>>(st);
        return ans;
    }

    // Custom comparer for List<int> to handle equality in HashSet
    public class ListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x == null || y == null) return false;
            return x.Count == y.Count && !x.Except(y).Any();
        }

        public int GetHashCode(List<int> obj)
        {
            return obj == null ? 0 : obj.Aggregate(17, (hash, value) => hash * 31 + value);
        }
    }

    static void Main(string[] args)
    {
        List<int> arr = new List<int> { -1, 0, 1, 2, -1, -4 };
        int n = arr.Count;
        List<List<int>> ans = Triplet(n, arr);

        foreach (var triplet in ans)
        {
            Console.Write("[");
            foreach (var num in triplet)
            {
                Console.Write(num + " ");
            }
            Console.Write("] ");
        }
        Console.WriteLine();
    }
}



Better:


using System;
using System.Collections.Generic;

class Program
{
    public static List<List<int>> Triplet(int n, List<int> arr)
    {
        HashSet<List<int>> st = new HashSet<List<int>>(new ListComparer());

        // Iterate through each pair of elements
        for (int i = 0; i < n; i++)
        {
            HashSet<int> hashset = new HashSet<int>();

            for (int j = i + 1; j < n; j++)
            {
                // Calculate the 3rd element
                int third = -(arr[i] + arr[j]);

                // Check if the 3rd element is present in the hashset
                if (hashset.Contains(third))
                {
                    List<int> temp = new List<int> { arr[i], arr[j], third };
                    temp.Sort(); // Sort the triplet to ensure uniqueness
                    st.Add(temp); // Add the sorted triplet to the set
                }

                hashset.Add(arr[j]); // Add current element to the hashset
            }
        }

        // Convert HashSet to List
        List<List<int>> ans = new List<List<int>>(st);
        return ans;
    }

    // Custom comparer for List<int> to handle equality in HashSet
    public class ListComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            if (x == null || y == null) return false;
            return x.Count == y.Count && !x.Except(y).Any();
        }

        public int GetHashCode(List<int> obj)
        {
            return obj == null ? 0 : obj.Aggregate(17, (hash, value) => hash * 31 + value);
        }
    }

    static void Main(string[] args)
    {
        List<int> arr = new List<int> { -1, 0, 1, 2, -1, -4 };
        int n = arr.Count;
        List<List<int>> ans = Triplet(n, arr);

        foreach (var triplet in ans)
        {
            Console.Write("[");
            foreach (var num in triplet)
            {
                Console.Write(num + " ");
            }
            Console.Write("] ");
        }
        Console.WriteLine();
    }
}




Optimal:


using System;
using System.Collections.Generic;

class Program
{
    public static List<List<int>> Triplet(int n, List<int> arr)
    {
        List<List<int>> ans = new List<List<int>>();
        arr.Sort(); // Sort the array first

        for (int i = 0; i < n; i++)
        {
            // Skip duplicates
            if (i != 0 && arr[i] == arr[i - 1]) continue;

            // Two pointers approach
            int j = i + 1;
            int k = n - 1;

            while (j < k)
            {
                int sum = arr[i] + arr[j] + arr[k];
                if (sum < 0)
                {
                    j++; // Move the left pointer right
                }
                else if (sum > 0)
                {
                    k--; // Move the right pointer left
                }
                else
                {
                    // Found a valid triplet
                    List<int> temp = new List<int> { arr[i], arr[j], arr[k] };
                    ans.Add(temp);
                    j++;
                    k--;

                    // Skip duplicates
                    while (j < k && arr[j] == arr[j - 1]) j++;
                    while (j < k && arr[k] == arr[k + 1]) k--;
                }
            }
        }

        return ans;
    }

    static void Main(string[] args)
    {
        List<int> arr = new List<int> { -1, 0, 1, 2, -1, -4 };
        int n = arr.Count;
        List<List<int>> ans = Triplet(n, arr);

        foreach (var triplet in ans)
        {
            Console.Write("[");
            foreach (var num in triplet)
            {
                Console.Write(num + " ");
            }
            Console.Write("] ");
        }
        Console.WriteLine();
    }
}
