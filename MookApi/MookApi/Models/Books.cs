namespace MookApi.Models
{
    public class Books : DataInserter
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPagesCount { get; set; }
        public float BookRating { get; set; }
        public int BookRatingCount { get; set; }
        public string BookDescription { get; set; }

        public List<Authors> Authors { get; set; }
        public List<Publishers> Publishers { get; set; }
        public Admins Admins { get; set; }
        public List<RequestDetails> RequestDetails { get; set; }
        public List<Comments> Comments { get; set; }
        //done
    }
}
