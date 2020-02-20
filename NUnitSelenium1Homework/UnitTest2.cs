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
        public void WikipediaPictures()
        {
            //var images = _driver.FindElements(By.TagName("img"));

            var ele = By.TagName("img");
            var arr = _driver.TakeScreenshot(new OnlyElementDecorator(new ScreenshotMaker()).SetElement(ele));
            string path = Directory.GetCurrentDirectory();
            File.WriteAllBytes(path, arr);
        }
    }
}