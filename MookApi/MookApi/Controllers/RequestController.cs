using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MookApi.Service;
using MookApi.ViewModel;

namespace MookApi.Controllers
{
    [Route("{cotroller}")]
    public class RequestController : ControllerBase
    {

        private readonly RequestDataService _service;
        public RequestController(RequestDataService service)
        {
            _service = service;
        }

        // GET: RequestController
        [HttpGet]
        public ActionResult<List<RequestDataService>> Index()
        {
            List<RequestViewModel> list = new List<RequestViewModel>();
            list = _service.get();

            return Ok(list);
        }


    }
}
