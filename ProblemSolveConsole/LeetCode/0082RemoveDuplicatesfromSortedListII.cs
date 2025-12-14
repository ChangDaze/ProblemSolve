using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0082RemoveDuplicatesfromSortedListII
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            //加頭避免出錯
            ListNode tempHead = new ListNode(0, head);
            ListNode pointer = tempHead.next;
            int cur = -101;//不會出現的數字
            ListNode curBaseNode = tempHead;

            //跑一次把要刪除的都標記起來
            while (pointer != null)
            {
                if(pointer.val != cur)
                {
                    cur = pointer.val;
                    curBaseNode = pointer;                    
                }
                else //pointer.val == cur;
                {
                    curBaseNode.val = -101;
                    pointer.val = -101;
                }
                pointer = pointer.next;
            }
            //跑第二次做刪除
            ListNode previousPointer = tempHead;
            pointer = previousPointer.next;
            while (pointer != null)
            {
                if(pointer.val == -101)
                {
                    while (pointer != null && pointer.val == -101)
                    {
                        pointer = pointer.next;
                    }
                    previousPointer.next = pointer;
                    //pointer因為可能到null所以不先移動
                }
                else
                {
                    //不用刪除就做移動
                    previousPointer= previousPointer.next;
                    pointer = pointer.next;                    
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

        //https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/solutions/28335/my-accepted-java-code-by-snowfish-zi64/?page=3
        //這個是比較直覺的解法，分析清楚就可以不跑兩次O(n)
        //https://leetcode.com/problems/remove-duplicates-from-sorted-list-ii/solutions/28364/java-simple-and-clean-code-with-comment-a8jef/?page=3
        //其他人也是相同解法
        //我的解法到最後其實跟其他人處理一樣的事(去清除-101時注意的東西和其他人解題步驟其實一樣)，所以我想清楚就應該能做到只跑一次O(n)，下次要多試試
    }


}
