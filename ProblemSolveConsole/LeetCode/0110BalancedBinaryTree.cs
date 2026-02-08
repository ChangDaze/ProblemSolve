using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.LeetCode._0589N_aryTreePreorderTraversal;

namespace ProblemSolveConsole.LeetCode
{
    public class _0110BalancedBinaryTree
    {
#if false //舊方法 ，其實舊方法程式碼比較漂亮耶，理解程度也比較高，概念上和新方法一樣，決定性差距是(1)使用全域bool變數(2)樹的深度倒過來了，其實也是可以@@，有機會記下來可能可以多一些解題手段
            bool stop = false;
            public bool IsBalanced(TreeNode root)
            {
                Recurive(root);
                if(stop) return false;
                return true;
            }

            public int Recurive(TreeNode node)
            {
                if(node == null||stop==true) return 0;
                int leftDepth = Recurive(node.left);
                int rightDepth = Recurive(node.right);
                if(Math.Abs(leftDepth-rightDepth)>1)
                    stop= true;
                return Math.Max(leftDepth, rightDepth)+1;
            }
#endif

#if false //最盛每個node的比較版本了，題目要subtree比較版本
        public bool IsBalanced(TreeNode root)
        {
            if(root == null) return true; //防呆

            Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>(); //使用BFS紀錄每個節點到達的深度
            queue.Enqueue((root, 0));

            int max = 0;
            int ceil = int.MaxValue;//預設值，當有正常值時代表某個子樹沒有再繼續向下生長了

            while (queue.Count > 0)
            {
                (TreeNode, int) temp = queue.Dequeue();
                TreeNode tempNode = temp.Item1;
                int tempDepth = temp.Item2;

                if(tempDepth > max) //更新最深深度
                {
                    max = tempDepth;
                }

                if (max - ceil > 1) //代表目前深度和某個子樹已不平衡了
                {
                    return false;
                }

                if(tempNode.left != null)
                {
                    queue.Enqueue((tempNode.left, tempDepth + 1));
                }

                if (tempNode.right != null)
                {
                    queue.Enqueue((tempNode.right, tempDepth + 1));
                }

                if((tempNode.left == null || tempNode.right == null) && tempDepth < ceil) //某個子樹沒有再繼續向下生長了，紀錄對應深度
                {
                    ceil = tempDepth;
                }
            }

            return true;
        }
#endif

#if false //只能判斷相鄰層有沒有平衡，沒辦法累積結果
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true; //防呆

            Queue<(TreeNode, bool)> queue = new Queue<(TreeNode, bool)>(); 
            queue.Enqueue((root, true));

            while (queue.Count > 0)
            {
                
                (TreeNode, bool) temp = queue.Dequeue();

                bool balance = true;

                TreeNode tempNode = temp.Item1;
                bool parentBalance = temp.Item2;

                if ((!parentBalance) && (tempNode.left != null || tempNode.right != null)) 
                {
                    return false;
                }

                if (tempNode.left == null || tempNode.right == null)
                {
                    balance = false;
                }

                if (tempNode.left != null)
                {
                    queue.Enqueue((tempNode.left, balance));
                }

                if (tempNode.right != null)
                {
                    queue.Enqueue((tempNode.right, balance));
                }
            }

            return true;
        }
#endif
        public bool IsBalanced(TreeNode root)
        {
            //1.子樹深度需要累積，所以需記錄狀態
            //2.需分個看每個子樹是否滿足需求
            //Time complexity:O(N)
            //Space complexity:O(H) > H是深度

            return Recursive(root, 0).Item1;
        }

        //AI有建議如果要做到極致可以把tuple的bool用特殊值取代就能只用int了，跟正負值代表狀態很像
        private (bool, int) Recursive(TreeNode node, int depth)
        {
            if (node == null) return (true, depth); //到null代表深度不會增加了
            (bool, int) left = Recursive(node.left, depth + 1);
            (bool, int) right = Recursive(node.right, depth + 1);

            if(left.Item1 == false || right.Item1 == false) //強制結束
            {
                return (false, 0);
            }

            if(Math.Abs(left.Item2-right.Item2) > 1) //題目條件
            {
                return (false, 0);
            }
            else
            {
                return (true, Math.Max(left.Item2, right.Item2)); //更新parent 的深度
            }
        }

        //https://leetcode.com/problems/balanced-binary-tree/solutions/35691/the-bottom-up-on-solution-would-be-bette-kz5i/
        //這位法一是暴力解，每層都單獨重算深度
        //法二跟AI給的best pratice一樣，用-1當break point，可以多參考
        //https://leetcode.com/problems/balanced-binary-tree/solutions/2428871/very-easy-100-fully-explained-c-java-pyt-v508/
        //這位方法跟上面一位一樣
        //看來這題best pratice就是用特殊sign，大家解法都差不多

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
