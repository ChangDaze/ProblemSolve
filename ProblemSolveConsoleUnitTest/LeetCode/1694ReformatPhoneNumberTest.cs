using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _1694ReformatPhoneNumberTest
    {
        private _1694ReformatPhoneNumber _1694ReformatPhoneNumber;

        public _1694ReformatPhoneNumberTest()
        {
            _1694ReformatPhoneNumber = new _1694ReformatPhoneNumber();
        }
        [Fact]
        public void Test1()
        {
            var result = _1694ReformatPhoneNumber.ReformatNumber("1-23-45 6");
            Assert.Equal("123-456", result);
        }
        [Fact]
        public void Test2()
        {
            var result = _1694ReformatPhoneNumber.ReformatNumber("123 4-567");
            Assert.Equal("123-45-67", result);
        }
        [Fact]
        public void Test3()
        {
            var result = _1694ReformatPhoneNumber.ReformatNumber("123 4-5678");
            Assert.Equal("123-456-78", result);
        }
        [Fact]
        public void Test4()
        {
            var result = _1694ReformatPhoneNumber.ReformatNumber("12");
            Assert.Equal("12", result);
        }
    }
}
