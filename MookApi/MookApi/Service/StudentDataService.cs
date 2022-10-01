using MookApi.Context;
using MookApi.Models;
using MookApi.ViewModel;
using System.Collections.Generic;

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
            List<StudentReportViewModel> reportList = new List<StudentReportViewModel>();

            List<StudentViewModel> studentViewModels = new List<StudentViewModel>();
            studentViewModels = _context.Students.Select(x => new StudentViewModel()
            {
                IsBlocked = x.IsBlocked,
                IsRegistered = x.IsRegistered,
                IsSpam = x.IsSpam,
                IsSuspended = x.IsSuspended,
                reportPoint = x.reportPoint,
                SpamCount = x.SpamCount,

                StudentID = x.StudentID,
                StudentName = x.StudentName,
                StudentSSID = x.StudentSSID,
                StudentUniversityID = x.StudentUniversityID,
                CreatedDate = x.CreatedDate
            }).ToList();

            List<RequestHeader> RequestHeader = new List<RequestHeader>();
            RequestHeader = _context.RequestHeader.Select(x => new RequestHeader()
            {
                AcceptedAdminID = x.AcceptedAdminID,
                Admins = x.Admins,
                CreatedDate = x.CreatedDate,
                DelayDays = x.DelayDays,
                IsAccepted = x.IsAccepted,
                IsDelayed = x.IsDelayed,
                IsDeleted = x.IsDeleted,
                RequestAcceptedDate = x.RequestAcceptedDate,
                RequestDetails = x.RequestDetails,
                RequestFinishedDate = x.RequestFinishedDate,
                RequestID = x.RequestID,
                students = x.students,
                UpdateDate = x.UpdateDate,
                RequestDecription = x.RequestDecription
            }).ToList();

            foreach (var item in studentViewModels)
            {
                reportList.Add(new StudentReportViewModel()
                {
                    name = item.StudentName,
                    SID = item.StudentSSID,
                    UniID = item.StudentUniversityID,
                    RequestCount = RequestHeader.Where(x => x.students.StudentID == item.StudentID).Count(),
                    DelayedCount = RequestHeader.Where(x => x.students.StudentID == item.StudentID & x.IsDelayed == true).Count(),
                    bookCount = RequestHeader.Where(x => x.students.StudentID == item.StudentID).Select(c => c.RequestDetails).Count(),
                    DamagedBookCount = RequestHeader.Where(x => x.students.StudentID == item.StudentID).Select(c => c.RequestDetails.Where(d => d.IsDamaged == true)).Count(),
                    LostBookCount = RequestHeader.Where(x => x.students.StudentID == item.StudentID).Select(c => c.RequestDetails.Where(d => d.IsLost == true)).Count(),
                    RegisterDate = item.CreatedDate,
                    TopDelay = RequestHeader.Where(x => x.students.StudentID == item.StudentID).Max(x => x.DelayDays) + " روز"
                });
            }

            return reportList;
        }

        public List<StudentViewModel> getList()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            students = _context.Students.Select(c => new StudentViewModel()
            {
                CreatedDate = c.CreatedDate,
                IsBlocked = c.IsBlocked,
                SpamCount = c.SpamCount,
                IsRegistered = c.IsRegistered,
                StudentName = c.StudentName,
                IsSuspended = c.IsSuspended,
                StudentID = c.StudentID,
                IsSpam = c.IsSpam,
                StudentSSID = c.StudentSSID,
                StudentUniversityID = c.StudentUniversityID,
                reportPoint = c.reportPoint
            }).ToList();

            return students;
        }
    }
}
