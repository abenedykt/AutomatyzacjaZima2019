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
            WaitForClickable(By.Id("user_login"), 5);
            var userLogin = browser.FindElement(By.Id("user_login"));
            userLogin.SendKeys(userName);

            WaitForClickable(By.Id("user_pass"), 5);
            var passwordElement = browser.FindElement(By.Id("user_pass"));
            passwordElement.SendKeys(password);

            WaitForClickable(By.Id("wp-submit"), 5);
            var login = browser.FindElement(By.Id("wp-submit"));
            login.Click();


            return new AdminPanelPage(browser);
        }

        internal static AdminPage Open(IWebDriver webDriver)
        {
            return new AdminPage(webDriver);
        }
    }
}