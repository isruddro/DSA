public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
        Array.Sort(g);
        Array.Sort(s);
        
        int contentChildren = 0;
        int childIdx = 0;
        int cookieIdx = 0;
        
        while (childIdx < g.Length && cookieIdx < s.Length) {
            if (s[cookieIdx] >= g[childIdx]) {
                contentChildren++;
                childIdx++;
            }
            cookieIdx++;
        }
        
        return contentChildren;
    }
}