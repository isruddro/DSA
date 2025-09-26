public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null) return null;

        // Dictionary to store cloned nodes.
        Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

        // Start the DFS traversal and clone nodes.
        return DFS(node, visited);
    }

    private Node DFS(Node node, Dictionary<Node, Node> visited)
    {
        // If the node was already cloned, return the clone.
        if (visited.ContainsKey(node))
        {
            return visited[node];
        }

        // Clone the node.
        Node cloneNode = new Node(node.val);
        // Add the clone to the visited dictionary.
        visited[node] = cloneNode;

        // Iterate through the neighbors and clone them.
        foreach (Node neighbor in node.neighbors)
        {
            cloneNode.neighbors.Add(DFS(neighbor, visited));
        }

        return cloneNode;
    }
}
