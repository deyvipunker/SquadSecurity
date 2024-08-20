using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Implementations;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Backend.UnitsOfWork.Interfaces;

namespace SquadSecurity.Backend.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericController(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            var action = await _genericRepository.GetAsync();
            if (action.WasSucceess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _genericRepository.GetAsync(id);
            if (action.WasSucceess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T model)
        {
            var action = await _genericRepository.AddAsync(model);
            if (action.WasSucceess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _genericRepository.UpdateAsync(model);
            if (action.WasSucceess)
            {
                return Ok(action.Result);
            }

            return BadRequest(action.Message);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _genericRepository.DeleteAsync(id);
            if (action.WasSucceess)
            {
                return NoContent();
            }

            return BadRequest(action.Message);
        }
    }
}
