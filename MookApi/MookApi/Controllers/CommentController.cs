using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MookApi.Context;
using MookApi.Models;
using MookApi.Service;
using MookApi.ViewModel;
using System.Linq;

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
        // GET: CommentController
        public ActionResult<List<CommentViewModel>> CommentList()
        {
            IEnumerable<CommentViewModel> comment = new List<CommentViewModel>();
            comment = _service.CommentList();

            return Ok();
        }

        //// GET: CommentController/Details/5
        //public ActionResult Details(int CommentID)
        //{
        //    return View();
        //}

        [HttpPost]
        // GET: CommentController/Create
        public ActionResult Create(CommentViewModel commentViewModel)
        {
            return Ok();
        }


        // GET: CommentController/Edit/5
        [HttpPut]
        public ActionResult Edit(CommentViewModel commentViewModel)
        {
            return Ok();
        }


        // GET: CommentController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int CommentID)
        {
            return Ok();
        }


    }
}
