namespace MookApi.Models
{
    public class Publishers : DataInserter
    {
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }
        public string PublisherPhone { get; set; }
        public string publisherAddress { get; set; }

        public Admins Admins { get; set; }
        public List<Books> Books { get; set; }
        //done
    }
}
