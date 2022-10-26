using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MookApi.Models
{
    public class RequestHeader : DataInserter
    {
        [Key]
        public int requestID { get; set; }
        public int studentID { get; set; }
        public string? requestAcceptedDate { get; set; }
        public Boolean isAccepted { get; set; }
        public string? requestFinishedDate { get; set; }
        public string? requestDecription { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Admins admins { get; set; }
        public Students students { get; set; }
        public List<RequestDetails> requestDetails { get; set; }
        //done
    }
}
