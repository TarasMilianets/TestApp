namespace TestApp.Models
{
    public class Book
    {
        public Book(int id, string author, string title, BookType type)
        {
            Id = id;
            Author = author;
            Title = title;
            Type = type;
        }

        public int Id { get; }

        public string Author { get; }

        public string Title { get; }

        public BookType Type { get; }
    }
}
