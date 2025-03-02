using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProblemSolveConsole.LeetCode._0705DesignHashSet;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0705DesignHashSetTest
    {
        private _0705DesignHashSet _0705DesignHashSet;

        public _0705DesignHashSetTest()
        {
            _0705DesignHashSet = new _0705DesignHashSet();
        }
        [Fact]
        public void Test1()
        {
            MyHashSet myHashSet = new MyHashSet();
            myHashSet.Add(1);      // set = [1]
            myHashSet.Add(2);      // set = [1, 2]
            Assert.True(myHashSet.Contains(1)); // return True
            Assert.False(myHashSet.Contains(3));// return False, (not found)
            myHashSet.Add(2);      // set = [1, 2]
            Assert.True(myHashSet.Contains(2)); // return True
            myHashSet.Remove(2);   // set = [1]
            Assert.False(myHashSet.Contains(2)); // return False, (already removed)
        }
    }
}
