public class Solution
{
    public int MaxSumBST(TreeNode root)
    {
        var maxSum = 0;
        MaxSumBstDfs(root);
        return maxSum;

        Subtree MaxSumBstDfs(TreeNode node)
        {
            if (node == null)
            {
                return Subtree.Null;
            }

            var left = MaxSumBstDfs(node.left);
            var right = MaxSumBstDfs(node.right);
            var subtree = Subtree.Combine(node, left, right);

            if (subtree.IsBst)
            {
                maxSum = Math.Max(maxSum, subtree.Sum);
            }

            return subtree;
        }
    }

    public class Subtree
    {
        public int Sum { get; init; }
        public int Low { get; init; }
        public int High { get; init; }
        public bool IsBst { get; init; }

        private Subtree() { }

        public static Subtree Combine(
            TreeNode node, Subtree left, Subtree right) => new()
        {
            Sum = left.Sum + right.Sum + node.val,
            Low = Math.Min(node.val, left.Low),
            High = Math.Max(node.val, right.High),
            IsBst = left.IsBst && right.IsBst &&
                left.High < node.val && node.val < right.Low,
        };

        public static Subtree Null { get; } = new()
        {
            Sum = 0,
            Low = int.MaxValue,
            High = int.MinValue,
            IsBst = true,
        };
    }
}