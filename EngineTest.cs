using ChessCompanion.MVVM.Model;
using ChessCompanion.MVVM.Model.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class EngineTest : IDisposable
    {

        IEngine engine;
        
        
        public EngineTest()
        {
            this.engine = new Engine(@"C:\Users\marti\source\repos\martinkoch1\Stockfish_Polyglot_15_64-bit");
        }
        public void Dispose() 
        {

        }
        [Fact]
        public void MultipleLinesTest()
        {
            engine.SetPosition("rnb1kb2/pp1ppprp/7P/q1p5/3Pn3/1P1B1Np1/P1PQ1PP1/RNB1K2R w KQq - 1 11");
            engine.setLines(5);
            TopMove[] topMoves = new TopMove[5];
            topMoves = engine.GetMultipleLines(1000);
        }

    }
}
