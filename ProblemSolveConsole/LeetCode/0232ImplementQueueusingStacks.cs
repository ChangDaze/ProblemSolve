using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _0232ImplementQueueusingStacks
    {
#if false //舊方法 我這個舊方法也是很帥XDDD，可以固定O(N)，其實也很令人印象深刻，可以拿來搏眼球，方法也是控制狀態，不過是每次遭做完任兩個stack狀態同步，我就可以同時持有最新的stack和最新的queue，然後stack 的 new 方法在這裡的用法可以記住一下
        public class MyQueue
        {
            private Stack<int> stack1;
            private Stack<int> stack2;

            public MyQueue()
            {
                stack1 = new Stack<int>();
            }

            public void Push(int x)
            {
                stack1.Push(x);
                stack2 = new Stack<int>(stack1);
            }

            public int Pop()
            {
                int answer = stack2.Pop();
                stack1 = new Stack<int>(stack2);
                return answer;
            }

            public int Peek()
            {
                return stack2.Peek();
            }

            public bool Empty()
            {
                return stack1.Count == 0;
            }
        }
#endif



        /*
        時間複雜度 (Time Complexity)
        這裡的分析重點在於 攤銷分析 (Amortized Analysis)，因為不是每次操作的代價都一樣。

        方法,最差情況(Worst Case),攤銷情況(Amortized),原因分析
        Push,O(N),O(1),若前一次是 Pop/Peek，資料全在 output，此時 Push 需將 N 個元素搬回 input。
        Pop,O(N),O(1),若資料全在 input，需搬運 N 個元素到 output 才能取出最底部的元素。
        Peek,O(N),O(1),同 Pop，需要確保資料處於反序狀態。
        Empty,O(1),O(1),僅檢查兩個 Stack 的 Count。

        雖然單次切換可能很慢，但對於 $N$ 次連續操作，每個元素被「搬家」的次數是有限的常數，平均下來每個動作仍趨近於 $O(1)$。

        空間複雜度：$O(N)
        你使用了兩個 Stack 來儲存所有元素。無論資料在哪個 Stack，總量始終是 N。

        目前的問題：頻繁搬家在你的程式碼中，如果交替執行 Push -> Pop -> Push -> Pop，資料會像乒乓球一樣在兩個 Stack 之間來回全量搬運。這會導致在這種特定場景下，攤銷失效，退化成 $O(N)$
        */
        //All the calls to pop and peek are valid. => 不用實作exception
        public class MyQueue
        {
            Stack<int> input = new Stack<int>(); //存放stack 正序
            Stack<int> output = new Stack<int>(); //存放stack 反序 (可用作queue)

            //input 和 output 同時只能存在其一實體
            //push 對應 正序
            //pop/peek 對應 反序
            //當使用對應方法時，要控制實體轉換成正確狀態 => 每個方法開頭實作的if

            public MyQueue()
            {

            }

            public void Push(int x)
            {
                if(!(input.Count >= output.Count))
                {
                    while(output.Count > 0)
                    {
                        input.Push(output.Pop());
                    }
                }

                input.Push(x);
            }

            public int Pop()
            {
                if (!(output.Count > input.Count))
                {
                    while (input.Count > 0)
                    {
                        output.Push(input.Pop());
                    }
                }

                return output.Pop();
            }

            public int Peek()
            {
                if (!(output.Count > input.Count))
                {
                    while (input.Count > 0)
                    {
                        output.Push(input.Pop());
                    }
                }

                return output.Peek();
            }

            public bool Empty()
            {
                return input.Count == 0 && output.Count == 0;
            }
        }

        //https://leetcode.com/problems/implement-queue-using-stacks/solutions/64206/short-o1-amortized-c-java-ruby-by-stefan-ktm3/
        //這個人實作的是best pratice
        //https://leetcode.com/problems/implement-queue-using-stacks/solutions/127533/implement-queue-using-stacks-by-leetcode-9l24/
        //這是官方的
        //(1)也是控制狀態，只是每次動作完畢後會將狀態全都重整理至s1 (對應我的input)，像是我的新方法只控一個stack+舊方法同步最新狀態 融合的解法
        //(2)一樣是best pratice

        //我實作的方法不夠好，只要交替使用不同方法就會讓每個operation變成O(n)，下面有AI實作的bestpratice
        //其中重要的觀念是我把stack當作兩個桶子互相獨立，但AI將stack當作兩個"關聯"的桶子，像queue實作循環一樣串聯起來，這是除了我的解法外要特別記住的特性/解法之一
        //因此真的變成amortized(美個方法攤銷後穩定) O(1)
        //不過要控制狀態這件事大家都有實作，要記住
#if false //ai-best pratice => amortized O(1)
        //最佳實踐(Best Practice) 優化：「非必要不搬家」。
        //Push：永遠只進 input。
        //Pop/Peek：如果 output 是空的，才把 input 的資料一次性倒入 output；如果 output 還有資料，直接用就好。
        public class MyQueue
        {
            Stack<int> input = new Stack<int>(); //存放stack 正序
            Stack<int> output = new Stack<int>(); //存放stack 反序 (可用作queue)

            //input 和 output 同時只能存在其一實體
            //push 對應 正序
            //pop/peek 對應 反序
            //當使用對應方法時，要控制實體轉換成正確狀態 => 每個方法開頭實作的if

            public MyQueue()
            {

            }

            public void Push(int x)
            {
                input.Push(x); // 永遠只管進，不管 output 狀態
            }

            public int Pop()
            {
                Peek(); // 利用 Peek 的邏輯確保 output 有資料
                return output.Pop();
            }

            public int Peek()
            {
                // 只有當 output 沒東西了，才從 input 拿
                // 這樣即使交替 Push/Pop，也不會重複搬運已在 output 的舊資料
                if (output.Count == 0)
                {
                    while (input.Count > 0)
                    {
                        output.Push(input.Pop());
                    }
                }
                return output.Peek();
            }
        }
#endif
    }
}
