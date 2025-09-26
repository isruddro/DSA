using System;
using System.Collections.Generic;

public class Solution {
    // Helper function to perform DFS and find the topological sort
    private void FindTopoSort(int node, bool[] vis, Stack<int> st, List<int>[] adj) {
        vis[node] = true;

        // Visit all the adjacent nodes of the current node
        foreach (int neighbor in adj[node]) {
            if (!vis[neighbor]) {
                FindTopoSort(neighbor, vis, st, adj);
            }
        }
        // Push the node to stack after all adjacent nodes are processed
        st.Push(node);
    }

    // Function to return the topological sort of the graph
    public List<int> TopoSort(int N, List<int>[] adj) {
        Stack<int> st = new Stack<int>();
        bool[] vis = new bool[N];
        List<int> topo = new List<int>();

        // Perform DFS on all nodes to find the topological order
        for (int i = 0; i < N; i++) {
            if (!vis[i]) {
                FindTopoSort(i, vis, st, adj);
            }
        }

        // Transfer nodes from the stack to the result list (topological order)
        while (st.Count > 0) {
            topo.Add(st.Pop());
        }

        return topo;
    }
}

public class Program {
    public static void Main() {
        // Number of vertices in the graph
        int N = 6;

        // Adjacency list for the directed graph
        List<int>[] adj = new List<int>[N];
        for (int i = 0; i < N; i++) {
            adj[i] = new List<int>();
        }

        // Add edges to the graph
        adj[5].Add(2);
        adj[5].Add(0);
        adj[4].Add(0);
        adj[4].Add(1);
        adj[2].Add(3);
        adj[3].Add(1);

        // Create an object of the Solution class and perform topological sort
        Solution obj = new Solution();
        List<int> topoOrder = obj.TopoSort(N, adj);

        // Print the topological order
        Console.WriteLine("Toposort of the given graph is:");
        foreach (int node in topoOrder) {
            Console.Write(node + " ");
        }
    }
}
