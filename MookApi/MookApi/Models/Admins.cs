﻿namespace MookApi.Models
{
    public class Admins : DataInserter
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }

        public List<Authors> AuthorsFk { get; set; }
        public List<History> HistoryFk { get; set; }
        public List<Students> StudentsFk { get; set; }
        public List<Publishers> PublishersFk { get; set; }
        public List<Books> BooksFk { get; set; }
        public List<RequestHeader> RequestHeaderFk { get; set; }
        public List<Comments> CommentsFk { get; set; }
        public List<Users> UsersFk { get; set; }
        //done
    }
}
