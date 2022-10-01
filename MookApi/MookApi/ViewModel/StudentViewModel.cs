namespace MookApi.ViewModel
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSSID { get; set; }
        public string StudentUniversityID { get; set; }
        public int SpamCount { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsRegistered { get; set; }
        public string CreatedDate { get; set; }
        public bool IsBlocked { get; set; }
        public int reportPoint { get; set; }
        public bool IsSpam { get; set; }
    }
}
