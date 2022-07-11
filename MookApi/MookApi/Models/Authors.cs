namespace MookApi.Models
{
    public class Authors : DataInserter
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }

        public Admins AdminsFk { get; set; }
        public List<Books> Books { get; set; }
        //done
    }
}
