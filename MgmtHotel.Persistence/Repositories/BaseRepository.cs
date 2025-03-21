using MgmtHotel.Domain.Entities;
using MgmtHotel.Domain.Interfaces;
using MgmtHotel.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MgmtHotel.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context;

        public BaseRepository(AppDbContext appDbContext)
        {
            Context = appDbContext;
        }

        public void Create(T entity)
        {
            entity.CreateDate = DateTime.Now;
            Context.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.DeletionDate = DateTime.Now;
            Context.Remove(entity);
        }

        public async Task<T> Get(int id, CancellationToken cancellationToken)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            Context.Update(entity);
        }
    }
}
