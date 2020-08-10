using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.DAL.Repositories.Abstractions;
using TestApp.Entities;
using TestApp.Models;

namespace TestApp.DAL.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private DBContext _context;

        public BooksRepository(DBContext context)
        {
            _context = context;
        }

        public async Task CreateBook(BookCreateRequest request)
        {
            var book = new BookEntity
            {
                Id = await GenerateNewIdAsync(),
                Title = request.Title,
                Author = request.Author,
                TypeId = request.BookTypeId
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        private async Task<int> GenerateNewIdAsync()
        {
            var id = await _context.Books.MaxAsync(x => x.Id);

            return id+1;
        }


        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _context.Books.Include(x => x.Type).Select(x => new Book(x.Id,
                                                      x.Author,
                                                      x.Title,
                                                      new BookType(x.Type.Id, x.Type.TypeName)))
                                                      .AsNoTracking().ToListAsync();

            return books;
        }

        public async Task Delete(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
