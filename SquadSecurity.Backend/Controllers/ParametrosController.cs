using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.DTOs;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParametrosController : GenericController<Parametro>
    {
        //private readonly IGenericRepository<Parametro> _genericRepository;
        private readonly IParametrosRepository _parametrosRepository;

        public ParametrosController(IGenericRepository<Parametro> genericRepository, IParametrosRepository parametrosRepository ) : base(genericRepository)
        {
           // _genericRepository = genericRepository;
           _parametrosRepository = parametrosRepository;
        }

        [HttpGet("full")]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _parametrosRepository.GetAsync();
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _parametrosRepository.GetAsync(pagination);
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _parametrosRepository.GetAsync(id);
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet("totalPages")]
        public override async Task<IActionResult> GetPagesAsync([FromQuery] PaginationDTO pagination)
        {
            var response = await _parametrosRepository.GetTotalPagesAsync(pagination);
            if (response.WasSucceess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

    }
}
