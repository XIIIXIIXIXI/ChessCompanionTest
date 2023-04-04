using ChessCompanion.MVVM.Model;
using ChessCompanion.MVVM.Utility;
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
    public class GameScraperTest : IDisposable
    {
       
        GameScraper scraper;
        ChessBoard board = new ChessBoard();
        
        public GameScraperTest()
        {
            var driver = new ChromeDriver();
            //setup test
            this.scraper = new GameScraper(driver);
            driver.Navigate().GoToUrl("https://www.chess.com/play/computer");
        }
        public void Dispose() 
        {

        }

        [Fact]
        public void CheckFlag()
        {
            bool expected = true;
            

            bool actual = scraper.IsResignElementPresent();

            bool expected2 = false;

            bool actual2 = scraper.IsResignElementPresent();

            Assert.Equal(expected, actual);
            Assert.Equal(expected2, actual2);

        }

        [Fact]
        public void PlayerColorTest()
        {
            bool expected = false;
            scraper.FindPlayerColor();

            bool actual = scraper.isWhite;

            Assert.Equal(expected, actual);
        }
       
        [Fact]
        public void WaitForOpponentToMoveTest()
        {
            scraper.FindPlayerColor();
            while (true)
            {
                scraper.WaitForOpponentToMove();
                Debug.WriteLine("Your turn");
                scraper.WaitForPlayerToMove();
                Debug.WriteLine("Opponent turn");

            }
        }
        [Fact]
        public void BlackOrWhiteToMoveTest()
        {
            char expected = 'b';
            char actual = scraper.BlackOrWhiteToMove();
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void MakeMove()
        {
            scraper.MakeMove("e2e4");
            scraper.MakeMove("f2f4");
            scraper.MakeMove("a2a3");

        }
        [Fact]
        public void GetLatestMove()
        {
            scraper.FindPlayerColor();
            string move = scraper.GetLatestMoveForWhite();
            //string square = board.TranslateMoveToSquare(move);
            Debug.WriteLine("");

        }
    }
}
