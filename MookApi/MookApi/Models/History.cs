using MookApi.Context;
using System.ComponentModel.DataAnnotations;

namespace MookApi.Models
{
    public class History : DataInserter
    {

        [Key]
        public int HistoryID { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string ColumnChanged { get; set; }
        public int TableID { get; set; }
        public int Date { get; set; }

        public Admins adminFk { get; set; }
        public Students students { get; set; }
        //done

    }
}
