using ProblemSolveConsole.AdventofCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.AdventofCode
{
    public class _2024D5Test
    {
        private _2024D5 _2024D5;
        public _2024D5Test()
        {
            _2024D5 = new _2024D5();
        }
        [Fact]
        public void GetOrderSumTest()
        {
            var result = _2024D5.GetOrderSum(@"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47");
            Assert.Equal(143, result);
        }
        [Fact]
        public void GetUnorderSummTest()
        {
            var result = _2024D5.GetUnorderSum(@"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47");
            Assert.Equal(123, result);
        }
    }
}
