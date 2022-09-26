using MookApi.Context;
using MookApi.Models;
using MookApi.ViewModel;

namespace MookApi.Service
{
    public class CommentDataService
    {
        private readonly AppDbContext _context;

        public CommentDataService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CommentViewModel> CommentList()
        {

            List<Comments> comments =
                _context.Comments.Select(c => new Comments()
                {
                    CommentID = c.CommentID,
                    FatherID = c.FatherID,
                    CommentContent = c.CommentContent,
                    Students = c.Students,
                    AcceptedAdminID = c.AcceptedAdminID,
                    Admins = c.Admins,
                    Books = c.Books,
                    CommentDislike = c.CommentDislike,
                    CommentFlag = c.CommentFlag,
                    CommentHeader = c.CommentHeader,
                    CommentLike = c.CommentLike,
                    CreatedDate = c.CreatedDate,
                    IsAdminAccepted = c.IsAdminAccepted,
                    IsDeleted = c.IsDeleted,
                    UpdateDate = c.UpdateDate
                }).ToList();

            IEnumerable<Students> students =
                _context.Students.Select(c => new Students()
                {
                    StudentID = c.StudentID,
                    StudentName = c.StudentName,
                    AcceptedAdminID = c.AcceptedAdminID,
                    Admins = c.Admins,
                    BooksTobuy = c.BooksTobuy,
                    Comments = c.Comments,
                    CreatedDate = c.CreatedDate,
                    Histories = c.Histories,
                    IsBlocked = c.IsBlocked,
                    IsDeleted = c.IsDeleted,
                    IsRegistered = c.IsRegistered,
                    IsSpam = c.IsSpam,
                    IsSuspended = c.IsSuspended,
                    reportPoint = c.reportPoint,
                    RequestHeaders = c.RequestHeaders,
                    SpamCount = c.SpamCount,
                    StudentSSID = c.StudentSSID,
                    StudentUniversityID = c.StudentUniversityID,
                    UpdateDate = c.UpdateDate,
                    users = c.users
                }).ToList().Where(x => comments.Any(s => s.Students.StudentID == x.StudentID));


            IEnumerable<CommentViewModel> commentViewModel = new List<CommentViewModel>();

            foreach (var item in comments)
            {
                commentViewModel.Append(new CommentViewModel()
                {
                    bookID = item.Books.BookID,
                    commentBody = item.CommentContent,
                    commentHeader = item.CommentHeader,
                    CommentID = item.CommentID,
                    createdDate = item.CreatedDate,
                    IsAdminAccepted = item.IsAdminAccepted,
                    student = students.Where(c=> item.Students.StudentID == c.StudentID).FirstOrDefault()
                });
            }

            return commentViewModel;
        }
    }
}
