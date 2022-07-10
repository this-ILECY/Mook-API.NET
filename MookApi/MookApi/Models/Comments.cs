namespace MookApi.Models
{
    public class Comments : DataInserter
    {
        public int CommentID { get; set; }
        public int StudentID { get; set; }
        public int BookID { get; set; }
        public int FatherID { get; set; }
        public string CommentHeader { get; set; }
        public string CommentContent { get; set; }
        public float CommentLike { get; set; }
        public float CommentDislike { get; set; }
        public Boolean CommentFlag { get; set; }
    }
}
