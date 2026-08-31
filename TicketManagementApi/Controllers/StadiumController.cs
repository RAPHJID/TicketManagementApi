using Microsoft.AspNetCore.Mvc;
using TicketManagementApi.Models;
using TicketManagementApi.Models.DTOs;
using TicketManagementApi.Services.IServices;

namespace TicketManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadiumController : ControllerBase
    {
        private readonly IStadium _stadiumService;

        public StadiumController(IStadium service)
        {
            _stadiumService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStadiums()
        {
            var stadiums = await _stadiumService.GetAllStadiumsAsync();
            return Ok(stadiums);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStadiumById(Guid Id)
        {
            var stadium = await _stadiumService.GetStadiumByIdAsync(Id);
            if(stadium == null) return NotFound($"Stadium with Id {Id} not found");
            return Ok(stadium);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStadium(CreateUpdateStadiumDto dto)
        {
            var created = await _stadiumService.CreateStadiumAsync(dto);
            return CreatedAtAction(nameof(GetStadiumById), new { id = created.Id}, created);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStadium(CreateUpdateStadiumDto dto, Guid Id)
        {
            var updated = await _stadiumService.UpdateStadiumByIdAsync(dto, Id);
            if(updated == null) return NotFound($"Stadium with Id {Id} not found");
            return Ok(updated);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStadium(Guid Id)
        {
            var deleted = await _stadiumService.DeleteStadiumByIdAsync(Id);
            if(!deleted) return NotFound($"Stadium with Id {Id} not found");
            return NoContent();
        }

    }
}
