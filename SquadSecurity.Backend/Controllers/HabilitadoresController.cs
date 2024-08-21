using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabilitadoresController : GenericController<Habilitador>
    {
        private readonly IGenericRepository<Habilitador> _genericRepository;

        public HabilitadoresController(IGenericRepository<Habilitador> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
