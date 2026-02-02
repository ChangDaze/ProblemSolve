using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1700NumberofStudentsUnabletoEatLunch
    {
#if 舊方法，這方法比較像硬用array，內劇性感覺比較差，邏輯分散，所以難懂，但意外的檢核點都蠻清楚的，也算O(n^2)
            public int CountStudents(int[] students, int[] sandwiches)
            {
                int arrayLen = students.Length;
                int position = 0;
                int last = students.Length;                                
                Queue<int> lines = new Queue<int>(students);
                foreach(var sandwich in sandwiches)
                {
                    while(position <= arrayLen)
                    {
                        if(lines.Peek() != sandwich)
                        {
                            lines.Enqueue(lines.Dequeue());
                            position+=1;
                        }
                        else //比對到sandwitch就移動
                        {
                            lines.Dequeue();
                            last -= 1;
                            break;
                        }
                    }

                    if (position > arrayLen) //比完後沒比到代表循環了
                        break;
                    else//下一輪可以重新設定
                    {
                        position= 0;
                        arrayLen = lines.Count;
                    }
                }

                return last;
            }
#endif
        public int CountStudents(int[] students, int[] sandwiches)
        {
            //Time complexity:O(n ^ 2)
            //Space complexity:O(n)

            Queue<int> cur = new Queue<int>();
            Queue<int> next = new Queue<int>(students); //循環用
            int standard = 0;
            int pointer = 0;
            do
            {
                standard = next.Count; //紀錄循環標準
                cur = next;//開始下一輪
                next = new Queue<int>();
                while(cur.Count > 0)
                {
                    int student = cur.Dequeue();
                    if(student == sandwiches[pointer])
                    {
                        pointer++;
                    }
                    else
                    {
                        next.Enqueue(student);
                    }
                }
            }
            while (pointer != sandwiches.Length && standard != next.Count); //如果 pointer == sandwiches.Length (已結束)或 standard == next.Count(重複循環了)就不繼續了

            return next.Count;
        }
        //結果這方法是O(n^2)不知道有沒有更好的

        //https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/solutions/
        //方法依舊是我的方法 = simulate
        //哇...，這個人的方法2才是真解，我對循環的刻板印象導致做成simulate
        //但事實上循環就代表每個人都會輪到，只有sandwitch的順序不會動所以會影響答案，因此只要計算當sandwitch沒人可接(對應student數量歸零了)時就結束，值得學習這個題目理解力!
        //而且這才是O(n)
        //https://leetcode.com/problems/number-of-students-unable-to-eat-lunch/solutions/987403/javacpython-easy-and-concise-by-lee215-z8rn/
        //這位跟第一位一樣
        //大家都是用O(n)方法，所以要切記題目理解，雖然依賴關鍵字解題，但O(n^2)就是不太好
    }
}
