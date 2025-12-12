using Microsoft.AspNetCore.Mvc;
using DSW1_T2_ChicllaZamoraRonny.Application.DTOs;
using DSW1_T2_ChicllaZamoraRonny.Application.Interfaces;

namespace DSW1_T2_ChicllaZamoraRonny.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService) => _bookService = bookService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _bookService.GetAllBooksAsync());

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            try {
                var result = await _bookService.CreateBookAsync(dto);
                return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
            } catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }
    }
}