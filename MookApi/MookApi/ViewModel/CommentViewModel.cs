using MookApi.Models;
using System;

namespace MookApi.ViewModel
{
    public class CommentViewModel
    {

        public int commentID { get; set; }
        public int adminID { get; set; }

        public BookViewModel books { get; set; }
        public StudentViewModel? students { get; set; }
        public string? commentHeader { get; set; }
        public string? commentContent { get; set; }
        public Boolean isAdminAccepted { get; set; }
        public string? createdDate { get; set; }
    }
}
