using OpenQA.Selenium;
using System;

namespace PageObjectsExample
{
    internal class MainPage
    {
        private const string MAIN_PAGE_BASE_URL = "https://automatyzacja.benedykt.net";
        private readonly IWebDriver _browser;

        private MainPage(IWebDriver browser)
        {
            _browser = browser;
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }

        internal static MainPage Open()
        {
            return new MainPage(DriverFactory.Get());
        }

        internal NotePage NavigateToNewestNote()
        {
            var latestNote = _browser.FindElement(By.CssSelector(".entry-title > a"));
            latestNote.Click();

            return new NotePage(_browser);
        }
    }
}