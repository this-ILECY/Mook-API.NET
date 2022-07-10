namespace MookApi.Models
{
    public class RequestHeader : DataInserter
    {
        public int RequestID { get; set; }
        public int StudentID { get; set; }
        public string RequestAcceptedDate { get; set; }
        public Boolean IsAccepted { get; set; }
        public string RequestFinishedDate { get; set; }
        public int IsDelayed { get; set; }
        public string RequestDecription { get; set; }
    }
}
