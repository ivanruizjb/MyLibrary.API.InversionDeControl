using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.DTOs;
using MyLibrary.Application.Services.interfaces;

namespace MyLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _bookService;

        public BooksController(IBooksService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookDTO bookDTO)
        {
            var book = _bookService.AddBook(bookDTO);
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, [FromBody] BookDTO bookDTO)
        {
            var book = _bookService.UpdateBook(id, bookDTO);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var deleted = _bookService.DeleteBook(id);

            if (!deleted)
                return NotFound();

            return Ok("Libro eliminado");
        }
    }
}