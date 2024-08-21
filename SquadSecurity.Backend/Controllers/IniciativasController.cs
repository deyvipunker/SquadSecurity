using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IniciativasController : GenericController<Iniciativa>
    {
        private readonly IGenericRepository<Iniciativa> _genericRepository;

        public IniciativasController(IGenericRepository<Iniciativa> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
