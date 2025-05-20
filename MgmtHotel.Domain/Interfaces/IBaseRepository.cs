using MgmtHotel.Domain.Entities;

namespace MgmtHotel.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<T> Get(int id);

        Task<List<T>> GetAll();

        Task<List<T>> GetRoomsByPage(int numberPage, int pageSize);
    }
}
