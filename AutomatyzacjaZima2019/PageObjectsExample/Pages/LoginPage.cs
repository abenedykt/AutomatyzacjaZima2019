using OpenQA.Selenium;
using PageObjectsExample.Pages.Abstract;

namespace PageObjectsExample.Pages
{
    internal class LoginPage : BasePage
    {
        private const string ADMIN_PAGE_BASE_URL = "https://automatyzacja.benedykt.net/wp-admin";

        public LoginPage(IWebDriver webDriver): base(webDriver)
        {
            browser.Navigate().GoToUrl(ADMIN_PAGE_BASE_URL);
        }

        public AdminPanelPage Login(string userName, string password)
        {
            InsertUserName(userName);
            InsertPassword(password);
            ClickLoginButton();

            return new AdminPanelPage(browser);
        }

        private void ClickLoginButton()
        {
            WaitForClickable(By.Id("wp-submit")).Click();
        }

        private void InsertPassword(string password)
        {
            WaitForClickable(By.Id("user_pass")).SendKeys(password);
        }

        private void InsertUserName(string userName)
        {
            WaitForClickable(By.Id("user_login"));
            browser.FindElement(By.Id("user_login")).SendKeys(userName);
        }

        internal static LoginPage Open(IWebDriver webDriver)
        {
            return new LoginPage(webDriver);
        }
    }
}