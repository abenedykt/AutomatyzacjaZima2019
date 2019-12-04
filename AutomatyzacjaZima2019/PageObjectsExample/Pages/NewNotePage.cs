using System;
using OpenQA.Selenium;
using PageObjectsExample.Domain;
using PageObjectsExample.Pages.Abstract;

namespace PageObjectsExample.Pages
{
    internal class NewNotePage : BasePage
    {
        public NewNotePage(IWebDriver browser): base(browser)
        {
        }

        internal Uri CreateNote(TestNote testNote)
        {
            var noteTitle = browser.FindElement(By.Id("title-prompt-text"));
            noteTitle.Click();
            var titleElement = browser.FindElement(By.Id("title"));
            titleElement.SendKeys(testNote.Title);

            browser.FindElement(By.Id("content-html")).Click();

            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);


            var contentElement = browser.FindElement(By.Id("content"));
            contentElement.SendKeys(testNote.Content);

            var publishButton = browser.FindElement(By.Id("publish"));
            publishButton.Click();

            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);
            var postUrl = browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var url = postUrl.GetAttribute("href");

            return new Uri(url);
        }
    }
}