using MgmtHotel.Domain.Entities;
using MgmtHotel.Domain.Interfaces;
using MgmtHotel.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MgmtHotel.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        public BaseRepository(AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _context = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(T entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;

                await _unitOfWork.BeginTransactionAsync();

                _context.Add(entity);

                await _unitOfWork.SaveAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception) 
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                entity.DeletionDate = DateTime.Now;
                
                await _unitOfWork.BeginTransactionAsync();

                _context.Update(entity);

                await _unitOfWork.SaveAsync();
                
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception) 
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.DeletionDate == null);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetRoomsByPage(int numberPage, int pageSize)
        {
            return await _context.Set<T>()
                .Where(x => x.DeletionDate == null)
                .Skip((numberPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task Update(T entity)
        {
            try
            {
                entity.UpdateDate = DateTime.Now;
                
                await _unitOfWork.BeginTransactionAsync();

                _context.Update(entity);

                _context.Entry(entity).Property(e => e.CreateDate).IsModified = false;

                await _unitOfWork.SaveAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception) 
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
