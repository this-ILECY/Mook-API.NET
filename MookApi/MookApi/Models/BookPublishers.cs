using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class BookPublishers
    {
        [Key]
        public int BookPublishersID { get; set; }
        public int BookID { get; set; }
        public int PublisherID { get; set; }

        public Publishers publishers { get; set; }
        public Books books { get; set; }
    }
}
