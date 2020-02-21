using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WDSE.Decorators;
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
        public void WikipediaPicures()
        {
            //var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            //var memoryStream = new MemoryStream(bytesArr);
            //Bitmap pageScreenshot = new Bitmap(memoryStream);
            //mainPageImage.SaveAsFile("C:/Users/Mariia_Khmaruk/Downloads/TestImages/screen.png");
            //var images = _driver.FindElements(By.TagName("img"));

        }


       
    }

}