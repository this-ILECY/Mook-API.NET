using MookApi.Models;
using System;

namespace MookApi.ViewModel
{
    public class CommentViewModel
    {

        public int CommentID { get; set; }
        public int AdminID { get; set; }

        public Books book { get; set; }
        public Students? student { get; set; }
        public string? commentHeader { get; set; }
        public string? commentContent { get; set; }
        public Boolean IsAdminAccepted { get; set; }
        public string? createdDate { get; set; }
    }
}
