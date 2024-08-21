using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SquadDetallesController : GenericController<SquadDetalle>
    {
        private readonly IGenericRepository<SquadDetalle> _genericRepository;

        public SquadDetallesController(IGenericRepository<SquadDetalle> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
