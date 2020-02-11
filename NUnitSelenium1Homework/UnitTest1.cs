using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace NUnitSelenium1Homework
{
    public class Tests
    {

        [SetUp]

        public void Setup()
        {
            
        }

        [Test]
        public void WikipediaTestOne()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            IWebElement webSiteTitle = driver.FindElement(By.XPath("//head/title"));
            string webSiteTitleName = webSiteTitle.ToString();
            int webSiteTitleLength = webSiteTitleName.Length;
            Console.WriteLine(webSiteTitleName, webSiteTitleLength);
            string currentURL = driver.Url;
            Assert.AreEqual("https://www.wikipedia.org/", currentURL);
            string pageSource = driver.PageSource;
            int pageSourceLength = pageSource.Length;
            Console.WriteLine(pageSourceLength);
            driver.Close();
        }

        [Test]
        public void WikipediaTestTwo()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
            IWebElement helpLink = driver.FindElement(By.LinkText("Help"));
            helpLink.Click();
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
            driver.Close();
        }

        [Test]
        public void BrowserSizing()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(500, 600);
            driver.Manage().Window.Position = new Point(200,150);
            driver.Manage().Window.Maximize();
            driver.Close();
        }
    }
}