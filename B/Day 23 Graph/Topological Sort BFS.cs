using System;
using System.Collections.Generic;

public class Solution {
    public List<int> TopoSort(int N, List<int>[] adj) {
        // Queue to store nodes with indegree 0
        Queue<int> q = new Queue<int>();
        
        // Array to store the indegree of each node
        int[] indegree = new int[N];
        
        // Calculate indegree for each node
        for (int i = 0; i < N; i++) {
            foreach (int neighbor in adj[i]) {
                indegree[neighbor]++;
            }
        }
        
        // Enqueue all nodes with indegree 0
        for (int i = 0; i < N; i++) {
            if (indegree[i] == 0) {
                q.Enqueue(i);
            }
        }
        
        // List to store the topological order
        List<int> topo = new List<int>();
        
        // Process the nodes
        while (q.Count > 0) {
            int node = q.Dequeue();
            topo.Add(node);
            
            // Decrease the indegree of the adjacent nodes
            foreach (int neighbor in adj[node]) {
                indegree[neighbor]--;
                if (indegree[neighbor] == 0) {
                    q.Enqueue(neighbor);
                }
            }
        }
        
        return topo;
    }
}

public class Program {
    // Function to add an edge to the adjacency list
    public static void AddEdge(List<int>[] adj, int u, int v) {
        adj[u].Add(v);
    }

    public static void Main() {
        int N = 6; // Number of nodes
        List<int>[] adj = new List<int>[N];

        // Initialize adjacency list
        for (int i = 0; i < N; i++) {
            adj[i] = new List<int>();
        }

        // Add edges to the graph
        AddEdge(adj, 5, 2);
        AddEdge(adj, 5, 0);
        AddEdge(adj, 4, 0);
        AddEdge(adj, 4, 1);
        AddEdge(adj, 3, 1);
        AddEdge(adj, 2, 3);

        // Create an object of the Solution class and perform topological sort
        Solution obj = new Solution();
        List<int> topoOrder = obj.TopoSort(N, adj);
        
        // Print the topological order
        foreach (int node in topoOrder) {
            Console.Write(node + " ");
        }
    }
}
