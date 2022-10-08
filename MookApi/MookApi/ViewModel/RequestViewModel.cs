using MookApi.Models;

namespace MookApi.ViewModel
{
    public class RequestViewModel
    {
        public int RequestID { get; set; }
        public string? RequestAcceptedDate { get; set; }
        public Boolean IsAccepted { get; set; }
        public string? RequestFinishedDate { get; set; }
        public Boolean IsDelayed { get; set; }
        public int? DelayDays { get; set; }
        public string? RequestDecription { get; set; }
        public string? createdDate { get; set; }
        public Boolean? IsDeleted { get; set; }
        
        public List<RequestDetailViewModel> requestDetails{ get; set; }
        public Students students { get; set; }
    }

    public class RequestDetailViewModel
    {
        public int RequestDetailID { get; set; }
        public int RequestHeaderID { get; set; }
        public List<BookViewModel> Books { get; set; }
        public string? RequestDetailDescription { get; set; }
        public Boolean? IsDamaged { get; set; }
        public Boolean? IsLost { get; set; }
    }
}
