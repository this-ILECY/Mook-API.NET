using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class DataInserter
    {
        public int? acceptedAdminID { get; set; }
        [MaxLength(20)]
        public string createdDate { get; set; }
        [MaxLength(20)]
        public string? updateDate{ get; set; }
        public Boolean isDeleted{ get; set; }
    }
}
