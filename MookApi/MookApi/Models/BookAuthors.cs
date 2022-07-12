using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class BookAuthors
    {
        [Key]
        public int BookAuthorsID { get; set; }
        public int BookID { get; set; }
        public int AuthorID { get; set; }

        public Books books { get; set; }
        public Authors authors { get; set; }
    }
}
