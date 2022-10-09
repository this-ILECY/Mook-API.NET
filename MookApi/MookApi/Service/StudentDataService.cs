using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MookApi.Context;
using MookApi.Models;
using MookApi.ViewModel;

namespace MookApi.Service
{
    public class StudentDataService
    {
        private readonly AppDbContext _context;

        public StudentDataService(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentReportViewModel> getReport()
        {

            var studentConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RequestHeader, StudentReportViewModel>();
                cfg.CreateMap<RequestDetails, RequestDetailViewModel>();
                cfg.CreateMap<Books, BookViewModel>();
                cfg.CreateMap<Students, StudentViewModel>();
            });

            IMapper mapper = studentConfig.CreateMapper();


            List<StudentReportViewModel> reportList = new List<StudentReportViewModel>();

            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();
            List<Students> students = new List<Students>();
            students = _context.Students.ToList();
            studentViewModels = mapper.Map<List<StudentViewModel>>(students);

            List<RequestHeader> RequestHeader = new List<RequestHeader>();
            RequestHeader = _context.RequestHeader.Include(x => x.students).Include(x => x.Admins).Include(x => x.RequestDetails).ToList();

            reportList = mapper.Map<List<StudentReportViewModel>>(RequestHeader);

            foreach (var item in reportList)
            {
                item.RequestCount = RequestHeader.Where(x => x.students.StudentID == item.students.StudentID).Count();
                item.RequsetDelayCount = RequestHeader.Where(x => x.students.StudentID == item.students.StudentID & x.IsDelayed == true).Count();
                item.BookRent = RequestHeader.Where(x => x.students.StudentID == item.students.StudentID).Select(c => c.RequestDetails).Count();
                item.BookDamaged = RequestHeader.Where(x => x.students.StudentID == item.students.StudentID).Select(c => c.RequestDetails.Where(d => d.IsDamaged == true)).Count();
                item.BookLost = RequestHeader.Where(x => x.students.StudentID == item.students.StudentID).Select(c => c.RequestDetails.Where(d => d.IsLost == true)).Count();
                item.CreatedDate = item.CreatedDate;
                item.LongestDelay = RequestHeader.Where(x => x.students.StudentID == item.students.StudentID).Max(x => x.DelayDays) + " روز";
            }

            return reportList;
        }

        public List<StudentViewModel> getList()
        {
            List<Students> students = new List<Students>();
            List<StudentViewModel> studentViews = new List<StudentViewModel>();

            students = _context.Students.ToList();

            var studentConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Students, StudentViewModel>();
            });

            IMapper mapper = studentConfig.CreateMapper();

            studentViews = mapper.Map<List<StudentViewModel>>(students);

            return studentViews;
        }

        public Boolean Accept(int id)
        {
            try
            {
                Students students = new Students();
                students = _context.Students.Where(c => c.StudentID == id).FirstOrDefault();

                if (students != null)
                {
                    students.AcceptedAdminID = 1;

                    _context.Students.Update(students);
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
