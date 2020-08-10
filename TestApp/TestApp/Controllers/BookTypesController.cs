using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.DAL.Repositories.Abstractions;
using TestApp.Models;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypesController : ControllerBase
    {
        private readonly IBookTypesRepository _bookTypesRepository;

        public BookTypesController(IBookTypesRepository bookTypesRepository)
        {
            _bookTypesRepository = bookTypesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<BookType>> Get()
        {
            var result = await _bookTypesRepository.GetBookTypesAsync();

            return result;
        }
    }
}