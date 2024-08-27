using SquadSecurity.Shared.DTOs;
using SquadSecurity.Shared.Entities;
using SquadSecurity.Shared.Responses;
using System.Diagnostics.Metrics;

namespace SquadSecurity.Backend.Repositories.Interfaces
{
    public interface IParametrosRepository
    {
        Task<ActionResponse<Parametro>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Parametro>>> GetAsync();
        Task<ActionResponse<IEnumerable<Parametro>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
