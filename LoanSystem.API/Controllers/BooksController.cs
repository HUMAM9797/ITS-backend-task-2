using LoanSystem.Application.DTOs;
using LoanSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoanSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBook([FromBody] CreateBookRequest request)
        {
            var bookId = await _bookService.CreateBookAsync(request);
            return CreatedAtAction(nameof(CreateBook), new { id = bookId }, bookId);
        }
    }
}
