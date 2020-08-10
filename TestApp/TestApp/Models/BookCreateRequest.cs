namespace TestApp.Models
{
    public class BookCreateRequest
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int BookTypeId { get; set; }
    }
}
