using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MookApi.Service;
using MookApi.ViewModel;
using static MookApi.Service.StudentDataService;

namespace MookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDataService _service;

        public StudentController(StudentDataService service)
        {
            _service = service;
        }

        [HttpGet("rpt")]
        public ActionResult<List<StudentReportViewModel>> getReport()
        {
            List<StudentReportViewModel> report = new List<StudentReportViewModel>();
            report = _service.getReport();
            return Ok(report);
        }

        [HttpGet]
        public ActionResult<List<StudentReportViewModel>> get()
        {
            List<StudentViewModel> report = new List<StudentViewModel>();
            report = _service.getList();
            return Ok(report);
        }

        [HttpPut("{id}")]
        public ActionResult<Boolean> Change(int id, changeMethod method)
        {
            bool report = _service.Change(id, method);
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public ActionResult<Boolean> deleteNewRegister(int id)
        {
            bool report = _service.Delete(id);
            return Ok(report);
        }

    }
}
