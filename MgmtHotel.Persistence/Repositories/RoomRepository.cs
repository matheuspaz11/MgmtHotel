using MgmtHotel.Domain.Entities;
using MgmtHotel.Domain.Interfaces;
using MgmtHotel.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MgmtHotel.Persistence.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext appDbContext) : base(appDbContext) {}

        public async Task<Room> GetRoomByNumber(string numberRoom)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == numberRoom && x.DeletionDate == null);
        }
    }
}
