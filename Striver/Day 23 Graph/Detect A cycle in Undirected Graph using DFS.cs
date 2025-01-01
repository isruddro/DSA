using System;
using System.Collections.Generic;

public class Solution {
    // Function to detect cycle using DFS
    private bool Dfs(int node, int parent, bool[] vis, List<int>[] adj) {
        // Mark the current node as visited
        vis[node] = true;

        // Traverse all adjacent nodes
        foreach (int adjacentNode in adj[node]) {
            // If the adjacent node is unvisited, call DFS on it
            if (!vis[adjacentNode]) {
                if (Dfs(adjacentNode, node, vis, adj)) {
                    return true; // Cycle detected
                }
            }
            // If the adjacent node is visited and not the parent, it's a cycle
            else if (adjacentNode != parent) {
                return true;
            }
        }

        return false; // No cycle detected
    }

    // Function to check if there is a cycle in the graph
    public bool IsCycle(int V, List<int>[] adj) {
        bool[] vis = new bool[V]; // Visited array initialized to false

        // Traverse all nodes and check for cycle in each component
        for (int i = 0; i < V; i++) {
            if (!vis[i]) {
                if (Dfs(i, -1, vis, adj)) {
                    return true; // Cycle detected
                }
            }
        }
        return false; // No cycle detected
    }
}

public class Program {
    // Function to add an edge to the graph
    public static void AddEdge(List<int>[] adj, int u, int v) {
        adj[u].Add(v);
        adj[v].Add(u);
    }

    public static void Main() {
        int V = 4; // Number of vertices
        List<int>[] adj = new List<int>[V];
        
        // Initialize adjacency list
        for (int i = 0; i < V; i++) {
            adj[i] = new List<int>();
        }

        // Add edges to the graph
        AddEdge(adj, 0, 1);
        AddEdge(adj, 1, 2);
        AddEdge(adj, 2, 3);

        // Create an object of the Solution class and check for cycle
        Solution obj = new Solution();
        bool ans = obj.IsCycle(V, adj);

        // Print the result
        if (ans) {
            Console.WriteLine("Yes"); // Cycle detected
        } else {
            Console.WriteLine("No"); // No cycle detected
        }
    }
}
