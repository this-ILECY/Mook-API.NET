using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Comments : DataInserter
    {
        [Key]
        public int CommentID { get; set; }
        public int FatherID { get; set; }
        public string CommentHeader { get; set; }
        public string CommentContent { get; set; }
        public float CommentLike { get; set; }
        public float CommentDislike { get; set; }
        public Boolean CommentFlag { get; set; }
        public Boolean IsAdminAccepted { get; set; }

        public Admins Admins { get; set; }
        public Students Students { get; set; }
        public Books Books { get; set; }
        //done
    }
}
