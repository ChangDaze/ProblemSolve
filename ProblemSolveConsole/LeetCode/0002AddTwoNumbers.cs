using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0002AddTwoNumbers
    {
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //test case 長度會不同
            //是將linklist代表每位數，且位數是reverse的
            //相加後return 也是reverse位數的
            //0+0也要有node return
            //題目會測超過int, bigint > 因為會有更長的，所以可能要改用carry (每個位數自己算進位)
            //如果只剩carry要要產出node
            //要看一下怎麼加強效率...

            ListNode temp1 = l1;
            ListNode temp2 = l2;

            return ConvertToListNode(
                        FindNumber(l1), FindNumber(l2)
                    );


            string FindNumber(ListNode input)
            {
                StringBuilder sb = new StringBuilder();
                while(input != null)
                {
                    sb.Append(input.val);
                    input = input.next;
                }
                return new string(sb.ToString().Reverse().ToArray());
            }

            ListNode ConvertToListNode(string input1, string input2)
            {
                ListNode result = new ListNode();
                ListNode pointer = result;
                var lst1 = input1.ToList();
                var lst2 = input2.ToList();
                int carry = 0;
                while (lst1.Count > 0 || lst2.Count > 0 || carry != 0) ////如果只剩carry要要產出node
                {
                    int val = carry; //加上進位
                    carry = 0;                    

                    if (lst1.Count > 0) //可以考慮改用foreach
                    {
                        val += (lst1.Last() - '0');
                        lst1.RemoveAt(lst1.Count-1);
                    }

                    if (lst2.Count > 0)
                    {
                        val += (lst2.Last() - '0');
                        lst2.RemoveAt(lst2.Count - 1);
                    }

                    carry = val / 10; //先進位
                    val = val % 10; //取餘數          

                    pointer.next = new ListNode(val); //強制轉型
                    pointer= pointer.next;
                }


                return result.next; 
            }
        }
    }
}
