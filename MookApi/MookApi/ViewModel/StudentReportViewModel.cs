namespace MookApi.ViewModel
{
    public class StudentReportViewModel
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public string studentSSID { get; set; }
        public string studentUniversityID { get; set; }
        public int requestCount { get; set; }
        public int requsetDelayCount { get; set; }
        public int BookRent { get; set; }
        public int bookDamaged { get; set; }
        public int bookLost { get; set; }
        public string createdDate { get; set; }
    }
}
