using MookApi.Context;
using MookApi.Models;
using MookApi.ViewModel;
using System.Linq;

namespace MookApi.Service
{
    public class RequestDataService
    {
        private readonly AppDbContext _context;

        public RequestDataService(AppDbContext context)
        {
            _context = context;
        }

        public List<RequestViewModel> get()
        {

            List<RequestHeader> requestHeaders = new List<RequestHeader>();
            requestHeaders = _context.RequestHeader.Select(c=> new RequestHeader()
            {
                AcceptedAdminID=c.AcceptedAdminID,
                Admins = c.Admins,
                CreatedDate = c.CreatedDate,
                DelayDays = c.DelayDays,
                IsAccepted = c.IsAccepted,
                IsDelayed = c.IsDelayed,
                IsDeleted = c.IsDeleted,
                RequestAcceptedDate = c.RequestAcceptedDate,
                RequestDetails = c.RequestDetails.Select(d=> new RequestDetails()
                {
                    RequestDetailID=d.RequestDetailID,
                    IsLost=d.IsLost,
                    IsDamaged=d.IsDamaged,
                    IsDeleted=d.IsDeleted,
                    RequestDetailDescription=d.RequestDetailDescription,
                    CreatedDate=d.CreatedDate,
                    RequestHeader=d.RequestHeader,
                    BookID=d.BookID,
                    Books=d.Books,
                    UpdateDate=d.UpdateDate,
                    AcceptedAdminID= d.AcceptedAdminID
                }).ToList(),
                RequestFinishedDate = c.RequestFinishedDate,
                RequestDecription = c.RequestDecription,
                RequestID = c.RequestID,
                students = c.students,
                UpdateDate=c.UpdateDate
            }).Where(f => f.IsDeleted == false).ToList();
            List<Students> students = new List<Students>();

            List<RequestViewModel> requestViewModel = new List<RequestViewModel>();
            
            foreach (var member in requestHeaders)
            {
                requestViewModel.Add(new RequestViewModel()
                {
                    students = member.students,
                    requestDetails = member.RequestDetails.Select(m => new RequestDetailViewModel()
                    {
                        Books = m.Books.Select(f=> new BookViewModel()
                        {
                            BookID=f.BookID,
                            BookDescription=f.BookDescription,
                            BookName=f.BookName,
                            Author=f.Author,
                            BookPagesCount=f.BookPagesCount,
                            BookRating=f.BookRating,
                            BookRatingCount=f.BookRatingCount,
                            IsAvailable=f.IsAvailable,
                            IsDamaged=f.IsDamaged,
                            publisher=f.publisher
                        }).ToList(),
                        IsDamaged = m.IsDamaged,
                        IsLost = m.IsLost,
                        RequestDetailDescription = m.RequestDetailDescription,
                        RequestDetailID = m.RequestDetailID,
                        RequestHeaderID = m.RequestHeader.RequestID
                    }).ToList(),
                    DelayDays = member.DelayDays,
                    IsAccepted = member.IsAccepted,
                    RequestAcceptedDate = member.RequestAcceptedDate,
                    IsDelayed = member.IsDelayed,
                    RequestDecription = member.RequestDecription,
                    RequestID = member.RequestID,
                    RequestFinishedDate = member.RequestFinishedDate
                });
            }

            return requestViewModel;
        }
    }
}
