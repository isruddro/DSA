using System;
using System.Collections.Generic;

public class Solution {
    // Function to detect cycle in a directed graph
    public bool IsCyclic(int V, List<int>[] adj) {
        int[] indegree = new int[V];  // To store indegree of each node
        
        // Compute indegree for each node
        for (int i = 0; i < V; i++) {
            foreach (int neighbor in adj[i]) {
                indegree[neighbor]++;
            }
        }

        // Use a queue to process nodes with indegree 0
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < V; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }

        // Process the nodes
        int count = 0;
        while (q.Count > 0) {
            int node = q.Dequeue();
            count++;

            // Decrease the indegree of adjacent nodes and add them to queue if indegree becomes 0
            foreach (int neighbor in adj[node]) {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0) {
                    q.Enqueue(neighbor);
                }
            }
        }

        // If count is not equal to the number of vertices, there is a cycle
        return count != V;
    }
}

public class Program {
    // Function to add an edge to the directed graph
    public static void AddEdge(List<int>[] adj, int u, int v) {
        adj[u].Add(v);
    }

    public static void Main() {
        int V = 4;  // Number of vertices
        List<int>[] adj = new List<int>[V];

        // Initialize adjacency list
        for (int i = 0; i < V; i++) {
            adj[i] = new List<int>();
        }

        // Add edges to the directed graph
        AddEdge(adj, 0, 1);
        AddEdge(adj, 1, 2);
        AddEdge(adj, 2, 3);
        // Uncomment the following line to introduce a cycle
        // AddEdge(adj, 3, 1); // Adds a cycle

        // Create an object of the Solution class and check for cycle
        Solution obj = new Solution();
        bool ans = obj.IsCyclic(V, adj);

        // Print the result
        if (ans) {
            Console.WriteLine("Cycle detected");
        } else {
            Console.WriteLine("No cycle detected");
        }
    }
}
