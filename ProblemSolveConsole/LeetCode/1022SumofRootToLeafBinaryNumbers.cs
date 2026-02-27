using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.LeetCode
{
    public class _1022SumofRootToLeafBinaryNumbers
    {
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
#if false //舊方法，這是以前還不熟bit時的做法，就自己做轉換器和用靜態加總，其實蠻粗糙好懂得，就是過程可能比較耗時間，複雜度其實一樣
        public double result = 0;
        public int SumRootToLeaf(TreeNode root)
        {
            Recursive(root, "");
            return (int)result;
        }

        public void Recursive(TreeNode node, string bit)
        {
            if (node == null)
                return;
            bit += node.val.ToString();
            if (node.left == null && node.right == null)
            {
                for (int i = 0; i < bit.Length; i++)
                {
                    if (bit[i] == '1')
                        result += Math.Pow(2, (bit.Length - 1 - i));
                }
                return;
            }
            else
            {
                Recursive(node.left, bit);
                Recursive(node.right, bit);
            }
            return;
        }
#endif
        public int SumRootToLeaf(TreeNode root)
        {
            //time:O(n)
            //space:O(n) => function stack
            return Recursive(root, 0);
        }

        public int Recursive(TreeNode node, int cur)
        {
            if (node == null) return 0;//會遇到單邊沒有child的node，可以用0模擬不存在的child

            cur <<= 1;//DFS到leaf並計算沿途得leaf傳下去
            cur |= node.val;

            if (node.left == null && node.right == null) //leaf 是兩邊都沒有child的node
            {
                return cur;
            }

            return Recursive(node.left, cur) + Recursive(node.right, cur);//答案是DFS到末端的加總
        }

        //https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/solutions/270025/javacpython-recursive-solution-by-lee215-fcw2/
        //這位解法其實跟我一樣，只是把bit操作隱藏在*2中
        //1.root.left == root.right => 單純簡短 root.left == null && root.right == null，因為是記憶體所以有值就不會相等
        //2.val = val * 2 + root.val; => val * 2就是把傳入的值做left shift => 其實也蠻值得記住的，算是第二種表現bit的方法
        //https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/solutions/1681682/well-detailed-explaination-java-c-python-mqkc/
        //這位方法跟第一位一樣
        //https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/solutions/270600/java-simple-dfs-by-gcarrillo-w0yz/
        //這位方法則跟我一樣用left shift
        //看來標準解法確定有兩種表現方式 1. *2 2. left shift

    }
}
