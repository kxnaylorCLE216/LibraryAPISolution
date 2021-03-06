﻿using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Books
{
    public class PostBookRequest
    {
        [Required][MaxLength(200)]
        public string Title { get; set; }
        [Required][MaxLength(200)]
        public string Author { get; set; }
        [Required] 
        public string Genre { get; set; }
    }
}