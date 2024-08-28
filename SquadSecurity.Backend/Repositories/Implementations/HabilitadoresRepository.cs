using Microsoft.EntityFrameworkCore;
using SquadSecurity.Backend.Data;
using SquadSecurity.Backend.Helpers;
using SquadSecurity.Backend.Repositories.Interfaces;
using SquadSecurity.Shared.DTOs;
using SquadSecurity.Shared.Entities;
using SquadSecurity.Shared.Responses;



namespace SquadSecurity.Backend.Repositories.Implementations
{
    public class HabilitadoresRepository : GenericRepository<Habilitador>, IHabilitadoresRepository
    {
        private readonly DataContext _context;

        public HabilitadoresRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<IEnumerable<Habilitador>>> GetAsync()
        {
            var habilitadores = await _context.Habilitadores
                .OrderBy(h => h.Titulo)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Habilitador>>
            {
                WasSucceess = true,
                Result = habilitadores
            };
        }

        public override async Task<ActionResponse<IEnumerable<Habilitador>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Habilitadores.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Titulo.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Habilitador>>
            {
                WasSucceess = true,
                Result = await queryable
                .OrderBy(h => h.Titulo)
                .Paginate(pagination)
                .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination)
        {
            var queryable = _context.Habilitadores.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Titulo.ToLower().Contains(pagination.Filter.ToLower()));
            }
            double count = await queryable.CountAsync();
            int totalPages = (int)Math.Ceiling(count / pagination.RecorsNumber);

            return new ActionResponse<int>
            {
                WasSucceess = true,
                Result = totalPages
            };
        }

        public override async Task<ActionResponse<Habilitador>> GetAsync(int id)
        {
            var habilitador = await _context.Habilitadores
               .FirstOrDefaultAsync(h => h.Id == id);

            if (habilitador == null)
            {
                return new ActionResponse<Habilitador>
                {
                    WasSucceess = false,
                    Message = "Habilitador no existe"
                };
            }

            return new ActionResponse<Habilitador>
            {
                WasSucceess = true,
                Result = habilitador
            };
        }
    }
}

