using AutoMapper;
using Azure.Core;
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
            requestHeaders = _context.RequestHeader.Include(x => x.requestDetails).ThenInclude(x => x.books).Include(x => x.students).Include(x => x.admins).ToList();

            requestViewModel = mapper.Map<List<RequestViewModel>>(requestHeaders);

            foreach (var item in requestViewModel)
            {
                Delay getDelay = JalaliDate.getIsDelay(null, item);
                item.isDelayed = getDelay.isDelayed;
                item.delayDays = getDelay.delayDays;
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

                requestHeader.requestAcceptedDate = null;
                requestHeader.isAccepted = false;
                requestHeader.requestFinishedDate = null;
                requestHeader.requestDecription = null;
                requestHeader.isDeleted = false;
                requestHeader.studentID = requestViewModel.studentID;
                requestHeader.createdDate = requestViewModel.createdDate;
                requestHeader.updateDate = requestViewModel.createdDate;
                _context.RequestHeader.Add(requestHeader);
                _context.SaveChanges();

                foreach (var item in requestViewModel.requestDetails)
                {
                    requestDetails = new RequestDetails
                    {
                        requestHeaderID = _context.RequestHeader.Max(x => x.requestID),
                        bookID = item.bookID,
                        requestDetailDescription = item.requestDetailDescription,
                        isDamaged = false,
                        isLost = false,
                        createdDate = requestViewModel.createdDate,
                        updateDate = requestViewModel.createdDate
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
                request = _context.RequestHeader.Where(c => c.requestID == id)
                    .Include(x => x.admins).Include(x => x.students).Include(x => x.requestDetails).ThenInclude(x => x.books).FirstOrDefault();

                if (request != null)
                {
                    //don`t forget accepted adminID
                    request.isAccepted = true;
                    request.requestAcceptedDate = JalaliDate.getDate(DateTime.Now);
                    request.requestFinishedDate = JalaliDate.getDate(DateTime.Now.AddDays(14));
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
                request = _context.RequestHeader.Where(c => c.requestID == id).FirstOrDefault();

                if (request != null)
                {
                    request.isDeleted = true;

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
