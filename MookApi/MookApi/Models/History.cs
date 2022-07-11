namespace MookApi.Models
{
    public class History : DataInserter
    {
        public int HistoryID { get; set; }
        public int AdminID { get; set; }
        public int StudentID { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int TableID { get; set; }
        public int Date { get; set; }

        public Admins adminFk { get; set; }
        public Students students { get; set; }
        //done
    }
}
