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

        
    }
}
