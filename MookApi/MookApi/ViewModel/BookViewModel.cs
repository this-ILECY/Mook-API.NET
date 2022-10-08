namespace MookApi.ViewModel
{
    public class BookViewModel
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int BookPagesCount { get; set; }
        public float BookRating { get; set; }
        public string publisher { get; set; }
        public string Author { get; set; }
        public int BookRatingCount { get; set; }
        public string BookDescription { get; set; }
        public string IsAvailable { get; set; }
        public Boolean IsDamaged { get; set; }
    }
}
