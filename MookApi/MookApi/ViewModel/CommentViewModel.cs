using MookApi.Models;
using System;

namespace MookApi.ViewModel
{
    public class CommentViewModel
    {

        public int CommentID { get; set; }
        public int bookID { get; set; }
        public Students? student { get; set; }
        public string? commentHeader { get; set; }
        public string? commentBody { get; set; }
        public Boolean IsAdminAccepted { get; set; }
        public string? createdDate { get; set; }
    }
}
