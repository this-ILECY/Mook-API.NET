namespace MookApi.ViewModel
{
    public class StudentReportViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSSID { get; set; }
        public string StudentUniversityID { get; set; }
        public int RequestCount { get; set; }
        public int RequsetDelayCount { get; set; }
        public int BookRent { get; set; }
        public int BookDamaged { get; set; }
        public int BookLost { get; set; }
        public string CreatedDate { get; set; }
    }
}
