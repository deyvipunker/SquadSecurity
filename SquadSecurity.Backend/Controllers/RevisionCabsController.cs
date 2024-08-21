using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevisionCabsController : GenericController<RevisionCab>
    {
        private readonly IGenericRepository<RevisionCab> _genericRepository;

        public RevisionCabsController(IGenericRepository<RevisionCab> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
