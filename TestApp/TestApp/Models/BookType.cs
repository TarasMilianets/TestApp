namespace TestApp.Models
{
    public class BookType
    {
        public BookType(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        public int Id { get; }

        public string TypeName { get; }
    }
}
