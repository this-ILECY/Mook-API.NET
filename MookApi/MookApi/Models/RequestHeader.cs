using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class RequestHeader : DataInserter
    {
        [Key]
        public int RequestID { get; set; }
        public int StudentID { get; set; }
        public string RequestAcceptedDate { get; set; }
        public Boolean IsAccepted { get; set; }
        public string RequestFinishedDate { get; set; }
        public int IsDelayed { get; set; }
        public string RequestDecription { get; set; }

        public Admins Admins { get; set; }
        public Students students { get; set; }
        public List<RequestDetails> RequestDetails { get; set; }
        //done
    }
}
