using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace NUnitSelenium1Homework
{
    public class RozetkaTask
    {
        private IWebDriver _driver;

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://rozetka.com.ua/mobile-phones/c80003/");
        }

        [Test]
        public void FilterCheck()
        {
            IWebElement minInputValue = _driver.FindElement(By.XPath("//input[@formcontrolname='min']"));
            minInputValue.Clear();
            minInputValue.SendKeys("10000");
            IWebElement okButton = _driver.FindElement(By.XPath("//div[@class='slider-filter__inner']/button"));
            okButton.Click();
            IWebElement minimalInputValue = _driver.FindElement(By.XPath("//input[@formcontrolname='min']"));
            Assert.AreEqual("10000", minimalInputValue.GetAttribute("value").ToString());
            IReadOnlyCollection <IWebElement> searchResults = _driver.FindElements(By.XPath("//*[@class='goods-tile__price-value']"));

            foreach (IWebElement priceEl in searchResults)
            {
                string priceText = priceEl.Text.Replace(" ", "");
                int convertedPriceEl = Int32.Parse(priceText);
                Assert.GreaterOrEqual(convertedPriceEl, 10000);
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }
}