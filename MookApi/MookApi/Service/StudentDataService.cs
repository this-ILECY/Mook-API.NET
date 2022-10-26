using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MookApi.Common;
using MookApi.Context;
using MookApi.Models;
using MookApi.ViewModel;

namespace MookApi.Service
{
    public class StudentDataService
    {
        public enum changeMethod
        {
            IsBlocked,
            IsRegistered,
            IsSuspended
        }

        private readonly AppDbContext _context;

        public StudentDataService(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentReportViewModel> getReport()
        {

            var studentConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Students, StudentReportViewModel>();
                cfg.CreateMap<RequestDetails, RequestDetailViewModel>();
                cfg.CreateMap<Books, BookViewModel>();
                cfg.CreateMap<Students, StudentViewModel>();
            });

            IMapper mapper = studentConfig.CreateMapper();


            List<StudentReportViewModel> reportList = new List<StudentReportViewModel>();

            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();
            List<Students> students = new List<Students>();
            students = _context.Students.Where(x => x.isRegistered == true).ToList();
            studentViewModels = mapper.Map<List<StudentViewModel>>(students);

            List<RequestHeader> RequestHeader = new List<RequestHeader>();
            RequestHeader = _context.RequestHeader.Include(x => x.students).Include(x => x.admins).Include(x => x.requestDetails).ToList();
            List<RequestDetails> requestDetails = new List<RequestDetails>();
            requestDetails = _context.RequestDetails.ToList();

            reportList = mapper.Map<List<StudentReportViewModel>>(students);

            foreach (var item in reportList)
            {
                item.requestCount = RequestHeader.Where(x => x.students.studentID == item.studentID).Count();
                item.requsetDelayCount = getDelayCount(RequestHeader.Where(x => x.students.studentID == item.studentID).ToList());
                item.BookRent = requestDetails.Where(x => x.requestHeader.studentID == item.studentID).Count();
                item.bookDamaged = requestDetails.Where(x => x.isDamaged == true && x.requestHeader.studentID == item.studentID).Count();
                item.bookLost = requestDetails.Where(x => x.isLost == true && x.requestHeader.studentID == item.studentID).Count();
                item.createdDate = item.createdDate;
            }

            return reportList;
        }

        private int getDelayCount(List<RequestHeader> rq)
        {
            int count = 0;
            foreach (var request in rq)
                if (JalaliDate.getIsDelay(request,null).isDelayed) count++;
            return count;
        }

        public StudentViewModel getByID(int id)
        {
            Students students = new Students();
            StudentViewModel studentViews = new StudentViewModel();

            students = _context.Students.FirstOrDefault(x => x.studentID == id);

            var studentConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Students, StudentViewModel>();
            });

            IMapper mapper = studentConfig.CreateMapper();

            studentViews = mapper.Map<StudentViewModel>(students);

            return studentViews;
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
        public Boolean Change(int id, changeMethod method)
        {
            try
            {
                Students students = new Students();
                students = _context.Students.Where(c => c.studentID == id).FirstOrDefault();

                if (students != null)
                {
                    switch (method)
                    {
                        case changeMethod.IsBlocked:
                            if (students.isBlocked)
                            {
                                students.isBlocked = false;
                            }
                            else
                            {
                                students.isBlocked = true;
                            }
                            break;
                        case changeMethod.IsRegistered:
                            //later
                            //students.AcceptedAdminID = 1;

                            students.isRegistered = true;
                            break;
                        case changeMethod.IsSuspended:
                            if (students.isSuspended)
                            {
                                students.isSuspended = false;
                            }
                            else
                            {
                                students.isSuspended = true;
                            }
                            break;
                        default:
                            return false;
                    }



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
        public Boolean Delete(int id)
        {
            try
            {
                Students students = new Students();
                students = _context.Students.Where(c => c.studentID == id).FirstOrDefault();

                if (students != null)
                {
                    students.isDeleted = true;

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
        public Boolean Update(StudentViewModel studentViewModel)
        {

            Students students = new Students();

            try
            {
                students = _context.Students.Where(c => c.studentID == studentViewModel.studentID).FirstOrDefault();

                if (students != null)
                {
                    students.studentName = studentViewModel.studentName;
                    students.studentSSID = studentViewModel.studentSSID;
                    students.studentUniversityID = studentViewModel.studentUniversityID;
                    students.spamCount = studentViewModel.spamCount;
                    students.isSuspended = studentViewModel.isSuspended;
                    students.isRegistered = studentViewModel.isRegistered;
                    students.createdDate = studentViewModel.createdDate;
                    students.isBlocked = studentViewModel.isBlocked;
                    students.reportPoint = studentViewModel.reportPoint;
                    students.isSpam = studentViewModel.isSpam;
                    students.isDeleted = false;

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
            return true;
        }
        public Boolean Create(StudentViewModel studentViewModel)
        {
            Students students = new Students();
            try
            {
                Students duplicateStudent = _context.Students.FirstOrDefault(c => c.studentSSID == studentViewModel.studentSSID);

                if (duplicateStudent != null) return false;

                students.studentName = studentViewModel.studentName;
                students.studentSSID = studentViewModel.studentSSID;
                students.studentUniversityID = studentViewModel.studentUniversityID;
                students.spamCount = 0;
                students.isSuspended = false;
                students.isRegistered = false;
                students.createdDate = JalaliDate.getDate(DateTime.Parse(studentViewModel.createdDate));
                students.updateDate = JalaliDate.getDate(DateTime.Parse(studentViewModel.createdDate));
                students.isBlocked = false;
                students.reportPoint = 0;
                students.isSpam = false;
                students.isDeleted = false;
                students.acceptedAdminID = studentViewModel.acceptedAdminID;

                _context.Students.Add(students);
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
