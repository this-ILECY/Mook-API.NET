using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class RequestDetails : DataInserter
    {
        [Key]
        public int RequestDetailID { get; set; }
        public string RequestDetailDescription { get; set; }
        public Boolean IsDamaged { get; set; }
        public Boolean IsLost { get; set; }

        public Books Books { get; set; }
        public RequestHeader RequestHeader { get; set; }
    }
}
