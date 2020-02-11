using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;

namespace NUnitSelenium1Homework
{
    public class Tests2
    {

        [SetUp]

        public void Setup()
        {
            
        }

        [Test]
        public void WikipediaPicures()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
        }


       
    }

}