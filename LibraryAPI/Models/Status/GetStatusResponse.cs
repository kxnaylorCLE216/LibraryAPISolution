using System;

namespace LibraryAPI.Models.Status
{
    public class GetStatusResponse
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}