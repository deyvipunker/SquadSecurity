using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Backend.UnitsOfWork.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevisionCabController : GenericController<RevisionCab>
    {
        private readonly IGenericRepository<RevisionCab> _genericRepository;

        public RevisionCabController(IGenericRepository<RevisionCab> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
