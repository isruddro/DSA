using System;
using System.Collections.Generic;

public class Solution
{
    // Helper function to perform DFS and check bipartite condition
    private bool Dfs(int node, int col, int[] color, List<int>[] adj)
    {
        color[node] = col;

        // Traverse adjacent nodes
        foreach (var it in adj[node])
        {
            // If uncolored
            if (color[it] == -1)
            {
                if (!Dfs(it, 1 - col, color, adj)) return false;
            }
            // If already colored and the same color, the graph is not bipartite
            else if (color[it] == col)
            {
                return false;
            }
        }

        return true;
    }

    // Function to check if the graph is bipartite
    public bool IsBipartite(int V, List<int>[] adj)
    {
        int[] color = new int[V];
        for (int i = 0; i < V; i++) color[i] = -1;

        // For connected components
        for (int i = 0; i < V; i++)
        {
            if (color[i] == -1)
            {
                if (!Dfs(i, 0, color, adj))
                    return false;
            }
        }

        return true;
    }
}

public class Program
{
    // Helper function to add an edge
    public static void AddEdge(List<int>[] adj, int u, int v)
    {
        adj[u].Add(v);
        adj[v].Add(u);
    }

    public static void Main()
    {
        // V = 4, E = 4
        int V = 4;
        List<int>[] adj = new List<int>[V];
        for (int i = 0; i < V; i++) adj[i] = new List<int>();

        // Add edges to the graph
        AddEdge(adj, 0, 2);
        AddEdge(adj, 0, 3);
        AddEdge(adj, 2, 3);
        AddEdge(adj, 3, 1);

        Solution obj = new Solution();
        bool ans = obj.IsBipartite(V, adj);

        // Output result
        if (ans)
            Console.WriteLine("1");
        else
            Console.WriteLine("0");
    }
}
