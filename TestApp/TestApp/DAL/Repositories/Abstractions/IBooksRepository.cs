using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DAL.Repositories.Abstractions
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task CreateBook(BookCreateRequest request);
        Task Delete(int id);
    }
}
