using PageObjectsExample.Abstract;
using PageObjectsExample.Domain;
using PageObjectsExample.Pages;
using Xunit;

namespace PageObjectsExample
{
    public class NoteTests : BaseTest
    { 
        [Fact]
        public void Can_publish_new_note()
        {
            // arrange
            var testNote = new TestNote();

            var adminLoginPage = LoginPage.Open(GetBrowser());
            var adminPanelPage = adminLoginPage.Login("automatyzacja", "auto@Zima2019");
            var newNotePage = adminPanelPage.OpenNewNote();

            // act
            var newNoteUrl = newNotePage.CreateNote(testNote);

            newNotePage.Logout();
            var newlyCreatedNotePage = NotePage.Open(GetBrowser(), newNoteUrl);

            // assert
            Assert.True(newlyCreatedNotePage.Has(testNote));
        }
    }
}
