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
            comments = _context.Comments.Where(c => c.commentFlag == true && c.isAdminAccepted == false).Include(x=> x.books).Include(x=>x.students).ToList();

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
                comments = _context.Comments.Where(c => c.commentID == commentID).FirstOrDefault();

                if (comments != null)
                {
                    comments.isDeleted = true;

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
                comments = _context.Comments.Where(c => c.commentID == commentID).FirstOrDefault();

                if (comments != null)
                {
                    comments.isAdminAccepted = true;

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
                    isDeleted = false,
                    acceptedAdminID = 0,
                    fatherID = 0,
                    commentLike = 0,
                    commentDislike = 0,
                    commentFlag = false,
                    isAdminAccepted = commentViewModel.isAdminAccepted,
                    updateDate = commentViewModel.createdDate,
                    createdDate = commentViewModel.createdDate,
                    commentContent = commentViewModel.commentContent,
                    commentHeader = commentViewModel.commentHeader,
                    admins = _context.Admins.FirstOrDefault(c => c.adminID == commentViewModel.adminID),
                    books = _context.Books.FirstOrDefault(c => c.bookID == commentViewModel.books.bookID),
                    students = _context.Students.FirstOrDefault(c => c.studentID == commentViewModel.students.studentID)
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
                comments = _context.Comments.FirstOrDefault(c => c.commentID == commentViewModel.commentID);

                comments.isDeleted = false;
                comments.fatherID = 0;
                comments.commentLike = 0;
                comments.commentDislike = 0;
                comments.commentFlag = false;
                comments.isAdminAccepted = commentViewModel.isAdminAccepted;
                comments.updateDate = commentViewModel.createdDate;
                comments.createdDate = commentViewModel.createdDate;
                comments.commentContent = commentViewModel.commentContent;
                comments.commentHeader = commentViewModel.commentHeader;
                comments.admins = _context.Admins.FirstOrDefault(c => c.adminID == commentViewModel.adminID);
                comments.books = _context.Books.FirstOrDefault(c => c.bookID == commentViewModel.books.bookID);
                comments.students = _context.Students.FirstOrDefault(c => c.studentID == commentViewModel.students.studentID);

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
