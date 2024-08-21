using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevisionDetsController : GenericController<RevisionDet>
    {
        private readonly IGenericRepository<RevisionDet> _genericRepository;

        public RevisionDetsController(IGenericRepository<RevisionDet> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
