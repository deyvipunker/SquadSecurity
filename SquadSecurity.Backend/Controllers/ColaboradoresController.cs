using Microsoft.AspNetCore.Mvc;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradoresController : GenericController<Colaborador>
    {
        private readonly IGenericRepository<Colaborador> _genericRepository;

        public ColaboradoresController(IGenericRepository<Colaborador> genericRepository) : base(genericRepository)
        {
            _genericRepository = genericRepository;
        }
    }
}
