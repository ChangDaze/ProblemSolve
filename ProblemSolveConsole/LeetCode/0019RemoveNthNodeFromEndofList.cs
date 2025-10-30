using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0019RemoveNthNodeFromEndofList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
#if false //走到結尾算長度
//time O(n)
//space (O1)
            int length = 0;

            ListNode temp = head;
            do
            {
                length++;
                temp = temp.next;
            }
            while (temp != null);

            ListNode prev = null;
            ListNode current = head;
            for (int i = 0; i < length - n; i++)
            {
                if(prev == null)
                {
                    prev = current;
                    current = current.next;
                }
                else
                {
                    prev.next = current;
                    prev = prev.next;
                    current = current.next;
                }
            }

            if (prev == null)
            {
                return head.next;
            }
            else
            {
                prev.next = current.next;
                return head;
            }
#endif
            //快慢指標
            //https://leetcode.com/problems/remove-nth-node-from-end-of-list/solutions/8804/simple-java-solution-in-one-pass-by-tms-onhr/

            

            //linkedlist好習慣 => 裝頭
            ListNode newHead = new ListNode(-1, head);
            ListNode slow = newHead; //最終(有前一個點的node才有能力移除該node)slow的next是要移除的部分，所以slow會跟fast差n+1步
            ListNode fast = newHead.next; //用來探詢結尾

            //因為題目有說給的n是合理的所以不用過多檢查，直接拉開n步
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }

            while (fast != null)//直到探到結尾
            {
                slow = slow.next;
                fast = fast.next;
            }

            slow.next = slow.next.next; //移除slow next

            return newHead.next; //拔掉裝上的頭
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
