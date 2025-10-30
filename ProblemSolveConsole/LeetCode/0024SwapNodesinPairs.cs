using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0024SwapNodesinPairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            //裝頭
            ListNode newHead = new ListNode(0, head);

            ListNode pointer = newHead;

            //都不是null才能換 避免單數node或null.next
            while(pointer.next != null && pointer.next.next != null)
            {
                ListNode secondPointer = pointer.next; //存下第二個pointer避免遺失
                
                pointer.next = pointer.next.next; //第一個pointer做跳躍 (前兩個產生正確順序)
                secondPointer.next = secondPointer.next.next; //第二個pointer做跳躍 (前兩個外產生正確順序)
                pointer.next.next = secondPointer; //(組合 前兩個 和 前兩個外 產生全部正確順序)

                pointer = pointer.next.next; //處理下一組
            }

            return newHead.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
