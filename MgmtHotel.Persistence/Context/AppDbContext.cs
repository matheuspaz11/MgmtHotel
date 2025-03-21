using MgmtHotel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MgmtHotel.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
    }
}
