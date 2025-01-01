public class Solution {
    public bool IsBipartite(int[][] graph) {
        //let's have two set of nodes, left and right
        HashSet<int> left = new HashSet<int>();
        HashSet<int> right = new HashSet<int>();

        //to check if node is already visited or not.
        HashSet<int> visited = new HashSet<int>();

        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited.Contains(i))
            {
                visited.Add(i);
                left.Add(i);
                if (!DFS(i, graph, visited, left, right))
                    return false;
            }
        }

        return true;
    }

    private bool DFS(int node, int[][] graph, HashSet<int> visited, HashSet<int> h1, HashSet<int> h2)
    {
        for (int i = 0; i < graph[node].Length; i++)
        {
            //check if the next node is already present in same set as current node
            //return if present in same set
            if (h1.Contains(graph[node][i]))
                return false;

            if (!visited.Contains(graph[node][i]))
            {
                visited.Add(graph[node][i]);
                h2.Add(graph[node][i]);
                //reversing h1 and h2 params here...
                bool result = DFS(graph[node][i], graph, visited, h2, h1);
                if (!result)
                    return result;
            }
        }

        return true;
    }
}