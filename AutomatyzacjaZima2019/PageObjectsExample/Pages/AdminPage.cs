using OpenQA.Selenium;
using PageObjectsExample.Pages.Abstract;

namespace PageObjectsExample.Pages
{
    internal class AdminPage : BasePage
    {
        private const string ADMIN_PAGE_BASE_URL = "https://automatyzacja.benedykt.net/wp-admin";

        public AdminPage(IWebDriver webDriver): base(webDriver)
        {
            browser.Navigate().GoToUrl(ADMIN_PAGE_BASE_URL);
        }

        internal AdminPanelPage Login(string userName, string password)
        {
            WaitForClickable(By.Id("user_login")).SendKeys(userName);

            WaitForClickable(By.Id("user_pass")).SendKeys(password);

            WaitForClickable(By.Id("wp-submit")).Click();


            return new AdminPanelPage(browser);
        }

        internal static AdminPage Open(IWebDriver webDriver)
        {
            return new AdminPage(webDriver);
        }
    }
}