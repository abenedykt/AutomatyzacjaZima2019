namespace PageObjectsExample.Domain
{
    internal class TestNote
    {
        public TestNote()
        {
            Title = Faker.Lorem.Sentence();
            Content = Faker.Lorem.Paragraph();
        }

        public string Title { get; }
        public string Content { get; }
    }
}