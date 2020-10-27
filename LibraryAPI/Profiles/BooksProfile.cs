using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Models.Books;

namespace LibraryAPI.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            // Book -> GetBookDetailsResponse
            CreateMap<Book, GetBookDetailsResponse>();

            // Book -> GetBookDetailsItem
            CreateMap<Book, GetBooksResponseItem>();
        }
    }
}