using System;
using OpenQA.Selenium;
using System.Linq;
using PageObjectsExample.Pages.Abstract;
using PageObjectsExample.Domain;

namespace PageObjectsExample.Pages
{
    internal class NotePage : BasePage
    {
        public NotePage(IWebDriver browser) : base(browser)
        {
        }

        internal NotePage AddComment(ExampleComment exampleComment)
        {
            var comment = browser.FindElement(By.Id("comment"));
            comment.SendKeys(exampleComment.Content);

            var author = browser.FindElement(By.Id("author"));
            author.SendKeys(exampleComment.Author);

            var email = browser.FindElement(By.Id("email"));
            email.SendKeys(exampleComment.Email);

            MoveToElement(browser.FindElement(By.CssSelector("div.nav-links")));

            browser.FindElement(By.Id("submit")).Submit();

            return new NotePage(browser);
        }

        internal static NotePage Open(IWebDriver webDriver, Uri noteUrl)
        {
            webDriver.Navigate().GoToUrl(noteUrl);
            return new NotePage(webDriver);
        }

        internal bool Has(ExampleComment exampleComment)
        {
            var comments = browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleComment.Author)
                .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleComment.Content);

            return myComments.Count() == 1;
        }

        internal bool Has(TestNote note)
        {
            return browser.FindElement(By.CssSelector(".entry-title")).Text == note.Title
                && browser.FindElement(By.CssSelector(".entry-content")).Text == note.Content;
        }
    }
}