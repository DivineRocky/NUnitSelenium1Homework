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
    public class WikipediaScreenshots
    {
        private IWebDriver _driver;

        [SetUp]

        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
        }

        [Test]
        public void WikipediaPictures()
        {
            var images = _driver.FindElements(By.TagName("img"));
            for (int i = 1; i <= images.Count; i++)
            {
                if (images[i-1].Size.Width<100)
                {
                    continue;
                }

                var ele = By.XPath($"(//img)[{i}]");
                var arr = _driver.TakeScreenshot(new OnlyElementDecorator(new ScreenshotMaker()).SetElement(ele));
                File.WriteAllBytes(@$"C:\Users\Masha\Desktop\images scrshts\scr{i}.png", arr);
            }            
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

        //[Test]
        //public void WikipediaPicturesTest()
        //{
        //    var images = _driver.FindElements(By.XPath("//*[@class='image']"));
        //    for (int i = 1; i <= images.Count; i++)
        //    {
        //        var ele = By.XPath("//*[@class='image']");
        //        var arr = _driver.TakeScreenshot(new OnlyElementDecorator(new ScreenshotMaker()).SetElement(ele));
        //        File.WriteAllBytes(@$"C:\Users\Masha\Desktop\images scrshts\scr{i}.png", arr);
        //    }
        //}
    }
}