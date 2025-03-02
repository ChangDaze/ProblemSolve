using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _3019NumberofChangingKeysTest
    {
        private _3019NumberofChangingKeys _3019NumberofChangingKeys;

        public _3019NumberofChangingKeysTest()
        {
            _3019NumberofChangingKeys = new _3019NumberofChangingKeys();
        }
        [Fact]
        public void Test1()
        {
            var result = _3019NumberofChangingKeys.CountKeyChanges("aAbBcC");
            Assert.Equal(2, result);
        }
        [Fact]
        public void Test2()
        {
            var result = _3019NumberofChangingKeys.CountKeyChanges("AaAaAaaA");
            Assert.Equal(0, result);
        }
    }
}
