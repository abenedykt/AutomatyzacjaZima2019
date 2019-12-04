using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectsExample.Domain
{
    public class DriverFactory
    {
        internal static IWebDriver Get()
        {
            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
    }
}