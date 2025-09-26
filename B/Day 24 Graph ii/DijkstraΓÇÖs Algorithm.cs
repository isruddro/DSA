using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public List<int> ShortestPath(int n, int m, List<List<int>> edges)
    {
        // Create an adjacency list of pairs in the form node1 -> {node2, edge weight}
        List<(int, int)>[] adj = new List<(int, int)>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            adj[i] = new List<(int, int)>();
        }

        foreach (var edge in edges)
        {
            adj[edge[0]].Add((edge[1], edge[2]));
            adj[edge[1]].Add((edge[0], edge[2]));
        }

        // Create a priority queue for storing nodes along with distances in the form {distance, node}
        var pq = new PriorityQueue<(int distance, int node), int>();
        int[] dist = Enumerable.Repeat(int.MaxValue, n + 1).ToArray();
        int[] parent = new int[n + 1];

        // Initialize the parent array to point to itself
        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
        }

        // Distance to the source is 0
        dist[1] = 0;
        pq.Enqueue((0, 1), 0);

        while (pq.Count > 0)
        {
            var (currentDist, currentNode) = pq.Dequeue();

            // Iterate through adjacent nodes
            foreach (var (adjNode, weight) in adj[currentNode])
            {
                if (currentDist + weight < dist[adjNode])
                {
                    dist[adjNode] = currentDist + weight;
                    pq.Enqueue((dist[adjNode], adjNode), dist[adjNode]);

                    // Update the parent of the adjacent node
                    parent[adjNode] = currentNode;
                }
            }
        }

        // If no path is found to the destination, return -1
        if (dist[n] == int.MaxValue)
        {
            return new List<int> { -1 };
        }

        // Build the path from destination to source using the parent array
        var path = new List<int>();
        int current = n;
        while (parent[current] != current)
        {
            path.Add(current);
            current = parent[current];
        }
        path.Add(1);

        // Reverse the path to get the correct order
        path.Reverse();
        return path;
    }
}

public class Program
{
    public static void Main()
    {
        int V = 5, E = 6;
        var edges = new List<List<int>>
        {
            new List<int> { 1, 2, 2 },
            new List<int> { 2, 5, 5 },
            new List<int> { 2, 3, 4 },
            new List<int> { 1, 4, 1 },
            new List<int> { 4, 3, 3 },
            new List<int> { 3, 5, 1 }
        };

        Solution obj = new Solution();
        List<int> path = obj.ShortestPath(V, E, edges);

        Console.WriteLine(string.Join(" ", path));
    }
}
