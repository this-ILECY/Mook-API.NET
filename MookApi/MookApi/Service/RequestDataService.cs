using MookApi.Context;
using MookApi.Models;
using MookApi.ViewModel;

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
            List<RequestViewModel> requestViewModel = new List<RequestViewModel>();

            List<RequestHeader> requestHeaders = new List<RequestHeader>();
            List<Students> students = new List<Students>();


            requestHeaders = _context.RequestHeader.Select(c => new RequestHeader()
            {
                students = c.students,
                AcceptedAdminID = c.AcceptedAdminID,
                IsDeleted = c.IsDeleted,
                Admins = c.Admins,
                CreatedDate = c.CreatedDate,
                DelayDays = c.DelayDays,
                IsAccepted = c.IsAccepted,
                IsDelayed = c.IsDelayed,
                RequestAcceptedDate = c.RequestAcceptedDate,
                RequestDecription = c.RequestDecription,
                RequestDetails = c.RequestDetails,
                RequestFinishedDate = c.RequestFinishedDate,
                RequestID = c.RequestID,
                UpdateDate = c.UpdateDate
            }).Where(f => f.IsDeleted == false).ToList();

            foreach (var member in requestHeaders)
            {
                requestViewModel.Add(new RequestViewModel()
                {
                    students = member.students,
                    requestDetails = member.RequestDetails.Select(x => new RequestDetailViewModel()
                    {
                        IsDamaged = x.IsDamaged,
                        IsLost = x.IsLost,
                        RequestDetailDescription = x.RequestDetailDescription,
                        RequestDetailID = x.RequestDetailID,
                        BookID = x.BookID,
                        RequestHeaderID = member.RequestID
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
