using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Comments : DataInserter
    {
        [Key]
        public int commentID { get; set; }
        public int fatherID { get; set; }
        public int bookID { get; set; }
        public string commentHeader { get; set; }
        public string commentContent { get; set; }
        public float commentLike { get; set; }
        public float commentDislike { get; set; }
        public Boolean commentFlag { get; set; }
        public Boolean isAdminAccepted { get; set; }

        public Admins admins { get; set; }
        public Students students { get; set; }
        public Books books { get; set; }
        //done
    }
}
