using MgmtHotel.Domain.Entities;
using MgmtHotel.Domain.Interfaces;
using MgmtHotel.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MgmtHotel.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public Task Create(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;

            _context.Add(entity);
            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task Delete(T entity)
        {
            entity.DeletionDate = DateTime.Now;
            _context.Remove(entity);
            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public Task Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            _context.Update(entity);
            _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
