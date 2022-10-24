﻿using AutoMapper;
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
                List<RequestDetails> requestDetails = new List<RequestDetails>();

                requestHeader.RequestAcceptedDate = null;
                requestHeader.IsAccepted = false;
                requestHeader.RequestFinishedDate = null;
                requestHeader.IsDelayed = false;
                requestHeader.DelayDays = 0;
                requestHeader.RequestDecription = null;
                requestHeader.IsDeleted = false;
                requestHeader.students = mapper.Map<Students>(requestViewModel.students);
                requestHeader.RequestDetails = mapper.Map<List<RequestDetails>>(requestViewModel.requestDetails);

               _context.Add(requestHeader);
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
