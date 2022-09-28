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
            requestViewModel.Select(c => new RequestViewModel()
            {
                requestHeader = _context.RequestHeader.FirstOrDefault(),
                
            });

            return requestViewModel;
        }
    }
}
