using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Admins : DataInserter
    {
        [Key]
        public int adminID { get; set; }
        public long userID { get; set; }
        public string adminName { get; set; }

        public List<History> history { get; set; }
        public List<Students> students { get; set; }
        public List<Books> books { get; set; }
        public List<RequestHeader> requestHeader { get; set; }
        public List<Comments> comments { get; set; }
        public Users users { get; set; }
        //done
    }
}
