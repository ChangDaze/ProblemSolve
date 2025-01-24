using ProblemSolveConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsole.AdventofCode
{
    public class _2024D09 : ISolution
    {
        public void Execute()
        {
            using (StreamReader sr = new StreamReader("C:/Repo/C#/ProblemSolve/ProblemSolveConsole/AdventofCode/Input/2024D09.txt"))
            {
                string input = sr.ReadToEnd();
                Console.WriteLine(GetChecksum(input));
                Console.WriteLine(GetChecksumWithFragmentation(input));
            }
        }
        public long GetChecksum(string input)
        {
            input = input.TrimEnd('\n');
            List<int> unfoldData = new List<int>();
            int index = 0;
            for (int i = 0; i<input.Length; i++)
            {
                int blockLen = Convert.ToInt32(input[i].ToString());
                int data = 0;
                if (i % 2 == 0)
                {
                    data = index;
                    index++;
                }
                else
                    data = -1;
                
                for (int j = 0; j < blockLen; j++)                
                    unfoldData.Add(data);                
            }

            //two pointer
            long checksum = 0;
            int rightPoint = unfoldData.Count - 1;
            for(int i = 0; i <= rightPoint && i < unfoldData.Count; i++)
            {
                if (unfoldData[i] != -1)
                    checksum += unfoldData[i] * i;
                else
                {
                    while (unfoldData[rightPoint] == -1)
                        rightPoint--;

                    if(i <= rightPoint)
                    {
                        checksum += unfoldData[rightPoint] * i;
                        rightPoint--;
                    }
                }
            }

            return checksum;
        }
        //分兩組
        //全比較
        public long GetChecksumWithFragmentation(string input)
        {
            input = input.TrimEnd('\n');
            List<BlockInfo> freeSpace = new List<BlockInfo>();
            List<BlockInfo> usedBlocks = new List<BlockInfo>();
            int dataIndex = 0;
            int pointer = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int dataLen = Convert.ToInt32(input[i].ToString());
                BlockInfo blockInfo = new BlockInfo();
                blockInfo.StartPoint = pointer;
                blockInfo.Len = dataLen;

                if (i % 2 == 0)
                {
                    blockInfo.DataIndex = dataIndex;
                    dataIndex++;
                    usedBlocks.Add(blockInfo);
                }
                else
                {
                    blockInfo.DataIndex = -1;
                    freeSpace.Add(blockInfo);
                }
                pointer += dataLen;
            }

            //allocate space 被分配走後留下的空間也不重用所以usedBlocks可以一路檢查回去
            for (int i = usedBlocks.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < freeSpace.Count; j++)
                {
                    if (usedBlocks[i].StartPoint <= freeSpace[j].StartPoint) 
                        break;

                    if(usedBlocks[i].Len == freeSpace[j].Len)
                    {
                        usedBlocks[i].StartPoint = freeSpace[j].StartPoint;
                        freeSpace.RemoveAt(j);
                        break;
                    }
                    else if (usedBlocks[i].Len < freeSpace[j].Len)
                    {
                        usedBlocks[i].StartPoint = freeSpace[j].StartPoint;
                        freeSpace[j].StartPoint += usedBlocks[i].Len;
                        freeSpace[j].Len -= usedBlocks[i].Len;
                        
                        break;
                    }
                }
            }

            long checksum = 0;
            foreach (var blockInfo in usedBlocks)
                //梯形公式 * DataIndex
                //用乘法要注意溢位...
                checksum += ((long)(blockInfo.StartPoint + (blockInfo.StartPoint + blockInfo.Len - 1)) * blockInfo.Len / 2 ) * blockInfo.DataIndex;

            return checksum;
        }
        private class BlockInfo()
        {
            public int StartPoint { get; set; }
            public int Len { get; set; }
            public int DataIndex { get; set; }
        }
    }
}
