using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using WDSE;
using WDSE.Decorators;
using WDSE.Decorators.CuttingStrategies;
using WDSE.ScreenshotMaker;

namespace NUnitSelenium1Homework
{
    public class HighChartTask
    {
        private IWebDriver _driver;

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.highcharts.com/demo/combo-timeline");
        }

        [Test]
        public void BlueChartCheck()
        {
            IReadOnlyCollection<IWebElement> tooltipElements = _driver.FindElements(By.CssSelector(".highcharts-point.highcharts-color-0"));

            foreach (IWebElement bluePoint in tooltipElements)
            {
                Actions hover = new Actions(_driver);
                hover.MoveToElement(bluePoint);
                Thread.Sleep(10);
                hover.Perform();
            }            
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}

