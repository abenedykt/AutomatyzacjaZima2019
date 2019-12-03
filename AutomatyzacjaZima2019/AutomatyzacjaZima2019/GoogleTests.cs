using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace AutomatyzacjaZima2019
{
    public class GoogleTests : IDisposable
    {
        public IWebDriver browser;
        public GoogleTests()
        {
            browser = new ChromeDriver();
        }
        
        [Fact]
        public void Can_Google_Weather_For_Warsaw()
        {
            browser.Navigate().GoToUrl("https://google.com");

            var queryBox = browser.FindElement(By.CssSelector(".gLFyf"));
            queryBox.Click();
            queryBox.SendKeys("pogoda warszawa");
            queryBox.Submit();

            var result = browser.FindElement(By.Id("wob_tm"));

            Assert.Equal("3", result.Text);
        }

        public void Dispose()
        {
            browser.Quit();
        }
    }
}
