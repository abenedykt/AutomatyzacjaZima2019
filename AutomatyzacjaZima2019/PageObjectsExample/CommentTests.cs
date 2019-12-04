
using Xunit;

namespace PageObjectsExample
{
    public class CommentTests
    {
        [Fact]
        public void Can_add_new_comment_to_latest_note()
        {
            var blogStartPage = MainPage.Open();
            var note = blogStartPage.NavigateToNewestNote();
            var exampleComment = new ExampleComment();
            var noteWithComment = note.AddComment(exampleComment);

            Assert.True(noteWithComment.Has(exampleComment));
        }
    }
}
