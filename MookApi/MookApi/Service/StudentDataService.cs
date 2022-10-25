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
            students = _context.Students.Where(x => x.IsRegistered == true).ToList();
            studentViewModels = mapper.Map<List<StudentViewModel>>(students);

            List<RequestHeader> RequestHeader = new List<RequestHeader>();
            RequestHeader = _context.RequestHeader.Include(x => x.students).Include(x => x.Admins).Include(x => x.RequestDetails).ToList();
            List<RequestDetails> requestDetails = new List<RequestDetails>();
            requestDetails = _context.RequestDetails.ToList();

            reportList = mapper.Map<List<StudentReportViewModel>>(students);

            foreach (var item in reportList)
            {
                item.RequestCount = RequestHeader.Where(x => x.students.StudentID == item.StudentID).Count();
                item.RequsetDelayCount = getDelayCount(RequestHeader.Where(x => x.students.StudentID == item.StudentID).ToList());
                item.BookRent = requestDetails.Where(x => x.RequestHeader.StudentID == item.StudentID).Count();
                item.BookDamaged = requestDetails.Where(x => x.IsDamaged == true && x.RequestHeader.StudentID == item.StudentID).Count();
                item.BookLost = requestDetails.Where(x => x.IsLost == true && x.RequestHeader.StudentID == item.StudentID).Count();
                item.CreatedDate = item.CreatedDate;
            }

            return reportList;
        }

        private Delay getIsDelay(RequestHeader rq)
        {
            Delay delay = new Delay();

            var name = JalaliDate.getDay(JalaliDate.getDate(DateTime.Now.ToLocalTime()));
            int? delayValue = JalaliDate.getDay(rq.RequestFinishedDate) - JalaliDate.getDay(JalaliDate.getDate(DateTime.Now.ToLocalTime()));
            if (delayValue != null)
            {
                delay.DelayDays = (int)delayValue;
                if (delay.DelayDays > 0)
                    delay.IsDelayed = true;
                else
                    delay.IsDelayed = false;
            }
            return delay;
        }
        private int getDelayCount(List<RequestHeader> rq)
        {
            int count = 0;
            foreach (var request in rq)
                if (getIsDelay(request).IsDelayed) count++;
            return count;
        }

        public StudentViewModel getByID(int id)
        {
            Students students = new Students();
            StudentViewModel studentViews = new StudentViewModel();

            students = _context.Students.FirstOrDefault(x=> x.StudentID == id);

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
                students = _context.Students.Where(c => c.StudentID == id).FirstOrDefault();

                if (students != null)
                {
                    switch (method)
                    {
                        case changeMethod.IsBlocked:
                            if (students.IsBlocked)
                            {
                                students.IsBlocked = false;
                            }
                            else
                            {
                                students.IsBlocked = true;
                            }
                            break;
                        case changeMethod.IsRegistered:
                            //later
                            //students.AcceptedAdminID = 1;

                            students.IsRegistered = true;
                            break;
                        case changeMethod.IsSuspended:
                            if (students.IsSuspended)
                            {
                                students.IsSuspended = false;
                            }
                            else
                            {
                                students.IsSuspended = true;
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
                students = _context.Students.Where(c => c.StudentID == id).FirstOrDefault();

                if (students != null)
                {
                    students.IsDeleted = true;

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
                students = _context.Students.Where(c => c.StudentID == studentViewModel.StudentID).FirstOrDefault();

                if (students != null)
                {
                    students.StudentName = studentViewModel.StudentName;
                    students.StudentSSID = studentViewModel.StudentSSID;
                    students.StudentUniversityID = studentViewModel.StudentUniversityID;
                    students.SpamCount = studentViewModel.SpamCount;
                    students.IsSuspended = studentViewModel.IsSuspended;
                    students.IsRegistered = studentViewModel.IsRegistered;
                    students.createdDate = studentViewModel.CreatedDate;
                    students.IsBlocked = studentViewModel.IsBlocked;
                    students.reportPoint = studentViewModel.reportPoint;
                    students.IsSpam = studentViewModel.IsSpam;
                    students.IsDeleted = false;

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
                Students duplicateStudent = _context.Students.FirstOrDefault(c => c.StudentSSID == studentViewModel.StudentSSID);

                if (duplicateStudent != null) return false;

                students.StudentName = studentViewModel.StudentName;
                students.StudentSSID = studentViewModel.StudentSSID;
                students.StudentUniversityID = studentViewModel.StudentUniversityID;
                students.SpamCount = 0;
                students.IsSuspended = false;
                students.IsRegistered = false;
                students.createdDate = JalaliDate.getDate(DateTime.Parse(studentViewModel.CreatedDate));
                students.UpdateDate = JalaliDate.getDate(DateTime.Parse(studentViewModel.CreatedDate));
                students.IsBlocked = false;
                students.reportPoint = 0;
                students.IsSpam = false;
                students.IsDeleted = false;
                students.AcceptedAdminID = studentViewModel.AcceptedAdminID;

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
