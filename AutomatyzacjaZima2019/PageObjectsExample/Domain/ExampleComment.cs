namespace PageObjectsExample.Domain
{
    internal class ExampleComment
    {
        public ExampleComment()
        {
            Author = Faker.Name.FullName();
            Email = Faker.Internet.Email();
            Content = Faker.Lorem.Paragraph();
        }

        public string Author { get; }
        public string Email { get; }
        public string Content { get; }
    }
}