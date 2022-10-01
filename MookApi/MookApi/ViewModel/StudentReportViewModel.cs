namespace MookApi.ViewModel
{
    public class StudentReportViewModel
    {
        public string name { get; set; }
        public string SID { get; set; }
        public string UniID { get; set; }
        public int RequestCount { get; set; }
        public int DelayedCount { get; set; }
        public string TopDelay { get; set; }
        public int bookCount { get; set; }
        public int DamagedBookCount { get; set; }
        public int LostBookCount{ get; set; }
        public string RegisterDate{ get; set; }
    }
}
