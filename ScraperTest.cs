using Xunit;
using ChessCompanion;
using System;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;
using Xunit.Sdk;
using System.Security.Policy;
using OpenQA.Selenium.Chrome;
using ChessCompanion.MVVM.Utility;
using OpenQA.Selenium;
using System.Reflection.Metadata;
using System.Windows.Documents;
using ChessCompanion.MVVM.Model;

namespace Test
{
    public class ScraperTest : IDisposable
    {
        Scraper scraper;
        GameScraper gameScraper;
        ChessBoard board = new ChessBoard();
        LastMoveIcon lastMoveIcon;
        EvaluationBar evalBar;
        public ScraperTest() 
        {
            var driver = new ChromeDriver();
            //setup test
            scraper = new Scraper(driver);
           // scraper.driver.Navigate().GoToUrl("https://www.chess.com/play/computer");

            this.gameScraper = new GameScraper(driver);

            
        }
        public void Dispose()
        {
            //close down test
        }

        [Fact]
        public void ScraperRun()
        {
            // Get the page source of the current web page
            string pageSource = scraper.driver.PageSource;

            // Print the page source to the console
            Debug.WriteLine(pageSource);

        }

        [Fact]
        public void makeIcon()
        {
            string square1 = "24";
            string square2 = "45";
            string square3 = "64";
            string square4 = "11";
            string square5 = "34";
            string square6 = "67";
            string square7 = "66";

            var Brilliant = MoveScoreColors.IconData[MoveScore.Brilliant];
            var greatFind = MoveScoreColors.IconData[MoveScore.GreatFind];
            var inaccuracy = MoveScoreColors.IconData[MoveScore.Inaccuracy];
            var good = MoveScoreColors.IconData[MoveScore.Good];
            var GreatFind = MoveScoreColors.IconData[MoveScore.GreatFind];
            var blunder = MoveScoreColors.IconData[MoveScore.Blunder];


            scraper.ShowAnalyzedIcon(square1, Brilliant);
            scraper.ShowAnalyzedIcon(square2, greatFind);
            scraper.ShowAnalyzedIcon(square3, good);
            scraper.ShowAnalyzedIcon(square4, greatFind);
            scraper.ShowAnalyzedIcon(square5, inaccuracy);
            scraper.ShowAnalyzedIcon(square6, GreatFind);
            scraper.ShowAnalyzedIcon(square7, blunder);


        }

        [Fact]
        public void evalBarTest()
        {
            gameScraper.FindPlayerColor();
            this.evalBar = new EvaluationBar(scraper.driver);

            evalBar.CreateBar(gameScraper.isWhite);
            evalBar.UpdateBar(gameScraper.isWhite, 2000, null, 'w');
            evalBar.UpdateBar(gameScraper.isWhite, 0, null, 'w');
            evalBar.UpdateBar(gameScraper.isWhite, 3600, null, 'w');
            evalBar.UpdateBar(gameScraper.isWhite, -4000, null, 'w');
            evalBar.UpdateBar(gameScraper.isWhite, -8000, null, 'w');
            evalBar.UpdateBar(gameScraper.isWhite, 0, null, 'w');
            evalBar.UpdateBar(gameScraper.isWhite, null, 2, 'w');
            evalBar.UpdateBar(gameScraper.isWhite, null, -2, 'w');
        }


    }
}