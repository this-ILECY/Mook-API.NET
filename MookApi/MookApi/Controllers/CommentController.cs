using Microsoft.AspNetCore.Mvc;
using MookApi.Service;
using MookApi.ViewModel;

namespace MookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly CommentDataService _service;

        public CommentController(CommentDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<CommentViewModel>> CommentList()
        {
            IEnumerable<CommentViewModel> comment = new List<CommentViewModel>();
            comment = _service.CommentList();

            if (comment != null) return Ok(comment);
            else return BadRequest();
        }
        
        [HttpPost]
        public ActionResult Create([FromBody]CommentViewModel comments)
        {
            bool IsCreated = _service.create(comments);
            if (IsCreated) return Ok(IsCreated);
            else return BadRequest();
        }

        [HttpPut]
        public ActionResult Edit([FromBody]CommentViewModel comments)
        {
            bool IsEdited = _service.update(comments);
            if (IsEdited) return Ok(IsEdited);
            else return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool IsDeleted = _service.delete(id);
            if (IsDeleted) return Ok(IsDeleted);
            else return BadRequest(IsDeleted);
        }
        [Route("/api/[Controller]/a/{id}")]
        [HttpDelete]
        public ActionResult<List<CommentViewModel>> AcceptComment(int id)
        {
            bool IsAccepted = _service.Accept(id);
            if (IsAccepted) return Ok(IsAccepted);
            else return BadRequest(IsAccepted);
        }


    }
}
