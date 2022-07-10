using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class DataInserter
    {
        [Key]
        public int AdminID { get; set; }
        [MaxLength(20)]
        public string CreatedDate { get; set; }
        [MaxLength(20)]
        public string UpdateDate{ get; set; }
        public Boolean IsDeleted{ get; set; }
    }
}
