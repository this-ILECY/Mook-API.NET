using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MookApi.Models
{
    public class RequestHeader : DataInserter
    {
        [Key]
        public int RequestID { get; set; }
        public int StudentID { get; set; }
        public string? RequestAcceptedDate { get; set; }
        public Boolean IsAccepted { get; set; }
        public string? RequestFinishedDate { get; set; }
        public string? RequestDecription { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Admins Admins { get; set; }
        public Students students { get; set; }
        public List<RequestDetails> RequestDetails { get; set; }
        //done
    }
}
