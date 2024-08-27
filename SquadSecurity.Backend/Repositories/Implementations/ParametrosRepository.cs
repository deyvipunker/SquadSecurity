using Microsoft.EntityFrameworkCore;
using SquadSecurity.Backend.Data;
using SquadSecurity.Backend.Helpers;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.DTOs;
using SquadSecurity.Shared.Entities;
using SquadSecurity.Shared.Responses;

namespace SquadSecurity.Backend.Repositories.Implementations
{
    public class ParametrosRepository : GenericRepository<Parametro>, IParametrosRepository
    {
        private readonly DataContext _context;

        public ParametrosRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<ActionResponse<IEnumerable<Parametro>>> GetAsync()
        {
            var countries = await _context.Parametros
                .OrderBy(c => c.Nombre)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Parametro>>
            {
                WasSucceess = true,
                Result = countries
            };
        }

        public override async Task<ActionResponse<IEnumerable<Parametro>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Parametros.AsQueryable();
                //.Include(c => c.States)
                //.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Nombre.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Parametro>>
            {
                WasSucceess = true,
                Result = await queryable
                .OrderBy(c => c.Nombre)
                .Paginate(pagination)
                .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Parametros.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Nombre.ToLower().Contains(pagination.Filter.ToLower()));
            }
            double count = await queryable.CountAsync();
            int totalpages = (int)Math.Ceiling(count / pagination.RecorsNumber);

            return new ActionResponse<int>
            {
                WasSucceess = true,
                Result = totalpages
            };
        }

        public override async Task<ActionResponse<Parametro>> GetAsync(int id)
        {
            var country = await _context.Parametros
               .FirstOrDefaultAsync(c => c.Id == id);

            if (country == null)
            {
                return new ActionResponse<Parametro>
                {
                    WasSucceess = false,
                    Message = "Parametro no existe"
                };
            }

            return new ActionResponse<Parametro>
            {
                WasSucceess = true,
                Result = country
            };
        }
    }
}
