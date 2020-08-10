using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.DAL.Repositories.Abstractions;
using TestApp.Models;

namespace TestApp.DAL.Repositories
{
    public class BookTypesRepository : IBookTypesRepository
    {
        private DBContext _context;

        public BookTypesRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookType>> GetBookTypesAsync()
        {
            var types = await _context.Types.Select(x => new BookType(x.Id, x.TypeName)).ToListAsync();

            return types;
        }
    }
}
