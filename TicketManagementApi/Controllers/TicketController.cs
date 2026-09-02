
using Microsoft.AspNetCore.Mvc;
using TicketManagementApi.Models.DTOs;
using TicketManagementApi.Services.IServices;

namespace TicketManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicket _service;

        public TicketController(ITicket service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _service.GetAllTicketsAsync();

            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(Guid id)
        {
            var ticket = await _service.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(CreateTicketDto dto)
        {
            var ticket = await _service.CreateTicketAsync(dto);

            return CreatedAtAction(
                nameof(GetTicketById),
                new { id = ticket.Id },
                ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(
            UpdateTicketDto dto,
            Guid id)
        {
            var ticket = await _service.UpdatedTicketByIdAsync(dto, id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            var deleted = await _service.DeleteTicketByIdAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
