namespace MookApi.ViewModel
{
    public class StudentViewModel
    {
        public int studentID { get; set; }
        public int acceptedAdminID { get; set; }
        public string studentName { get; set; }
        public string studentSSID { get; set; }
        public string studentUniversityID { get; set; }
        public int spamCount { get; set; }
        public bool isSuspended { get; set; }
        public bool isRegistered { get; set; }
        public string createdDate { get; set; }
        public bool isBlocked { get; set; }
        public int reportPoint { get; set; }
        public bool isSpam { get; set; }
        public bool isDeleted { get; set; }
        
    }
}
