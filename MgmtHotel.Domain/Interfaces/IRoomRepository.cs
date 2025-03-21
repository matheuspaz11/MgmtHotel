using MgmtHotel.Domain.Entities;

namespace MgmtHotel.Domain.Interfaces
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room> GetRoomByNumber(string numberRoom, CancellationToken cancellationToken);
    }
}
