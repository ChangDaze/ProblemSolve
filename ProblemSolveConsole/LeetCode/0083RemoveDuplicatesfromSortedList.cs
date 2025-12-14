using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0083RemoveDuplicatesfromSortedList
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            //Time complexity:O(n)
            //Space complexity:O(1)

            //加頭避免出錯
            ListNode tempHead = new ListNode(0, head);
            ListNode pointer = tempHead.next;

            while(pointer != null && pointer.next != null)
            {
                if(pointer.val == pointer.next.val)
                {
                    pointer.next = pointer.next.next; //pointer不會動嫁接後繼續比
                }
                else
                {
                    pointer = pointer.next;//pointer會動，移到下一個比較
                }
            }

            return tempHead.next;
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

            //要複寫才能用單元測試equal
            public override bool Equals(object obj)
            {
                if (obj is not ListNode other) return false;

                var l1 = this;
                var l2 = other;

                while (l1 != null && l2 != null)
                {
                    if (l1.val != l2.val) return false;
                    l1 = l1.next;
                    l2 = l2.next;
                }
                return l1 == null && l2 == null;
            }
        }
    }

    

    //https://leetcode.com/problems/remove-duplicates-from-sorted-list/solutions/28625/3-line-java-recursive-solution-by-wen587-j8y8/
    //recursive版本，優點是行數會很少
    //https://leetcode.com/problems/remove-duplicates-from-sorted-list/solutions/5810798/video-explain-important-points-by-niits-maxm/
    //很單純所以大家解法都一樣
}
