using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class RequestDetails : DataInserter
    {
        [Key]
        public int requestDetailID { get; set; }
        public int requestHeaderID { get; set; }
        public int bookID { get; set; }
        public string? requestDetailDescription { get; set; }
        public Boolean? isDamaged { get; set; }
        public Boolean? isLost { get; set; }

        public Books books { get; set; }
        public RequestHeader requestHeader { get; set; }
    }
}
