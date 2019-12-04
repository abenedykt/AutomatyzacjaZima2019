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

        internal NewNotePage OpenNewNote()
        {
            var menuElements = browser.FindElements(By.ClassName("wp-menu-name"));

            var posts = menuElements.Single(x => x.Text == "Wpisy");
            posts.Click();

            var submenuItems = browser.FindElements(By.CssSelector(".wp-submenu > li"));
            var newPost = submenuItems.Single(x => x.Text == "Dodaj nowy");
            newPost.Click();


            return new NewNotePage(browser);
        }
    }
}