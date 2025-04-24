using MgmtHotel.Domain.Interfaces;
using MgmtHotel.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace MgmtHotel.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        private IDbContextTransaction? _transaction;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _appDbContext.SaveChangesAsync();

                await _transaction.CommitAsync();

                await _transaction.DisposeAsync();

                _transaction = null;
            }
        }

        public async Task RoolbackTransactionAsync()
        {
            if( _transaction != null)
            {
                await _transaction.RollbackAsync();

                await _transaction.DisposeAsync();

                _transaction = null;
            }
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
