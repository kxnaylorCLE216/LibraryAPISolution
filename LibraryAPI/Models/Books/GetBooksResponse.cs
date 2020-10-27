using System.Collections.Generic;

namespace LibraryAPI.Models.Books
{
    public class GetBooksResponse
    {
        public List<GetBooksResponseItem> Data { get; set; }
    }
}