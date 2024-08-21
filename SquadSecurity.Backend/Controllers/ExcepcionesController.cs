using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExcepcionesController : GenericController<Excepcion>
    {
        private readonly IGenericRepository<Excepcion> _genericRepository;

        public ExcepcionesController(IGenericRepository<Excepcion> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
