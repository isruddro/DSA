using System;
using System.Collections.Generic;

public class Solution {
    // Helper function for DFS traversal
    private void Dfs(int node, List<int>[] adj, bool[] visited, List<int> result) {
        visited[node] = true;
        result.Add(node);
        
        // Traverse all its neighbors
        foreach (int neighbor in adj[node]) {
            if (!visited[neighbor]) {
                Dfs(neighbor, adj, visited, result);
            }
        }
    }

    // Function to return a list containing the DFS traversal of the graph
    public List<int> DfsOfGraph(int V, List<int>[] adj) {
        bool[] visited = new bool[V]; // To track visited nodes
        int start = 0; // Starting node for DFS
        List<int> result = new List<int>(); // List to store the DFS traversal
        Dfs(start, adj, visited, result); // Perform DFS
        return result;
    }
}

public class Program {
    // Function to add an edge to the undirected graph
    public static void AddEdge(List<int>[] adj, int u, int v) {
        adj[u].Add(v);
        adj[v].Add(u);
    }

    // Function to print the result of DFS traversal
    public static void PrintAns(List<int> ans) {
        foreach (int node in ans) {
            Console.Write(node + " ");
        }
    }

    public static void Main() {
        int V = 5;
        List<int>[] adj = new List<int>[V];

        // Initialize adjacency lists
        for (int i = 0; i < V; i++) {
            adj[i] = new List<int>();
        }

        // Add edges
        AddEdge(adj, 0, 2);
        AddEdge(adj, 2, 4);
        AddEdge(adj, 0, 1);
        AddEdge(adj, 0, 3);

        // Create an object of the Solution class and get DFS traversal
        Solution obj = new Solution();
        List<int> ans = obj.DfsOfGraph(V, adj);

        // Print the result
        PrintAns(ans);
    }
}
