using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MookApi.Service;
using MookApi.ViewModel;

namespace MookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {

        private readonly RequestDataService _service;
        public RequestController(RequestDataService service)
        {
            _service = service;
        }

       
       [HttpGet]
        public ActionResult<List<RequestViewModel>> Index()
        {
            List<RequestViewModel> list = new List<RequestViewModel>();
            list = _service.get();
            return Ok(list);
        }

        [HttpPost]
        public ActionResult<bool> create(RequestViewModel requestViewModel)
        {
            bool report = _service.create(requestViewModel);
            return Ok(report);
        }

        [HttpPut("{id}")]
        public ActionResult<Boolean> Accept(int id)
        {
            bool report = _service.Accept(id);
            return Ok(report);
        }

        [HttpDelete("{id}")]
        public ActionResult<Boolean> Delete(int id)
        {
            bool report = _service.Delete(id);
            return Ok(report);
        }
    }
}
