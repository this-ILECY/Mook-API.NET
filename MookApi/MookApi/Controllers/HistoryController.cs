using Microsoft.AspNetCore.Mvc;
using MookApi.Models;
using MookApi.Service;

namespace MookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {

        public HistoryController()
        {
        }

        [HttpPost]
        public ActionResult<History> get([FromBody]string tbName)
        {

            ContextService.getModelData(tbName);

            return Ok();
        }
       


        
    }
}
