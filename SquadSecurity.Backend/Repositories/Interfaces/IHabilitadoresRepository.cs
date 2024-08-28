using SquadSecurity.Shared.DTOs;
using SquadSecurity.Shared.Entities;
using SquadSecurity.Shared.Responses;

namespace SquadSecurity.Backend.Repositories.Interfaces
{
    public interface IHabilitadoresRepository
    {
        Task<ActionResponse<Habilitador>> GetAsync(int id);
        Task<ActionResponse<IEnumerable<Habilitador>>> GetAsync();
        Task<ActionResponse<IEnumerable<Habilitador>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalPagesAsync(PaginationDTO pagination);
    }
}
