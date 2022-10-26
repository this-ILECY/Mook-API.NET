namespace MookApi.Models
{
    public class BookToBuy: DataInserter
    {
        public int bookToBuyId{ get; set; }
        public string bookName { get; set; }
        public string bookAuthor { get; set; }
        public string bookPublisher { get; set; }

        public Students students { get; set; }
    }
}
