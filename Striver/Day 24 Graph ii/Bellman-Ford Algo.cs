using System;
using System.Collections.Generic;

public class Solution
{
    public List<int> BellmanFord(int V, List<List<int>> edges, int S)
    {
        // Initialize distances with a high value (infinity)
        List<int> dist = new List<int>(new int[V]);
        for (int i = 0; i < V; i++) dist[i] = int.MaxValue;
        dist[S] = 0;

        // Relax all edges V-1 times
        for (int i = 0; i < V - 1; i++)
        {
            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                int wt = edge[2];
                if (dist[u] != int.MaxValue && dist[u] + wt < dist[v])
                {
                    dist[v] = dist[u] + wt;
                }
            }
        }

        // Check for negative-weight cycles
        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];
            int wt = edge[2];
            if (dist[u] != int.MaxValue && dist[u] + wt < dist[v])
            {
                return new List<int> { -1 };
            }
        }

        return dist;
    }
}

public class Program
{
    public static void Main()
    {
        int V = 6;
        List<List<int>> edges = new List<List<int>>
        {
            new List<int> { 3, 2, 6 },
            new List<int> { 5, 3, 1 },
            new List<int> { 0, 1, 5 },
            new List<int> { 1, 5, -3 },
            new List<int> { 1, 2, -2 },
            new List<int> { 3, 4, -2 },
            new List<int> { 2, 4, 3 }
        };

        int S = 0;
        Solution obj = new Solution();
        List<int> dist = obj.BellmanFord(V, edges, S);

        foreach (var d in dist)
        {
            Console.Write(d + " ");
        }
        Console.WriteLine();
    }
}
