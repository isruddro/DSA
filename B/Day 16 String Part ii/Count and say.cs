public class Solution {
    public string CountAndSay(int n) {
        //base case
        if(n==1) return "1";
        if(n==2) return "11";

        string s = "11";

        for(int i =3; i<=n; i++){
            //taking temp string to store
            string t = "";
            s+='&';
            int c =1;

            for(int j =1; j<s.Length; j++){
                //when j and previous of j is not same
                if(s[j]!=s[j-1]){
                    //we print those
                    t+=c.ToString();
                    t+=s[j-1];
                    c=1;
                }else{
                    //if same we count
                    c++;
                }
            }
            //store in s
            s=t;
        }
        return s;
    }
}