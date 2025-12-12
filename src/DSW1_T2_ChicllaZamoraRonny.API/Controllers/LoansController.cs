using Microsoft.AspNetCore.Mvc;
using DSW1_T2_ChicllaZamoraRonny.Application.DTOs;
using DSW1_T2_ChicllaZamoraRonny.Application.Interfaces;

namespace DSW1_T2_ChicllaZamoraRonny.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoansController(ILoanService loanService) => _loanService = loanService;

        [HttpGet]
        public async Task<IActionResult> GetActive() => Ok(await _loanService.GetActiveLoansAsync());

        [HttpPost]
        public async Task<IActionResult> Create(CreateLoanDto dto)
        {
            try {
                var result = await _loanService.CreateLoanAsync(dto);
                return Ok(result);
            } catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> Return(int id)
        {
            try {
                await _loanService.ReturnLoanAsync(id);
                return NoContent();
            } catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        }
    }
}