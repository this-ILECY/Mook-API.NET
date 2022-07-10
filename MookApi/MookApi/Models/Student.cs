using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Student: DataInserter
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }        
        public string StudentSSID { get; set; }
        public int StudentUniversityID { get; set; }

    }
}
