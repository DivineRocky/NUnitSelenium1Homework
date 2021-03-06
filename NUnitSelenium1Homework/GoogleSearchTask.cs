using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace NUnitSelenium1Homework
{
    public class GoogleSearchTask
    {
        private IWebDriver _driver;

        private void SearchForKeyword(string keyword)
        {
            IWebElement searchString = _driver.FindElement(By.XPath("//input[@type='text']"));
            searchString.SendKeys(keyword + Keys.Enter);
        }

        private void MakeScreenshot(string screenshotPath)
        {
            var vcs = new VerticalCombineDecorator(new ScreenshotMaker());
            byte[] screen = _driver.TakeScreenshot(vcs);
            File.WriteAllBytes(screenshotPath, screen);
        }

        private void SearchAndTakeScreenshot(string keywordRandomCompany, int maxPageNumber, bool makeScreenshotIfNotFound = false)
        {
            bool isElementFound = false;
            for (int i = 0; i < maxPageNumber; i++)
            {
                try
                {
                    IWebElement keywordRandomResult = _driver.FindElement(By.XPath(keywordRandomCompany));
                    MakeScreenshot(@$"C:\Users\Masha\Desktop\images scrshts\Found On Page {i + 1}.png");
                    isElementFound = true;
                }
                catch (Exception e)
                {
                    if (makeScreenshotIfNotFound)
                    {
                        MakeScreenshot(@$"C:\Users\Masha\Desktop\images scrshts\Not Found On Page {i + 1}.png");
                    }
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
            SearchForKeyword("�������");
            SearchAndTakeScreenshot("//a[@href='https://avksweets.com/catalog/shokolad/']", 5); 
        }

        [Test]
        public void GoogleTestTwo()
        {
            SearchForKeyword("�������");
            SearchAndTakeScreenshot("//a[@href='https://rozetka.com.ua/shokolad/c4629452/']", 1);
        }

        [Test]
        public void GoogleTestThree()
        {
            SearchForKeyword("�������");
            SearchAndTakeScreenshot("//a[@href='https://www.bmw.com/en/index.html']", 50, true); 
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}