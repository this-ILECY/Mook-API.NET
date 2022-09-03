using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Books : DataInserter
    {
        [Key]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPagesCount { get; set; }
        public float BookRating { get; set; }
        public int BookRatingCount { get; set; }
        public string BookDescription { get; set; }
        public string IsAvailable { get; set;}

        public List<Publishers> Publishers { get; set; }
        public Admins Admins { get; set; }
        public List<RequestDetails> RequestDetails { get; set; }
        public List<Comments> Comments { get; set; }

        public List<BookPublishers> BookPublishers { get; set; }
        //done
    }
}
