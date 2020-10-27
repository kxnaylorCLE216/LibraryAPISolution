using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryAPI.Data;
using LibraryAPI.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly LibraryDataContext _context;
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;

        public BooksController(LibraryDataContext context, MapperConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet("books/{id:int}")]
        public async Task<ActionResult> GetBookDetails(int id)
        {
            var response = await _context.Books
                .Where(b => b.Id == id && b.IsInInventory)
                .ProjectTo<GetBookDetailsResponse>(_config)
                .SingleOrDefaultAsync();

            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("books")]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await _context.Books
                .Where(book => book.IsInInventory == true)
                .ProjectTo<GetBooksResponseItem>(_config)
                .ToListAsync();

            var response = new GetBooksResponse
            {
                Data = books
            };

            return Ok(response);
        }
    }
}