using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MookApi.Models
{
    public class Books : DataInserter
    {
        [Key]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPagesCount { get; set; }
        public float BookRating { get; set; }
        public string publisher { get; set; }
        public string Author { get; set; }
        public int BookRatingCount { get; set; }
        public string BookDescription { get; set; }
        public Boolean IsAvailable { get; set;}
        public Boolean IsDamaged {get; set;}


        [JsonIgnore]
        [IgnoreDataMember]
        public Admins Admins { get; set; }
        public List<RequestDetails> RequestDetails { get; set; }
        public List<Comments> Comments { get; set; }

        //done
    }
}
