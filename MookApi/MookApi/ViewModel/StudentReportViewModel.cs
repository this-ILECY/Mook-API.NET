namespace MookApi.ViewModel
{
    public class StudentReportViewModel
    {
        public StudentViewModel students { get; set; }
        public int RequestCount { get; set; }
        public int RequsetDelayCount { get; set; }
        public string LongestDelay { get; set; }
        public int BookRent { get; set; }
        public int BookDamaged { get; set; }
        public int BookLost { get; set; }
        public string CreatedDate { get; set; }
    }
}
