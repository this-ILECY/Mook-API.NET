using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MookApi.Models
{
    public class Students : DataInserter
    {
        [Key]
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string StudentName { get; set; }
        public string StudentSSID { get; set; }
        public string StudentUniversityID { get; set; }
        public int SpamCount { get; set; }
        public bool IsSuspended { get; set; }
        public IsRegistered {get; set;}
        public bool IsBlocked { get; set; }
        public int reportPoint { get; set; }
        public bool IsSpam { get; set; }

        public Admins Admins { get; set; }
        public List<History> Historys { get; set; }
        public Users users { get; set; }
        public List<Comments> Comments { get; set; }
        public List<RequestHeader> RequestHeaders { get; set; }
        //done
    }
}
