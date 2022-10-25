using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MookApi.Common;
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

            foreach (var item in requestViewModel)
            {
                item.delayDays = JalaliDate.getDay(item.requestFinishedDate) - JalaliDate.getDay(item.requestAcceptedDate) - 14;
                if (item.delayDays > 0)
                {
                    item.isDelayed = true;
                }
            }
            return requestViewModel;
        }

        public bool create(RequestViewModel requestViewModel)
        {
            try
            {

                var requestConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestHeader, RequestViewModel>();
                    cfg.CreateMap<RequestDetailViewModel, RequestDetails>();
                    cfg.CreateMap<StudentViewModel, Students>();
                    cfg.CreateMap<BookViewModel, Books>();
                });

                IMapper mapper = requestConfig.CreateMapper();

                RequestHeader requestHeader = new RequestHeader();
                RequestDetails requestDetails = new RequestDetails();

                requestHeader.RequestAcceptedDate = null;
                requestHeader.IsAccepted = false;
                requestHeader.RequestFinishedDate = null;
                requestHeader.RequestDecription = null;
                requestHeader.IsDeleted = false;
                requestHeader.StudentID = requestViewModel.studentID;
                requestHeader.createdDate = requestViewModel.createdDate;
                requestHeader.UpdateDate = requestViewModel.createdDate;
                _context.RequestHeader.Add(requestHeader);
                _context.SaveChanges();

                foreach (var item in requestViewModel.requestDetails)
                {
                    requestDetails = new RequestDetails
                    {
                        RequestHeaderID = _context.RequestHeader.Max(x => x.RequestID),
                        BookID = item.bookID,
                        RequestDetailDescription = item.requestDetailDescription,
                        IsDamaged = false,
                        IsLost = false,
                        createdDate = requestViewModel.createdDate,
                        UpdateDate = requestViewModel.createdDate
                    };
                    _context.RequestDetails.Add(requestDetails);
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
                    request.RequestAcceptedDate = JalaliDate.getDate(DateTime.Now);
                    request.RequestFinishedDate = JalaliDate.getDate(DateTime.Now.AddDays(14));
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
