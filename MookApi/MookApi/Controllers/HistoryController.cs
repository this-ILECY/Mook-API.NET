using Microsoft.AspNetCore.Mvc;
using MookApi.Models;
using MookApi.Service;

namespace MookApi.Controllers
{
    public class HistoryController : ControllerBase
    {

        public HistoryController()
        {
        }

        [HttpPost]
        [Route("index")]
        public ActionResult<History> get([FromBody]string tbName)
        {

            ContextService.getModelData(tbName);

            return Ok();
        }
       


        
    }
}
