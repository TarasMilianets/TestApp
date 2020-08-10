using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public BookTypeEntity Type { get; set; }
    }
}
