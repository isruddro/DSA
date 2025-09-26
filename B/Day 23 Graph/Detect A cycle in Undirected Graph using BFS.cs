using System;
using System.Collections.Generic;

public class Solution {
    // Function to detect cycle using BFS
    private bool Detect(int src, List<int>[] adj, bool[] vis) {
        // Create a queue to store pairs of <current node, parent node>
        Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
        q.Enqueue(new Tuple<int, int>(src, -1)); // Push source node and parent as -1
        vis[src] = true;

        // Perform BFS traversal
        while (q.Count > 0) {
            var nodePair = q.Dequeue();
            int node = nodePair.Item1;
            int parent = nodePair.Item2;

            // Traverse all adjacent nodes
            foreach (int adjacentNode in adj[node]) {
                // If adjacent node is unvisited, mark it and add to the queue
                if (!vis[adjacentNode]) {
                    vis[adjacentNode] = true;
                    q.Enqueue(new Tuple<int, int>(adjacentNode, node));
                }
                // If adjacent node is visited and it's not the parent node, then there's a cycle
                else if (parent != adjacentNode) {
                    return true;
                }
            }
        }
        return false; // No cycle found
    }

    // Function to check if there is a cycle in the graph
    public bool IsCycle(int V, List<int>[] adj) {
        bool[] vis = new bool[V]; // Visited array initialized to false

        // Traverse all nodes, checking for cycle in each component
        for (int i = 0; i < V; i++) {
            if (!vis[i]) {
                if (Detect(i, adj, vis)) {
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
            Console.WriteLine("1"); // Cycle detected
        } else {
            Console.WriteLine("0"); // No cycle detected
        }
    }
}
