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
            FillOutTitle(testNote);
            ClickHtmlContent();
            WaitForPublishClickable();
            FillOutContent(testNote);
            Publish();

            WaitForPublishClickable();

            string url = GetNewNoteUrl();

            return new Uri(url);
        }

        internal void Logout()
        {
            MoveToElement(By.Id("wp-admin-bar-my-account"));

            WaitForClickable(By.Id("wp-admin-bar-logout")).Click();
        }

        private string GetNewNoteUrl()
        {
            var postUrl = browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var url = postUrl.GetAttribute("href");
            return url;
        }

        private void Publish()
        {
            var publishButton = browser.FindElement(By.Id("publish"));
            publishButton.Click();
        }

        private void FillOutContent(TestNote testNote)
        {
            var contentElement = browser.FindElement(By.Id("content"));
            contentElement.SendKeys(testNote.Content);
        }

        private void WaitForPublishClickable()
        {
            WaitForClickable(By.Id("publish"), 5);
            WaitForClickable(By.CssSelector(".edit-slug.button"), 5);
        }

        private void ClickHtmlContent()
        {
            browser.FindElement(By.Id("content-html")).Click();
        }

        private void FillOutTitle(TestNote testNote)
        {
            var noteTitle = browser.FindElement(By.Id("title-prompt-text"));
            noteTitle.Click();
            var titleElement = browser.FindElement(By.Id("title"));
            titleElement.SendKeys(testNote.Title);
        }







    }
}