using System.Linq;
using OpenQA.Selenium;
using PageObjectsExample.Pages.Abstract;

namespace PageObjectsExample.Pages
{
    internal class AdminPanelPage : BasePage
    {
        public AdminPanelPage(IWebDriver browser): base(browser)
        {
        }

        public NewNotePage OpenNewNote()
        {
            Click_Wpisy();
            Click_DodajNowy();

            return new NewNotePage(browser);
        }

        private void Click_DodajNowy()
        {
            var submenuItems = browser.FindElements(By.CssSelector(".wp-submenu > li"));
            var newPost = submenuItems.Single(x => x.Text == "Dodaj nowy");
            newPost.Click();
        }

        private void Click_Wpisy()
        {
            var menuElements = browser.FindElements(By.ClassName("wp-menu-name"));

            var posts = menuElements.Single(x => x.Text == "Wpisy");
            posts.Click();
        }
    }
}