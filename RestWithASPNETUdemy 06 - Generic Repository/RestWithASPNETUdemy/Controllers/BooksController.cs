using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Service;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Controllers {
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : ControllerBase {
        private IBookService _bookService;

        public BooksController(IBookService bookService) {
            this._bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get() {
            return this.Ok(this._bookService.FindAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            Book book = this._bookService.FindById(id);
            if (book == null)
                return this.NotFound();
            else
                return this.Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] Book book) {
            if (book == null)
                return this.BadRequest();
            else
                return new ObjectResult(this._bookService.Create(book));
        }

        // PUT api/books
        public IActionResult Put([FromBody] Book book) {
            if (book == null)
                return this.BadRequest();
            else if (this._bookService.FindById((long)book.Id) == null)
                return this.NotFound();
            else
                return new ObjectResult(this._bookService.Update(book));
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            this._bookService.Delete(id);
            return this.Ok();
        }
    }
}