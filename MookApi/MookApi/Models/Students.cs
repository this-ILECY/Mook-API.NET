using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MookApi.Models
{
    public class Students : DataInserter
    {
        [Key]
        public int studentID { get; set; }
        public long userID { get; set; }
        public string studentName { get; set; }
        public string studentSSID { get; set; }
        public string studentUniversityID { get; set; }
        public int spamCount { get; set; }
        public bool isSuspended { get; set; }
        public bool isRegistered {get; set;}
        public bool isBlocked { get; set; }
        public int reportPoint { get; set; }
        public bool isSpam { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Admins admins { get; set; }
        public List<History> histories { get; set; }
        public List<BookToBuy> booksTobuy { get; set; }
        public Users users { get; set; }
        public List<Comments> comments { get; set; }
        public List<RequestHeader> requestHeaders { get; set; }
        //done
    }
}
