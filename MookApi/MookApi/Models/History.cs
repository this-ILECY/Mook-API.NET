using MookApi.Context;
using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class History : DataInserter
    {

        [Key]
        public int historyID { get; set; }
        public string tableName { get; set; }
        public string columnName { get; set; }
        public string columnChanged { get; set; }
        public int tableID { get; set; }
        public int date { get; set; }

        public Admins admin { get; set; }
        public Students students { get; set; }
        //done

    }
}
