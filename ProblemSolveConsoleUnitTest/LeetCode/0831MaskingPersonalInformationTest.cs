using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _0831MaskingPersonalInformationTest
    {
        private _0831MaskingPersonalInformation _0831MaskingPersonalInformation;

        public _0831MaskingPersonalInformationTest()
        {
            _0831MaskingPersonalInformation = new _0831MaskingPersonalInformation();
        }

        [Fact]
        public void Test1()
        {
            string result = _0831MaskingPersonalInformation.MaskPII("LeetCode@LeetCode.com");
            Assert.Equal("l*****e@leetcode.com", result);
        }

        [Fact]
        public void Test2()
        {
            string result = _0831MaskingPersonalInformation.MaskPII("AB@qq.com");
            Assert.Equal("a*****b@qq.com", result);
        }

        [Fact]
        public void Test3()
        {
            string result = _0831MaskingPersonalInformation.MaskPII("1(234)567-890");
            Assert.Equal("***-***-7890", result);
        }

        [Fact]
        public void Test4()
        {
            string result = _0831MaskingPersonalInformation.MaskPII("86-(10)12345678");
            Assert.Equal("+**-***-***-5678", result);
        }

        [Fact]
        public void Test5()
        {
            string result = _0831MaskingPersonalInformation.MaskPII("+5(4266)719-677-");
            Assert.Equal("+*-***-***-9677", result);
        }

        [Fact]
        public void Test6()
        {
            string result = _0831MaskingPersonalInformation.MaskPII("+46(427)55-7-41");
            Assert.Equal("***-***-5741", result);
        }
    }
}
