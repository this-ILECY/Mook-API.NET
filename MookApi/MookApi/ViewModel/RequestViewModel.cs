using MookApi.Models;

namespace MookApi.ViewModel
{
    public class RequestViewModel
    {
        public int requestID { get; set; }
        public int studentID { get; set; }
        public string? requestAcceptedDate { get; set; }
        public Boolean isAccepted { get; set; }
        public string? requestFinishedDate { get; set; }
        public Boolean isDelayed { get; set; }
        public int? delayDays { get; set; }
        public string? requestDecription { get; set; }
        public string? createdDate { get; set; }
        public Boolean? IsDeleted { get; set; }
        
        public List<RequestDetailViewModel> requestDetails{ get; set; }
        public StudentViewModel students { get; set; }
    }

    public class RequestDetailViewModel
    {
        public int requestDetailID { get; set; }
        public int requestHeaderID { get; set; }
        public int bookID { get; set; }
        public BookViewModel books { get; set; }
        public string? requestDetailDescription { get; set; }
        public Boolean? isDamaged { get; set; }
        public Boolean? isLost { get; set; }
    }

    public class Delay
    {
        public bool IsDelayed{ get; set; }
        public int DelayDays { get; set; }
    }
}
