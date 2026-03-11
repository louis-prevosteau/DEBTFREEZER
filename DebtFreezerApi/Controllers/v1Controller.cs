using DebtFreezerApi.Dtos;
using DebtFreezerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebtFreezerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class v1Controller : ControllerBase

    {
        private readonly IDebtService _debtService;

        public v1Controller(IDebtService debtService )
        {
            _debtService = debtService;
        }

        [HttpGet("debts")]
        public async Task<ActionResult<List<DebtDto>>> GetAllAsync()
        {
            return Ok(await _debtService.GetAllAsync());
        }


        [HttpGet("debts/{id}")]
        public async Task<ActionResult<DebtDto>> GetByIdAsync([FromRoute]int id)
        {
            return Ok(await _debtService.GetByIdAsync(id));
        }


        [Authorize]
        [HttpPost("debts")]
        public async  Task<ActionResult<DebtDto>> CreateAsync([FromBody] CreateDebtDto dto)
        {
            //L'attribut Apicontroller en haut de la classe fait cette verification 
            // 

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var detteCree = await _debtService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { Id = detteCree.Id }, detteCree); 

        }

        [Authorize]
        [HttpPatch("debts/{id}")]
        public async Task<IActionResult> UpdateAsync ([FromRoute] int id, [FromBody] UpdateDebtDto dto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            bool detteModifiee = await _debtService.UpdateAsync(id, dto);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("debts/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _debtService.DeleteAsync(id);
            return NoContent();
        }


        
    }
}
