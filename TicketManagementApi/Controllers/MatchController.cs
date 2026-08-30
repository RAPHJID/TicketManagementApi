using Microsoft.AspNetCore.Mvc;
using TicketManagementApi.Models.DTOs;
using TicketManagementApi.Services.IServices;

namespace TicketManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatch _matchService;
        public MatchController(IMatch matchService)
        {
            _matchService = matchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatchesAsync();
            return Ok(matches);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMatchById(Guid Id)
        {
            var match = await _matchService.GetMatchByIdAsync(Id);
            if(match == null) return NotFound($"Match with Id {Id} not found!");
            return Ok(match);
        }
        [HttpPost]
        public async Task<IActionResult> AddMatch(CreateMatchDto dto)
        {
            var created = await _matchService.CreateMatchAsync(dto);
            return CreatedAtAction(nameof(GetMatchById), new { id = created.Id}, created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMatch(UpdateMatchDto dto, Guid Id)
        {
            var updated = await _matchService.UpdateMatchByIdAsync(dto, Id);
            if(updated == null) return NotFound($"Match with Id {Id} not Found!");   
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMatch(Guid Id)
        {
            var deleted = await _matchService.DeleteMatchByIdAsync(Id);
            if(!deleted) return NotFound($"Match with Id {Id} not found");
            return NoContent();
        }
    }
}
