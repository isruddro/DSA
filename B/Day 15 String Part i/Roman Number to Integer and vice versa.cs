public class Solution {
    public int RomanToInt(string s) {
        var romanValues = new Dictionary<char, int>{
            {'I',1},
            {'V',5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000}
        };
        int result = 0;
        for(int i=0; i<s.Length; i++){
            int currentValue = romanValues[s[i]];
            if(i<s.Length-1 && romanValues[s[i+1]]>currentValue){
                result -= currentValue;
            }
            else{
                result += currentValue;
            }
        }
        return result;
    }
}