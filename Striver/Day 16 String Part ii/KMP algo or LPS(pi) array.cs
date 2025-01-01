public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        for (int i = 0; ; i++)  // Loop through haystack
        {
            for (int j = 0; ; j++)  // Loop through needle
            {
                if (j == needle.Length)  // If we have checked all characters of needle, return the starting index
                    return i;

                if (i + j == haystack.Length)  // If we reached the end of haystack without matching needle, return -1
                    return -1;

                if (needle[j] != haystack[i + j])  // If characters don't match, break out of the inner loop
                    break;
            }
        }
    }
}
