using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1404NumberofStepstoReduceaNumberinBinaryRepresentationtoOne
    {
        public int NumSteps(string s)
        {
            //Time complexity:O(n) => 理論上最高位進位不會到很多次，所以應該還在O(n)範疇
            //Space complexity:O(n)
            //這題模式其實很固定
            //1. even時/2 => 只是right shift很簡單
            //2. odd時+1  => 難點在於會進位，甚至可能連續
            //3. 只剩1時結束 => 要檢查
            //因為是字串所以由右向左進位比較麻煩
            int step = 0;
            LinkedList<char> chars = new LinkedList<char>(s.ToCharArray()); // 用linked list單純是addfirst 是 O(1)
                                                                            // => 後來想想除了char判斷，用個window管理1(下次是否進位)+31個bit好像也可以不過可能要做mask管理進位的那位數
            while (chars.Count > 1)
            {

                if (chars.Last() == '0') //even
                {
                    step++;
                }
                else//odd
                {
                    LinkedListNode<char> current = chars.Last;

                    while (current != null)
                    {
                        if (current.Value == '0')//不用再進位就能不用檢查previous了
                        {
                            current.Value = '1';//調整到對應進位的位數
                            break;
                        }
                        else
                        {
                            current.Value = '0';
                        }

                        current = current.Previous;
                    }

                    if (current == null)//如果進位到最高位了就要addfirst
                    {
                        chars.AddFirst('1');
                    }

                    step += 2;//進位+shift共兩步
                }
                chars.RemoveLast(); //不論是even或odd都一次走到shift (因為odd進位完就變even了)
            }
            return step;
        }

        //https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/solutions/564287/cjava-on-by-votrubac-35b2/
        //這個人方法跟我一樣，不過精準超多耶，要記住 => 相比我的這個只有一次 O(N)，空間也只有O(1)
        //1.even確實只是單純step++
        //2.odd可以用carry處理，不用一次算完所有進位@@(這要記住!!!)，然後要多一次step++ => 要記住這種盡位carry的處理，以後應該是會遇到
        //3.最後res + carry，因為最後如果最高位是10，還要多shift一次
        //https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/solutions/7609368/draft-by-la_castille-0en8/
        //這位方法一樣(法1法2都一樣)
        //只是法2比較多隱含有點難懂
        //1.(bit ^ carry) => XOR， 0 & 0 和 1 & 1 會讓末位數是even所以step +1 ， 1 & 0 和 0 & 1 會讓末位數是odd所以step +1
        //2.carry |= bit => 隱含因為1 & 0時會多做odd動作，所以最終還是會進位

        //上面兩位應該就是標準解了
    }
}
