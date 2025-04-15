using MgmtHotel.Application.DTOs;
using MgmtHotel.Domain.Pagination;

namespace MgmtHotel.Application.Interfaces
{
    public interface IRoomService
    {
        Task Insert(RoomDTO roomDTO);
        Task Update(RoomDTO roomDTO);
        Task Delete(int id);
        Task<RoomDTO> GetAsync(int id);
        Task<PagedList<RoomDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<PagedList<RoomDTO>> GetByFilterAsync(string termo, int pageNumber, int pageSize);
    }
}
