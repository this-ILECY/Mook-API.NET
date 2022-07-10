namespace MookApi.Models
{
    public class Book : DataInserter
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPagesCount { get; set; }
        public float BookRating { get; set; }
        public int BookRatingCount { get; set; }
        public string BookDescription { get; set; }
    }
}
