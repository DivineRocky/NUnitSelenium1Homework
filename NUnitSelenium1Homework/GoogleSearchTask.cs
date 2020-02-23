using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using WDSE;
using WDSE.Decorators;
using WDSE.Decorators.CuttingStrategies;
using WDSE.ScreenshotMaker;

namespace NUnitSelenium1Homework
{
    public class GoogleSearchTask
    {
        private IWebDriver _driver;

        private void SearchForKeyword(string keyword)
        {
            IWebElement searchString = _driver.FindElement(By.XPath("//*[@title='Поиск']"));
            searchString.SendKeys(keyword + Keys.Enter);
        }

        private void SearchingAndTakingScreenshot(string keywordRandomCorp, int maxPageNumber)
        {
            bool isElementFound = false;
            for (int i = 0; i < maxPageNumber; i++)
            {
                try
                {
                    IWebElement keywordRandomResult = _driver.FindElement(By.XPath(keywordRandomCorp));
                    var vcs = new VerticalCombineDecorator(new ScreenshotMaker());
                    byte[] screen = _driver.TakeScreenshot(vcs);
                    File.WriteAllBytes(@$"C:\Users\Masha\Desktop\images scrshts\Found On Page {i + 1}.png", screen);
                    isElementFound = true;
                }
                catch (Exception e)
                {
                }
                IWebElement nextButton = _driver.FindElement(By.XPath("//*[@id='pnnext']"));
                nextButton.Click();
            }
            if (!isElementFound)
            {
                throw new Exception("Element is not found");
            }
        }

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.google.com//");
        }

        [Test]
        public void GoogleTestOne()
        {
            SearchForKeyword("Шоколад");
            SearchingAndTakingScreenshot("//a[@href='https://avksweets.com/catalog/shokolad/']", 5); 
        }

        [Test]
        public void GoogleTestTwo()
        {
            SearchForKeyword("Шоколад");
            SearchingAndTakingScreenshot("//a[@href='https://rozetka.com.ua/shokolad/c4629452/']", 1);
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}