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
                await _unitOfWork.RoolbackTransactionAsync();
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
                await _unitOfWork.RoolbackTransactionAsync();
                throw;
            }
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id && x.DeletionDate == null);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            try
            {
                entity.UpdateDate = DateTime.Now;
                
                await _unitOfWork.BeginTransactionAsync();

                _context.Update(entity);

                await _unitOfWork.SaveAsync();

                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception) 
            {
                await _unitOfWork.RoolbackTransactionAsync();
                throw;
            }
        }
    }
}
