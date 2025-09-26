public class Solution {
    public int RepeatedStringMatch(string a, string b) {
        var repeatStr = "";
        var count = 0 ;
        while(repeatStr.Length < b.Length)
        {
            repeatStr += a ;
            count++;
        }

        if(repeatStr.Contains(b))
        {
            return count;
        }else if((repeatStr+a).Contains(b)){
            return count+1;
        }

        return -1;
    }
}