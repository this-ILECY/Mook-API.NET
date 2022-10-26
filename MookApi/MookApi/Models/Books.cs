using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MookApi.Models
{
    public class Books : DataInserter
    {
        [Key]
        public int bookID { get; set; }
        public string bookName { get; set; }
        public int bookPagesCount { get; set; }
        public float bookRating { get; set; }
        public string publisher { get; set; }
        public string author { get; set; }
        public int bookRatingCount { get; set; }
        public string bookDescription { get; set; }
        public Boolean isAvailable { get; set;}
        public Boolean isDamaged {get; set;}


        [JsonIgnore]
        [IgnoreDataMember]
        public Admins admins { get; set; }
        public List<RequestDetails> requestDetails { get; set; }
        public List<Comments> comments { get; set; }

        //done
    }
}
