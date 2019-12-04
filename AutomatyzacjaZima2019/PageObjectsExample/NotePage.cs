using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace PageObjectsExample
{
    internal class NotePage
    {
        private IWebDriver _browser;

        public NotePage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal NotePage AddComment(ExampleComment exampleComment)
        {
            var comment = _browser.FindElement(By.Id("comment"));
            comment.SendKeys(exampleComment.Content);

            var author = _browser.FindElement(By.Id("author"));
            author.SendKeys(exampleComment.Author);

            var email = _browser.FindElement(By.Id("email"));
            email.SendKeys(exampleComment.Email);

            MoveToElement(_browser.FindElement(By.CssSelector("div.nav-links")));

            _browser.FindElement(By.Id("submit")).Submit();

            return new NotePage(_browser);
        }

        internal bool Has(ExampleComment exampleComment)
        {
            var comments = _browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleComment.Author)
                .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleComment.Content);

            return myComments.Count() == 1;
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}