using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0705DesignHashSet
    {
        public class MyHashSet
        {
            private int hashStandard;
            private Bucket[] buckets;
            private int Hash(int key)
            {
                return key % hashStandard;
            }
            public MyHashSet()
            {
                hashStandard = 1009; //單純一個質數 + 10^6上限簡單選出的數
                buckets = new Bucket[hashStandard];
                for(int i = 0; i < buckets.Length; i++)
                {
                    buckets[i] = new Bucket();
                }
            }

            public void Add(int key)
            {
                buckets[this.Hash(key)].Insert(key);
            }

            public void Remove(int key)
            {
                buckets[this.Hash(key)].Delete(key);
            }

            public bool Contains(int key)
            {
                return buckets[this.Hash(key)].Exists(key);
            }
        }
        //leetcode題目用的LinkedList
        public class ListNode
        {
            public int value;
            public ListNode next;
            public ListNode(int value = 0, ListNode next = null) //有給方便使用的預設值
            {
                this.value = value;
                this.next = next;
            }
        }
        public class Bucket
        {            
            private ListNode head;
            public Bucket()
            {
                //ListNode都由虛擬頭部起始，所以有無給值都沒差，防止null和刪光node等細節問題，取值則都由head.next開始
                head = new ListNode();
            }
            public bool Exists(int value)
            {
                ListNode currentNode = this.head.next;

                while (currentNode != null)
                {
                    if (currentNode.value == value)
                    {
                        return true;
                    }
                    currentNode = currentNode.next;
                }
                return false;
            }
            public void Insert(int value)
            {
                if(!this.Exists(value))//確保無重複
                {
                    //insert為插入頭部，讓每次insert都是O(1)
                    ListNode newNode = new ListNode(value, this.head.next);
                    this.head.next = newNode;
                }
            }
            public void Delete(int value)
            {
                ListNode previousNode = this.head;
                ListNode currentNode = this.head.next;
                while (currentNode != null)
                {
                    if(currentNode.value == value)
                    {
                        previousNode.next = currentNode.next;
                        return;
                    }

                    //delete就是簡單的刪除node
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }
            }
        }

        //最簡單的hash map mod(hash 方法) + linked list(處理碰撞)，這個bucket觀念要好好記起來@@
        //參考來源
        //https://maxming0.github.io/2020/08/02/Design-HashSet/
        //其他人的hash map是用不同的hash公式(Bit Manipulation、Multiplicative hashing)和储存方法(array)來處理而已，但linked list處理碰撞真的就蠻簡單的，但就是越簡單越容易碰撞(worst case提升時間複雜度)，但初始成本也低
        //https://leetcode.com/problems/design-hashset/solutions/769047/java-solution-using-bit-manipulation/
        //https://leetcode.com/problems/design-hashset/solutions/768659/python-easy-multiplicative-hash-explained/
    }
}
