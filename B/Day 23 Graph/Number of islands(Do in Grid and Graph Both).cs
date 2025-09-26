using System;
using System.Collections.Generic;

public class Solution {
    // Helper function to perform DFS and mark the visited cells
    private void Dfs(int row, int col, bool[,] vis, int[,] grid, List<Tuple<int, int>> vec, int row0, int col0) {
        // Mark the cell as visited
        vis[row, col] = true;

        // Store the relative coordinates based on the base coordinates
        vec.Add(new Tuple<int, int>(row - row0, col - col0));

        int n = grid.GetLength(0);
        int m = grid.GetLength(1);

        // Delta row and delta column for moving in the grid
        int[] delrow = {-1, 0, +1, 0};
        int[] delcol = {0, -1, 0, +1};

        // Traverse all 4 possible neighbours (up, down, left, right)
        for (int i = 0; i < 4; i++) {
            int nrow = row + delrow[i];
            int ncol = col + delcol[i];
            // Check for valid unvisited land neighbour
            if (nrow >= 0 && nrow < n && ncol >= 0 && ncol < m &&
                !vis[nrow, ncol] && grid[nrow, ncol] == 1) {
                Dfs(nrow, ncol, vis, grid, vec, row0, col0);
            }
        }
    }

    // Main function to count distinct islands
    public int CountDistinctIslands(int[,] grid) {
        int n = grid.GetLength(0);
        int m = grid.GetLength(1);
        bool[,] vis = new bool[n, m];
        HashSet<List<Tuple<int, int>>> st = new HashSet<List<Tuple<int, int>>>(new ListComparer());

        // Traverse the grid
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                // If not visited and is a land cell
                if (!vis[i, j] && grid[i, j] == 1) {
                    List<Tuple<int, int>> vec = new List<Tuple<int, int>>();
                    Dfs(i, j, vis, grid, vec, i, j);
                    // Store the island shape in the set
                    st.Add(vec);
                }
            }
        }

        return st.Count;
    }
}

// Custom comparer to handle List<Tuple<int, int>> in HashSet
public class ListComparer : IEqualityComparer<List<Tuple<int, int>>> {
    public bool Equals(List<Tuple<int, int>> x, List<Tuple<int, int>> y) {
        if (x.Count != y.Count) return false;
        for (int i = 0; i < x.Count; i++) {
            if (!x[i].Equals(y[i])) return false;
        }
        return true;
    }

    public int GetHashCode(List<Tuple<int, int>> obj) {
        int hash = 17;
        foreach (var item in obj) {
            hash = hash * 31 + item.GetHashCode();
        }
        return hash;
    }
}

public class Program {
    public static void Main() {
        // Example grid
        int[,] grid = {
            {1, 1, 0, 1, 1},
            {1, 0, 0, 0, 0},
            {0, 0, 0, 0, 1},
            {1, 1, 0, 1, 1}
        };

        Solution obj = new Solution();
        Console.WriteLine(obj.CountDistinctIslands(grid)); // Output the number of distinct islands
    }
}
