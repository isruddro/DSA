public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode() { }

    public TreeNode(int val)
    {
        this.val = val;
    }

    public TreeNode(int val, TreeNode left, TreeNode right)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return CreateBST(nums, 0, nums.Length - 1);
    }

    private TreeNode CreateBST(int[] nums, int l, int r)
    {
        if (l > r) // Base condition or recursion stopping condition
        {
            return null;
        }

        // Finding the middle index to create a balanced tree
        int mid = l + (r - l) / 2; // This is the formula to find the middle value
        TreeNode root = new TreeNode(nums[mid]); // Create the root with the middle value
        root.left = CreateBST(nums, l, mid - 1); // Create the left subtree
        root.right = CreateBST(nums, mid + 1, r); // Create the right subtree

        return root;
    }
}
