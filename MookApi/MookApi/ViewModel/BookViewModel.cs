namespace MookApi.ViewModel
{
    public class BookViewModel
    {
        public int bookID { get; set; }
        public int AcceptedAdminID { get; set; }
        public string bookName { get; set; }
        public int bookPagesCount { get; set; }
        public float bookRating { get; set; }
        public string publisher { get; set; }
        public string author { get; set; }
        public int bookRatingCount { get; set; }
        public string bookDescription { get; set; }
        public Boolean isAvailable { get; set; }
        public Boolean isDamaged { get; set; }
        public string createdDate { get; set; }
    }
}
