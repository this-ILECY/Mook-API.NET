using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MookApi.Service;
using MookApi.ViewModel;

namespace MookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDataService _service;

        public BookController(BookDataService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<BookViewModel>> getAll()
        {
            List<BookViewModel> books = new List<BookViewModel>();
            books = _service.get();
            if (books != null) return Ok(books);
            else return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<BookViewModel> getByID(int id)
        {
            BookViewModel book = new BookViewModel();
            book = _service.getByID(id);
            if (book != null) return Ok(book);
            else return BadRequest();
        }

        [HttpPut]
        public ActionResult<Boolean> Update(BookViewModel bookViewModel)
        {

            bool result = _service.Update(bookViewModel);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        [HttpPost]
        public ActionResult<Boolean> Create(BookViewModel bookViewModel)
        {
            bool result = _service.Create(bookViewModel);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

    }
}
