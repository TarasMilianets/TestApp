using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.DAL.Repositories.Abstractions
{
    public interface IBookTypesRepository
    {
        Task<IEnumerable<BookType>> GetBookTypesAsync();
    }
}
