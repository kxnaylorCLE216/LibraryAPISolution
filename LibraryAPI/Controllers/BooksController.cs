using LibraryAPI.Data;
using LibraryAPI.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly LibraryDataContext _context;

        public BooksController(LibraryDataContext context)
        {
            _context = context;
        }

        [HttpGet("books/{id:int}")]
        public async Task<ActionResult> GetBookDetails(int id)
        {
            var response = await _context.Books
                .Where(b => b.Id == id && b.IsInInventory)
                .Select(b => new GetBookDetailsResponse
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    AddedToInventory = b.AddedToInventory,
                    Genre = b.Genre
                }).SingleOrDefaultAsync();

            if(response == null)
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
                .Select(book => new GetBooksResponseItem
                { 
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    Genre= book.Genre
                })
                .ToListAsync();

            var response = new GetBooksResponse
            {
                Data = books
            };

            return Ok(response);
        }
    }
}
