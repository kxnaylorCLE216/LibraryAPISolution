using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryAPI.Data;
using LibraryAPI.Models.Books;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("books")]
        public async Task<ActionResult<GetBookDetailsResponse>> AddBook([FromBody] PostBookRequest bookToAdd)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var book = _mapper.Map<Book>(bookToAdd);
                _context.Books.Add(book);

                await _context.SaveChangesAsync();

                var response = _mapper.Map<GetBookDetailsResponse>(book);


                return CreatedAtRoute("books#getbookdetails", new { id = response.Id }, response);
            }

        }

        /// <summary>
        /// This allows you to look up a book from our inventory by providing the ID of the book
        /// </summary>
        /// <param name="id">The id of the book</param>
        /// <returns>The book that matches that request, or a 404</returns>
        [HttpGet("books/{id:int}", Name = "books#getbookdetails")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetBookDetailsResponse>> GetBookDetails(int id)
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
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetBooksResponseItem>> GetAllBooks()
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