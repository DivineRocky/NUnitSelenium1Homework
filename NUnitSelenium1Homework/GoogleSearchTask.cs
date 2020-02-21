using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WDSE;
using WDSE.Decorators;
using WDSE.Decorators.CuttingStrategies;
using WDSE.ScreenshotMaker;

namespace NUnitSelenium1Homework
{
    public class GoogleSearchTask
    {
        private IWebDriver _driver;

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.google.com//");
        }

        [Test]
        public void FilterCheck()
        {
            IWebElement searchString = _driver.FindElement(By.CssSelector("#fakebox-input"));
            searchString.SendKeys("Шоколад"+ Keys.Enter);
            
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}