using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Students : DataInserter
    {
        public int StudentID { get; set; }
        public int UserID { get; set; }
        public string StudentName { get; set; }
        public string StudentSSID { get; set; }
        public int StudentUniversityID { get; set; }

        public Admins Admins { get; set; }
        public List<History> Historys { get; set; }
        public Users Users { get; set; }
        public List<Comments> Comments { get; set; }
        public List<RequestHeader> RequestHeaders { get; set; }
        //done
    }
}
