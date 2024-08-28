using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.DTOs;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabilitadoresController : GenericController<Habilitador>
    {
        private readonly IHabilitadoresRepository _habilitadoresRepository;

        public HabilitadoresController(IGenericRepository<Habilitador> genericRepository, IHabilitadoresRepository habilitadoresRepository) : base(genericRepository)
        {
            _habilitadoresRepository = habilitadoresRepository;
        }

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _habilitadoresRepository.GetAsync();
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _habilitadoresRepository.GetAsync(pagination);
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _habilitadoresRepository.GetAsync(id);
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _habilitadoresRepository.GetTotalPagesAsync(pagination);
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }
    }
}
