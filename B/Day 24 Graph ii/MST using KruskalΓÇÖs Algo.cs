using System;
using System.Collections.Generic;

public class DisjointSet
{
    private int[] parent, rank, size;

    public DisjointSet(int n)
    {
        parent = new int[n];
        rank = new int[n];
        size = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
            rank[i] = 0;
            size[i] = 1;
        }
    }

    public int FindParent(int node)
    {
        if (node == parent[node])
            return node;
        return parent[node] = FindParent(parent[node]); // Path compression
    }

    public void UnionByRank(int u, int v)
    {
        int rootU = FindParent(u);
        int rootV = FindParent(v);

        if (rootU == rootV) return;

        if (rank[rootU] < rank[rootV])
        {
            parent[rootU] = rootV;
        }
        else if (rank[rootV] < rank[rootU])
        {
            parent[rootV] = rootU;
        }
        else
        {
            parent[rootV] = rootU;
            rank[rootU]++;
        }
    }

    public void UnionBySize(int u, int v)
    {
        int rootU = FindParent(u);
        int rootV = FindParent(v);

        if (rootU == rootV) return;

        if (size[rootU] < size[rootV])
        {
            parent[rootU] = rootV;
            size[rootV] += size[rootU];
        }
        else
        {
            parent[rootV] = rootU;
            size[rootU] += size[rootV];
        }
    }
}

public class Solution
{
    public int SpanningTree(int V, List<List<(int, int)>> adj)
    {
        var edges = new List<(int Weight, int Node1, int Node2)>();

        // Build the edge list
        for (int i = 0; i < V; i++)
        {
            foreach (var neighbor in adj[i])
            {
                int adjNode = neighbor.Item1;
                int weight = neighbor.Item2;
                if (i < adjNode) // Avoid duplicate edges
                {
                    edges.Add((weight, i, adjNode));
                }
            }
        }

        // Sort edges by weight
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));

        var ds = new DisjointSet(V);
        int mstWeight = 0;

        foreach (var edge in edges)
        {
            int weight = edge.Weight;
            int u = edge.Node1;
            int v = edge.Node2;

            // If u and v are in different sets, include this edge in MST
            if (ds.FindParent(u) != ds.FindParent(v))
            {
                mstWeight += weight;
                ds.UnionBySize(u, v);
            }
        }

        return mstWeight;
    }
}

public class Program
{
    public static void Main()
    {
        int V = 5;
        var edges = new List<(int, int, int)>
        {
            (0, 1, 2),
            (0, 2, 1),
            (1, 2, 1),
            (2, 3, 2),
            (3, 4, 1),
            (4, 2, 2)
        };

        var adj = new List<List<(int, int)>>(V);
        for (int i = 0; i < V; i++)
        {
            adj.Add(new List<(int, int)>());
        }

        foreach (var edge in edges)
        {
            adj[edge.Item1].Add((edge.Item2, edge.Item3));
            adj[edge.Item2].Add((edge.Item1, edge.Item3));
        }

        var solution = new Solution();
        int mstWeight = solution.SpanningTree(V, adj);

        Console.WriteLine("The sum of all the edge weights: " + mstWeight);
    }
}
