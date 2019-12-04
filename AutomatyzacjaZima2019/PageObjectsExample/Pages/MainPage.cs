using OpenQA.Selenium;
using PageObjectsExample.Pages.Abstract;

namespace PageObjectsExample.Pages
{
    internal class MainPage: BasePage
    {
        private const string MAIN_PAGE_BASE_URL = "https://automatyzacja.benedykt.net";

        private MainPage(IWebDriver browser) : base(browser)
        {
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }
                       
        internal static MainPage Open(IWebDriver browser)
        {
            return new MainPage(browser);
        }

        internal NotePage NavigateToNewestNote()
        {
            var latestNote = browser.FindElement(By.CssSelector(".entry-title > a"));
            latestNote.Click();

            return new NotePage(browser);
        }
    }
}