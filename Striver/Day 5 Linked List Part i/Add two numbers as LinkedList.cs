public class ListNode {
    public int Val;
    public ListNode Next;

    public ListNode() { }
    public ListNode(int x) { Val = x; }
    public ListNode(int x, ListNode next) { Val = x; Next = next; }
}

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(); 
        ListNode temp = dummy; 
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0) {
            int sum = 0;

            if (l1 != null) {
                sum += l1.Val; 
                l1 = l1.Next; 
            }

            if (l2 != null) {
                sum += l2.Val; 
                l2 = l2.Next; 
            }

            sum += carry; 
            carry = sum / 10; 
            ListNode node = new ListNode(sum % 10); 
            temp.Next = node; 
            temp = temp.Next; 
        }

        return dummy.Next; 
    }
}
