using Xunit;

namespace PageObjectsExample
{
    public class CommentTests
    {
        [Fact]
        public void Can_add_new_comment_to_latest_note()
        {
            var startPage = MainPage.Open();
            var notePage = startPage.NavigateToNewestNote();
            var testComment = new ExampleComment();
            var noteWithComment = notePage.AddComment(testComment);

            Assert.True(noteWithComment.Has(testComment));
        }
    }
}
