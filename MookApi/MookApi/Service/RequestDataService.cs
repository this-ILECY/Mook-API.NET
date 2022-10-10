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

        public bool Accept(int id)
        {
            try
            {
                RequestHeader request = new RequestHeader();
                request = _context.RequestHeader.Where(c => c.RequestID == id)
                    .Include(x => x.Admins).Include(x => x.students).Include(x => x.RequestDetails).ThenInclude(x => x.Books).FirstOrDefault();

                if (request != null)
                {
                    //don`t forget accepted adminID
                    request.IsAccepted = true;

                    _context.RequestHeader.Update(request);
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

        public bool Delete(int id)
        {
            try
            {
                RequestHeader request = new RequestHeader();
                request = _context.RequestHeader.Where(c => c.RequestID == id).FirstOrDefault();

                if (request != null)
                {
                    request.IsDeleted = true;

                    _context.RequestHeader.Update(request);
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


    }
}
