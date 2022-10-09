using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

            List<RequestViewModel> requestViewModel = new List<RequestViewModel>();

            var requestConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestHeader, RequestViewModel>();
                cfg.CreateMap<RequestDetails, RequestDetailViewModel>();
                cfg.CreateMap<Books, BookViewModel>();
                cfg.CreateMap<Students, StudentViewModel>();
            });

            IMapper mapper = requestConfig.CreateMapper();

            List<RequestHeader> requestHeaders = new List<RequestHeader>();
            requestHeaders = _context.RequestHeader.Include(x => x.RequestDetails).ThenInclude(x => x.Books).Include(x => x.students).Include(x => x.Admins).ToList();

            requestViewModel = mapper.Map<List<RequestViewModel>>(requestHeaders);


            return requestViewModel;
        }
    }
}
