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

namespace Test
{
    public class ScraperTest : IDisposable
    {
        Scraper scraper;
        LastMoveIcon lastMoveIcon;
        public ScraperTest() 
        {
            var driver = new ChromeDriver();
            //setup test
            scraper = new Scraper(driver);
           // scraper.driver.Navigate().GoToUrl("https://www.chess.com/play/computer");

            
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
            //string jsCode = "console.log('// Get the board element\r\nconst board = document.querySelector('.board-layout-main .board');\r\n\r\nconst div = document.createElement('div');\r\ndiv.classList.add('effect', 'square-54');\r\ndiv.setAttribute('bis_skin_checked', '1');\r\n\r\n// Create the svg element\r\nconst svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');\r\nsvg.setAttribute('class', '');\r\nsvg.setAttribute('width', '100%');\r\nsvg.setAttribute('height', '100%');\r\nsvg.setAttribute('viewBox', '0 0 18 19');\r\n\r\n// Create the g element\r\nconst g = document.createElementNS('http://www.w3.org/2000/svg', 'g');\r\ng.setAttribute('id', 'excellent');\r\n\r\n// Create the first group of paths\r\nconst g1 = document.createElementNS('http://www.w3.org/2000/svg', 'g');\r\nconst shadowPath = document.createElementNS('http://www.w3.org/2000/svg', 'path');\r\nshadowPath.setAttribute('class', 'icon-shadow');\r\nshadowPath.setAttribute('opacity', '0.3');\r\nshadowPath.setAttribute('d', 'M9,.5a9,9,0,1,0,9,9A9,9,0,0,0,9,.5Z');\r\nconst backgroundPath = document.createElementNS('http://www.w3.org/2000/svg', 'path');\r\nbackgroundPath.setAttribute('class', 'icon-background');\r\nbackgroundPath.setAttribute('fill', '#b33430');\r\nbackgroundPath.setAttribute('d', 'M9,0a9,9,0,1,0,9,9A9,9,0,0,0,9,0Z');\r\ng1.appendChild(shadowPath);\r\ng1.appendChild(backgroundPath);\r\n\r\n// Create the second group of paths\r\nconst g2 = document.createElementNS('http://www.w3.org/2000/svg', 'g');\r\ng2.setAttribute('class', 'icon-component-shadow');\r\ng2.setAttribute('opacity', '0.2');\r\nconst path1 = document.createElementNS('http://www.w3.org/2000/svg', 'path');\r\npath1.setAttribute('d', 'M13.79,11.34c0-.2.4-.53.4-.94S14,9.72,14,9.58a2.06,2.06,0,0,0,.18-.83,1,1,0,0,0-.3-.69,1.13,1.13,0,0,0-.55-.2,10.29,10.29,0,0,1-2.07,0c-.37-.23,0-1.18.18-1.7S11.9,4,10.62,3.7c-.69-.17-.66.37-.78.9-.05.21-.09.43-.13.57A5,5,0,0,1,7.05,8.23a1.57,1.57,0,0,1-.42.18v4.94A7.23,7.23,0,0,1,8,13.53c.52.12.91.25,1.44.33A11.11,11.11,0,0,0,11,14a6.65,6.65,0,0,0,1.18,0,1.09,1.09,0,0,0,1-.59.66.66,0,0,0,.06-.2,1.63,1.63,0,0,1,.07-.3c.13-.28.37-.3.5-.68S13.74,11.53,13.79,11.34Z');\r\nconst path2 = document.createElementNS('http://www.w3.org/2000/svg', 'path');\r\npath2.setAttribute('d', 'M5.49,8.09H4.31a.5.5,0,0,0-.5.5v4.56a.5.5,0,0,0,.5.5H5.49a.5.5,0,0,0,.5-.5V8.59A.5.5,0,0,0,5.49,8.09Z');\r\ng2.appendChild(path1);\r\ng2.appendChild(path2);\r\n\r\n// Create the third group of paths\r\nconst g3 = document.createElementNS('http://www.w3.org/2000/svg', 'g');\r\nconst path3 = document.createElementNS('http://www.w3.org/2000/svg', 'path');\r\npath3.setAttribute('class', 'icon-component');\r\npath3.setAttribute('fill', '#fff');\r\npath3.setAttribute('d', 'M13.79,10.84c0-.2.4-.53.4-.94S14,9.22,14,9.08a2.06,2.06,0,0,0,.18-.83,1,1,0,0,0-.3-.69,1.13,1.13,0,0,0-.55-.2,10.29,10.29,0,0,1-2.07,0c-.37-.23,0-1.18.18-1.7s.51-2.12-.77-2.43c-.69-.17-.66.37-.78.9-.05.21-.09.43-.13.57A5,5,0,0,1,7.05,7.73a1.57,1.57,0,0,1-.42.18v4.94A7.23,7.23,0,0,1,8,13c.52.12.91.25,1.44.33a11.11,11.11,0,0,0,1.62.16,6.65,6.65,0,0,0,1.18,0,1.09,1.09,0,0,0,1-.59.66.66,0,0,0,.06-.2,1.63,1.63,0,0,1,.07-.3c.13-.28.37-.3.5-.68S13.74,11,13.79,10.84Z');\r\nconst path4 = document.createElementNS('http://www.w3.org/2000/svg', 'path');\r\npath4.setAttribute('class', 'icon-component');\r\npath4.setAttribute('fill', '#fff');\r\npath4.setAttribute('d', 'M5.49,7.59H4.31a.5.5,0,0,0-.5.5v4.56a.5.5,0,0,0,.5.5H5.49a.5.5,0,0,0,.5-.5V8.09A.5.5,0,0,0,5.49,7.59Z');\r\ng3.appendChild(path3);\r\ng3.appendChild(path4);\r\n\r\n// Append the elements\r\ng.appendChild(g1);\r\ng.appendChild(g2);\r\ng.appendChild(g3);\r\nsvg.appendChild(g);\r\ndiv.appendChild(svg);\r\n\r\n// Add the element to the document\r\nboard.appendChild(div);\r\n');";

            scraper.ShowAnalyzedIcon("");


        }



    }
}