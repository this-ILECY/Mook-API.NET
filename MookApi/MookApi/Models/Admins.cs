using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Admins : DataInserter
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminName { get; set; }

        public List<History> HistoryFk { get; set; }
        public List<Students> StudentsFk { get; set; }
        public List<Books> BooksFk { get; set; }
        public List<RequestHeader> RequestHeaderFk { get; set; }
        public List<Comments> CommentsFk { get; set; }
        public Users UsersFk { get; set; }
        //done
    }
}
