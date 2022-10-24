using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

            List<CommentViewModel> commentViewModels = new List<CommentViewModel>();
            List<Comments> comments = new List<Comments>();
            comments = _context.Comments.Where(c => c.CommentFlag == true && c.IsAdminAccepted == false).Include(x=> x.Books).Include(x=>x.Students).ToList();

            var commentConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comments, CommentViewModel>();
                cfg.CreateMap<Students, StudentViewModel>();
                cfg.CreateMap<Books, BookViewModel>();
            });
           
            IMapper mapper = commentConfig.CreateMapper();

            commentViewModels = mapper.Map<List<CommentViewModel>>(comments);


            return commentViewModels;
        }

        public bool delete(int commentID)
        {
            try
            {
                Comments comments = new Comments();
                comments = _context.Comments.Where(c => c.CommentID == commentID).FirstOrDefault();

                if (comments != null)
                {
                    comments.IsDeleted = true;

                    _context.Comments.Update(comments);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Accept(int commentID)
        {
            try
            {
                Comments comments = new Comments();
                comments = _context.Comments.Where(c => c.CommentID == commentID).FirstOrDefault();

                if (comments != null)
                {
                    comments.IsAdminAccepted = true;

                    _context.Comments.Update(comments);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool create(CommentViewModel commentViewModel)
        {

            try
            {
                Comments comments = new Comments()
                {
                    IsDeleted = false,
                    AcceptedAdminID = 0,
                    FatherID = 0,
                    CommentLike = 0,
                    CommentDislike = 0,
                    CommentFlag = false,
                    IsAdminAccepted = commentViewModel.IsAdminAccepted,
                    UpdateDate = commentViewModel.createdDate,
                    createdDate = commentViewModel.createdDate,
                    CommentContent = commentViewModel.commentContent,
                    CommentHeader = commentViewModel.commentHeader,
                    Admins = _context.Admins.FirstOrDefault(c => c.AdminID == commentViewModel.AdminID),
                    Books = _context.Books.FirstOrDefault(c => c.bookID == commentViewModel.books.bookID),
                    Students = _context.Students.FirstOrDefault(c => c.StudentID == commentViewModel.students.StudentID)
                };

                _context.Comments.Add(comments);
                var res = _context.SaveChanges();
                if (res == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool update(CommentViewModel commentViewModel)
        {
            try
            {
                Comments comments = new Comments();
                comments = _context.Comments.FirstOrDefault(c => c.CommentID == commentViewModel.CommentID);

                comments.IsDeleted = false;
                comments.FatherID = 0;
                comments.CommentLike = 0;
                comments.CommentDislike = 0;
                comments.CommentFlag = false;
                comments.IsAdminAccepted = commentViewModel.IsAdminAccepted;
                comments.UpdateDate = commentViewModel.createdDate;
                comments.createdDate = commentViewModel.createdDate;
                comments.CommentContent = commentViewModel.commentContent;
                comments.CommentHeader = commentViewModel.commentHeader;
                comments.Admins = _context.Admins.FirstOrDefault(c => c.AdminID == commentViewModel.AdminID);
                comments.Books = _context.Books.FirstOrDefault(c => c.bookID == commentViewModel.books.bookID);
                comments.Students = _context.Students.FirstOrDefault(c => c.StudentID == commentViewModel.students.StudentID);

                _context.Comments.Update(comments);
                var res = _context.SaveChanges();
                if (res == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
