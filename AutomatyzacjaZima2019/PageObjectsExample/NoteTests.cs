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
            var testNote = new TestNote();
            var adminLogin = AdminPage.Open(GetBrowser());
            var adminPanel = adminLogin.Login("automatyzacja", "auto@Zima2019");
            var newNotePage = adminPanel.OpenNewNote();
            var newNoteUrl = newNotePage.CreateNote(testNote);

            var newNote = NotePage.Open(GetBrowser(), newNoteUrl);

            Assert.True(newNote.Has(testNote));
        }
    }
}
