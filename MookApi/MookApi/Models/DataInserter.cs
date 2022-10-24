using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class DataInserter
    {
        public int? AcceptedAdminID { get; set; }
        [MaxLength(20)]
        public string createdDate { get; set; }
        [MaxLength(20)]
        public string? UpdateDate{ get; set; }
        public Boolean IsDeleted{ get; set; }
    }
}
