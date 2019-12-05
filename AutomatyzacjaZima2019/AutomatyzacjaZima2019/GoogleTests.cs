using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using Xunit;

namespace AutomatyzacjaZima2019
{
    public class GoogleTests : IDisposable
    {
        public IWebDriver browser;
        public GoogleTests()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void Can_Google_Weather_For_Warsaw()
        {
            browser.Navigate().GoToUrl("https://google.com");

            var queryBox = browser.FindElement(By.CssSelector(".gLFyf"));
            queryBox.Click();
            queryBox.SendKeys("pogoda warszawa");
            queryBox.Submit();

            var result = browser.FindElement(By.Id("wob_tm"));

            Assert.Equal("3", result.Text);
        }

        [Fact]
        public void Can_add_new_comment()
        {
            browser.Navigate().GoToUrl("https://automatyzacja.benedykt.net");
            var latestNote = browser.FindElement(By.CssSelector(".entry-title > a"));
            latestNote.Click();

            var commentElement = browser.FindElement(By.Id("comment"));
            var exampleText = Faker.Lorem.Paragraph();
            commentElement.SendKeys(exampleText);

            var author = browser.FindElement(By.Id("author"));
            var exampleAuthor = Faker.Name.FullName();
            author.SendKeys(exampleAuthor);

            var email = browser.FindElement(By.Id("email"));
            var exampleEmail = Faker.Internet.Email();
            email.SendKeys(exampleEmail);

            MoveToElement(browser.FindElement(By.CssSelector("div.nav-links")));

            browser.FindElement(By.Id("submit")).Submit();

            var allComments = browser.FindElements(By.CssSelector("article.comment-body"));
            var filteredComments = allComments
                .Where(comment => comment.FindElement(By.CssSelector(".fn")).Text == exampleAuthor)
                .Where(comment => comment.FindElement(By.CssSelector(".comment-content > p")).Text == exampleText);

            Assert.Single(filteredComments);

            Assert.Single(browser.FindElements(By.CssSelector("article.comment-body"))
                 .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleAuthor)
                 .Where(x => x.FindElement(By.CssSelector(".comment-content > p")).Text == exampleText));
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }

        public void Dispose()
        {
            browser.Quit();
        }
    }
}
