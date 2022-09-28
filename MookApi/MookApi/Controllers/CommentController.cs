using Microsoft.AspNetCore.Mvc;
using MookApi.Service;
using MookApi.ViewModel;

namespace MookApi.Controllers
{
    [Route("comments")]
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

        [HttpDelete]
        public ActionResult Delete(int CommentID)
        {
            bool IsDeleted = _service.delete(CommentID);
            if (IsDeleted) return Ok(IsDeleted);
            else return BadRequest(IsDeleted);
        }

    }
}
