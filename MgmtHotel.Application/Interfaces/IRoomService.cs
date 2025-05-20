using MgmtHotel.Application.DTOs;

namespace MgmtHotel.Application.Interfaces
{
    public interface IRoomService
    {
        Task Insert(RoomDTO roomDTO);
        Task<RoomDTO> Update(RoomUpdateDTO roomUpdateDTO, RoomDTO roomDTO);
        Task Delete(int id);
        Task<RoomDTO> GetAsync(int id);
        Task<List<RoomDTO>> GetPagedRoomsAsync(int pageNumber, int pageSize);
    }
}
