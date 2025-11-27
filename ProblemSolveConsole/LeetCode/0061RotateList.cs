using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProblemSolveConsole.LeetCode
{
    public class _0061RotateList
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            //整段複製出來重做，應該是有點違背LinkedList用法，但因為也是O(n)，所以感覺還行
            //time:O(n)
            //space:O(n)

            if (head == null)
            {
                return head;
            }

            //扁平化Node
            List<int> nodes = new List<int>();
            ListNode headPointer = head;
            while (headPointer != null)
            {
                nodes.Add(headPointer.val);
                headPointer = headPointer.next;
            }                        

            //取餘數做位移
            int shift = k % nodes.Count;

            //跑兩段組成整個Loop
            ListNode result = new ListNode(0);
            ListNode resultPointer = result;

            for (int i = nodes.Count - shift; i < nodes.Count; i++) //不是nodes.Count - 1 - shift 喔，可以自己看規律，應該是因為index 0 的關係所以-1 +1 抵銷
            {
                resultPointer.next = new ListNode(nodes[i]);
                resultPointer = resultPointer.next;
            }

            for (int i = 0; i < nodes.Count - shift; i++)
            {
                resultPointer.next = new ListNode(nodes[i]);
                resultPointer = resultPointer.next;
            }

            return result.next;
        }

        //https://leetcode.com/problems/rotate-list/solutions/22715/share-my-java-solution-with-explanation-kzcd3/?page=3
        //XD，這個人用的兩指標才是真的linkedlist用法
        //1. fast 計算長度
        //2. slow 找到餘數截斷的地方
        //3. 將截斷的地方替換至頭部
        //=> 要記住 linked list 多指標 可以輕易定位要截斷的地方
        //https://leetcode.com/problems/rotate-list/solutions/22827/java-clean-solution-only-one-pointer-use-e3tw/?page=3
        //這個人跟上面的人做法本質一樣，只是把兩指標拆成兩段步驟而已

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

            public override int GetHashCode()
            {
                return HashCode.Combine(val, next?.GetHashCode() ?? 0);
            }
        }
    }
}
