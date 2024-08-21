using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SquadsController : GenericController<Squad>
    {
        private readonly IGenericRepository<Squad> _genericRepository;

        public SquadsController(IGenericRepository<Squad> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
