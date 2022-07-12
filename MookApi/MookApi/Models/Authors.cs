using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class Authors : DataInserter
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }

        public Admins AdminsFk { get; set; }
        public List<Books> Books { get; set; }
        public List<BookAuthors> BookAuthors { get; set; }
        //done
    }
}
