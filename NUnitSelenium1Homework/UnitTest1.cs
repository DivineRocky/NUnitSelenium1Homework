using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace NUnitSelenium1Homework
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();            
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            _driver.Navigate().GoToUrl("https://www.wikipedia.org/");
        }

        [Test]
        public void WikipediaTestOne()
        {
            IWebElement webSiteTitle = _driver.FindElement(By.CssSelector(".central-textlogo__image.svg-Wikipedia_wordmark"));
            string webSiteTitleName = webSiteTitle.Text;
            int webSiteTitleLength = webSiteTitleName.Length;
            Console.WriteLine($"Website Title name is {webSiteTitleName}, Title length is {webSiteTitleLength}");
            string currentURL = _driver.Url;
            Assert.AreEqual("https://www.wikipedia.org/", currentURL);
            string pageSource = _driver.PageSource;
            int pageSourceLength = pageSource.Length;
            Console.WriteLine(pageSourceLength);
        }

        [Test]
        public void WikipediaTestTwo()
        {
            _driver.Navigate().GoToUrl("https://www.wikipedia.org/wiki/Main_Page");
            IWebElement helpLink = _driver.FindElement(By.LinkText("Help"));
            helpLink.Click();
            _driver.Navigate().Back();
            _driver.Navigate().Forward();
            _driver.Navigate().Refresh();
        }

        [Test]
        public void BrowserSizing()
        {
            _driver.Manage().Window.Size = new Size(500, 600);
            _driver.Manage().Window.Position = new Point(200, 150);
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}