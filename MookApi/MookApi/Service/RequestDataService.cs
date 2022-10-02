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
            List<RequestHeader> requestHeaders = new List<RequestHeader>();

            List<RequestViewModel> requestViewModel = new List<RequestViewModel>();
            requestViewModel = _context.RequestHeader.Select(c => new RequestViewModel()
            {
                createdDate = c.CreatedDate,
                DelayDays = c.DelayDays,
                IsAccepted = c.IsAccepted,
                IsDelayed = c.IsDelayed,
                RequestAcceptedDate = c.RequestAcceptedDate,
                RequestDecription=c.RequestDecription,
                requestDetails=c.RequestDetails,
                RequestFinishedDate=c.RequestFinishedDate,
                RequestID=c.RequestID,
                students=c.students
            }).ToList();

            return requestViewModel;
        }
    }
}
