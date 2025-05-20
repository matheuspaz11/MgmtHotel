namespace MgmtHotel.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}
