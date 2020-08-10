using Microsoft.EntityFrameworkCore;
using TestApp.Entities;

namespace TestApp.DAL
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options) { }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<BookTypeEntity> Types { get; set; }
    }
}
