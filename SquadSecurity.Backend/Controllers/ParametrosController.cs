using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParametrosController : GenericController<Parametro>
    {
        private readonly IGenericRepository<Parametro> _genericRepository;

        public ParametrosController(IGenericRepository<Parametro> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
