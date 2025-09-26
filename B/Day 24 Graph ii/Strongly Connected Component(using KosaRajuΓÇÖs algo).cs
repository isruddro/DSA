using System;
using System.Collections.Generic;

public class Solution
{
    // Helper function for the first DFS
    private void Dfs(int node, bool[] vis, List<int>[] adj, Stack<int> st)
    {
        vis[node] = true;
        foreach (var neighbor in adj[node])
        {
            if (!vis[neighbor])
            {
                Dfs(neighbor, vis, adj, st);
            }
        }
        st.Push(node);
    }

    // Helper function for the second DFS on the transpose graph
    private void Dfs3(int node, bool[] vis, List<int>[] adjT)
    {
        vis[node] = true;
        foreach (var neighbor in adjT[node])
        {
            if (!vis[neighbor])
            {
                Dfs3(neighbor, vis, adjT);
            }
        }
    }

    // Function to find the number of strongly connected components
    public int Kosaraju(int V, List<int>[] adj)
    {
        bool[] vis = new bool[V];
        Stack<int> st = new Stack<int>();

        // First DFS to fill the stack with nodes in the order of finishing times
        for (int i = 0; i < V; i++)
        {
            if (!vis[i])
            {
                Dfs(i, vis, adj, st);
            }
        }

        // Create the transpose of the graph
        List<int>[] adjT = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            adjT[i] = new List<int>();
        }

        // Fill adjT with the transposed edges
        for (int i = 0; i < V; i++)
        {
            foreach (var neighbor in adj[i])
            {
                adjT[neighbor].Add(i);
            }
        }

        // Second DFS to count SCCs
        Array.Fill(vis, false);
        int sccCount = 0;
        while (st.Count > 0)
        {
            int node = st.Pop();
            if (!vis[node])
            {
                sccCount++;
                Dfs3(node, vis, adjT);
            }
        }

        return sccCount;
    }
}

public class Program
{
    public static void Main()
    {
        int n = 5;
        int[,] edges = {
            { 1, 0 }, { 0, 2 },
            { 2, 1 }, { 0, 3 },
            { 3, 4 }
        };

        // Create adjacency list
        List<int>[] adj = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            adj[i] = new List<int>();
        }

        // Populate adjacency list with edges
        for (int i = 0; i < edges.GetLength(0); i++)
        {
            adj[edges[i, 0]].Add(edges[i, 1]);
        }

        Solution obj = new Solution();
        int result = obj.Kosaraju(n, adj);
        Console.WriteLine("The number of strongly connected components is: " + result);
    }
}
