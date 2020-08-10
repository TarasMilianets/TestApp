using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.DAL.Repositories.Abstractions;
using TestApp.Models;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            var result = await _booksRepository.GetBooksAsync();

            return result;
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> Post(BookCreateRequest request)
        {
            await _booksRepository.CreateBook(request);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _booksRepository.Delete(id);

            return NoContent();
        }
    }
}
