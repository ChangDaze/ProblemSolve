using ProblemSolveConsole.LeetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveConsoleUnitTest.LeetCode
{
    public class _2147NumberofWaystoDivideaLongCorridorTest
    {
        private _2147NumberofWaystoDivideaLongCorridor _2147NumberofWaystoDivideaLongCorridor;

        public _2147NumberofWaystoDivideaLongCorridorTest()
        {
            _2147NumberofWaystoDivideaLongCorridor = new _2147NumberofWaystoDivideaLongCorridor();
        }

        [Fact]
        public void Test1()
        {
            int result = _2147NumberofWaystoDivideaLongCorridor.NumberOfWays("SSPPSPS");
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {
            int result = _2147NumberofWaystoDivideaLongCorridor.NumberOfWays("PPSPSP");
            Assert.Equal(1, result);
        }

        [Fact]
        public void Test3()
        {
            int result = _2147NumberofWaystoDivideaLongCorridor.NumberOfWays("S");
            Assert.Equal(0, result);
        }

        [Fact]
        public void Test4()
        {
            int result = _2147NumberofWaystoDivideaLongCorridor.NumberOfWays("PPPPPSPPSPPSPPPSPPPPSPPPPSPPPPSPPSPPPSPSPPPSPSPPPSPSPPPSPSPPPPSPPPPSPPPSPPSPPPPSPSPPPPSPSPPPPSPSPPPSPPSPPPPSPSPSS");
            Assert.Equal(919999993, result);
        }

        [Fact]
        public void Test5()
        {
            int result = _2147NumberofWaystoDivideaLongCorridor.NumberOfWays("PPPPPPPSPPPSPPPPSPPPSPPPPPSPPPSPPSPPSPPPPPSPSPPPPPSPPSPPPPPSPPSPPSPPPSPPPPSPPPPSPPPPPSPSPPPPSPSPPPSPPPPSPPPPPSPSPPSPPPPSPPSPPSPPSPPPSPPSPSPPSSSS");
            Assert.Equal(18335643, result);
        }
    }
}
