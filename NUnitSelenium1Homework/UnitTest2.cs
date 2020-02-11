using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace NUnitSelenium1Homework
{
    public class Tests2
    {
        private IWebDriver _driver;

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 7);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
        }

        [Test]
        public void WikipediaPicures()
        {
            var images = _driver.FindElements(By.TagName("img"));

        }


       
    }

}