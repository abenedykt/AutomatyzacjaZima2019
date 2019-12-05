using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectsExample.Pages.Abstract
{
    internal class BasePage
    {
        protected readonly IWebDriver browser;

        public BasePage(IWebDriver browser)
        {
            this.browser = browser;
        }

        protected IWebElement WaitForClickable(By by, int seconds = 10)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        protected IWebElement WaitForClickable(IWebElement element, int seconds = 10)
        {   
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
        protected void MoveToElement(By selector)
        {
            var element = browser.FindElement(selector);
            MoveToElement(element);
        }
        protected void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        internal void ScrollToElement(By selector)
        {
            IWebElement element = browser.FindElement(selector);
            Actions actions = new Actions(browser);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}