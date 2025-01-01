using System;
using System.Collections.Generic;

public class Solution
{
    // Function to find the sum of weights of the edges of the Minimum Spanning Tree.
    public int SpanningTree(int V, List<List<(int, int)>> adj)
    {
        // Priority queue to store {weight, node}.
        var pq = new SortedSet<(int Weight, int Node)>(Comparer<(int, int)>.Create((x, y) => x.Weight == y.Weight ? x.Node.CompareTo(y.Node) : x.Weight.CompareTo(y.Weight)));
        var visited = new bool[V];

        pq.Add((0, 0)); // Start with the first node with weight 0.
        int sum = 0;

        while (pq.Count > 0)
        {
            var current = pq.Min;
            pq.Remove(current);

            int weight = current.Weight;
            int node = current.Node;

            // If the node is already visited, continue.
            if (visited[node])
                continue;

            // Mark the node as visited and add its weight to the sum.
            visited[node] = true;
            sum += weight;

            // Traverse adjacent nodes.
            foreach (var edge in adj[node])
            {
                int adjNode = edge.Item1;
                int edgeWeight = edge.Item2;

                if (!visited[adjNode])
                {
                    pq.Add((edgeWeight, adjNode));
                }
            }
        }

        return sum;
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
        int sum = solution.SpanningTree(V, adj);

        Console.WriteLine("The sum of all the edge weights: " + sum);
    }
}
