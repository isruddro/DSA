using System;
using System.Collections.Generic;

public class Solution {
    // Function to return the Breadth First Traversal of the given graph
    public List<int> BfsOfGraph(int V, List<int>[] adj) {
        bool[] visited = new bool[V]; // To track visited nodes
        visited[0] = true; // Mark the starting node as visited
        Queue<int> q = new Queue<int>(); // Queue to store nodes for BFS
        q.Enqueue(0); // Push the starting node into the queue

        List<int> bfs = new List<int>(); // List to store the BFS traversal result
        
        // Iterate until the queue is empty
        while (q.Count > 0) {
            // Get the node at the front of the queue
            int node = q.Dequeue();
            bfs.Add(node); // Add the node to the BFS result

            // Traverse all its neighbors
            foreach (int neighbor in adj[node]) {
                // If the neighbor is not visited, mark it as visited and enqueue it
                if (!visited[neighbor]) {
                    visited[neighbor] = true;
                    q.Enqueue(neighbor);
                }
            }
        }
        return bfs; // Return the BFS traversal result
    }
}

public class Program {
    // Function to add an edge to the undirected graph
    public static void AddEdge(List<int>[] adj, int u, int v) {
        adj[u].Add(v);
        adj[v].Add(u);
    }

    // Function to print the BFS result
    public static void PrintAns(List<int> ans) {
        foreach (int node in ans) {
            Console.Write(node + " ");
        }
    }

    public static void Main() {
        int V = 5; // Number of vertices
        List<int>[] adj = new List<int>[V];
        
        // Initialize adjacency lists
        for (int i = 0; i < V; i++) {
            adj[i] = new List<int>();
        }

        // Add edges to the graph
        AddEdge(adj, 0, 1);
        AddEdge(adj, 1, 2);
        AddEdge(adj, 1, 3);
        AddEdge(adj, 0, 4);

        // Create an object of the Solution class and get BFS traversal
        Solution obj = new Solution();
        List<int> ans = obj.BfsOfGraph(V, adj);

        // Print the result of BFS traversal
        PrintAns(ans);
    }
}
