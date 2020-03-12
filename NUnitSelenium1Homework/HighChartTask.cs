using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

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
            IReadOnlyCollection<IWebElement> tooltipsToHide = _driver.FindElements(By.CssSelector(".highcharts-label.highcharts-point"));
            foreach (IWebElement tooltipToHide in tooltipsToHide)
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].style.visibility='hidden'", tooltipToHide);
            }
            IReadOnlyCollection<IWebElement> tooltipElements = _driver.FindElements(By.CssSelector(".highcharts-point.highcharts-color-0"));

            foreach (IWebElement chartPoint in tooltipElements)
            {
                Actions hover = new Actions(_driver);
                hover.MoveToElement(chartPoint);
                hover.Perform();
                string actualTooltipText = chartPoint.GetAttribute("aria-label").ToString();
                //Assert.AreEqual("DB?", actualTooltipText);
            }
        }

        [Test]
        public void GreyChartCheck()
        {
            IReadOnlyCollection<IWebElement> tooltipElements = _driver.FindElements(By.CssSelector(".highcharts-point.highcharts-color-1"));
        }

        [Test]
        public void GreenChartCheck()
        {
            IReadOnlyCollection<IWebElement> tooltipElements = _driver.FindElements(By.CssSelector(".highcharts-point.highcharts-color-2"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}

